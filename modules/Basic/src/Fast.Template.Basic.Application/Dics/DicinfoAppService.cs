using System;
using System.Linq;
using System.Threading.Tasks;
using Fast.Template.Basic.Permissions;
using Fast.Template.Basic.Dics.Dtos;
using Fast.Template.Common.Applicaiton.Base;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;

namespace Fast.Template.Basic.Dics;


/// <summary>
/// 数据字典
/// </summary>
public class DicinfoAppService : BaseCrudAppService<Dicinfo, DicinfoDto, Guid, DicinfoGetListInput, CreateUpdateDicinfoDto, CreateUpdateDicinfoDto>,
    IDicinfoAppService
{
    //protected override string GetPolicyName { get; set; } = BasicPermissions.Dicinfo.Default;
    //protected override string GetListPolicyName { get; set; } = BasicPermissions.Dicinfo.Default;
    //protected override string CreatePolicyName { get; set; } = BasicPermissions.Dicinfo.Create;
    //protected override string UpdatePolicyName { get; set; } = BasicPermissions.Dicinfo.Update;
    //protected override string DeletePolicyName { get; set; } = BasicPermissions.Dicinfo.Delete;

    private readonly IDicinfoRepository _repository;

    public DicinfoAppService(IDicinfoRepository repository) : base(repository)
    {
        _repository = repository;
    }

    protected override async Task<IQueryable<Dicinfo>> CreateFilteredQueryAsync(DicinfoGetListInput input)
    {
        return (await _repository.WithDetailsAsync())
            .WhereIf(input.DictypeId != null, x => x.DictypeId == input.DictypeId)
            .WhereIf(!input.Name.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Name))
            .WhereIf(!input.Value.IsNullOrWhiteSpace(), x => x.Value.Contains(input.Value))
            .WhereIf(input.Status != null, x => x.Status == input.Status)
            ;
    }

    protected override async Task CreateBeforeAsync(Dicinfo entity)
    {
        if (await _repository.AnyAsync(d => d.Value.Equals(entity.Value)))
        {
            throw new UserFriendlyException("编码已存在");
        }
    }

    protected override async Task UpdateBeforeAsync(Dicinfo entity)
    {
        var exists = await _repository.AnyAsync(d => d.Id != entity.Id && d.Value.Equals(entity.Value));
        if (exists)
        {
            throw new UserFriendlyException("编码已存在");
        }
    }
}
