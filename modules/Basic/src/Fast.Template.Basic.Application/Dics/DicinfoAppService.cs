using System;
using System.Linq;
using System.Threading.Tasks;
using Fast.Template.Basic.Permissions;
using Fast.Template.Basic.Dics.Dtos;
using Fast.Template.Common.Applicaiton.Base;

namespace Fast.Template.Basic.Dics;


/// <summary>
/// Êý¾Ý×Öµä
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
}
