using System;
using System.Linq;
using System.Threading.Tasks;
using Fast.Template.Basic.Permissions;
using Fast.Template.Basic.Dics.Dtos;
using Fast.Template.Common.Applicaiton.Base;

namespace Fast.Template.Basic.Dics;


/// <summary>
/// 字典类型
/// </summary>
public class DicTypeAppService : BaseCrudAppService<DicType, DicTypeDto, Guid, DicTypeGetListInput, CreateUpdateDicTypeDto, CreateUpdateDicTypeDto>,
    IDicTypeAppService
{
    //protected override string GetPolicyName { get; set; } = BasicPermissions.DicType.Default;
    //protected override string GetListPolicyName { get; set; } = BasicPermissions.DicType.Default;
    //protected override string CreatePolicyName { get; set; } = BasicPermissions.DicType.Create;
    //protected override string UpdatePolicyName { get; set; } = BasicPermissions.DicType.Update;
    //protected override string DeletePolicyName { get; set; } = BasicPermissions.DicType.Delete;

    private readonly IDicTypeRepository _repository;

    public DicTypeAppService(IDicTypeRepository repository) : base(repository)
    {
        _repository = repository;
    }

    protected override async Task<IQueryable<DicType>> CreateFilteredQueryAsync(DicTypeGetListInput input)
    {
        // TODO: AbpHelper generated
        return (await base.CreateFilteredQueryAsync(input))
            .WhereIf(!input.Name.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Name))
            .WhereIf(!input.Code.IsNullOrWhiteSpace(), x => x.Code.Contains(input.Code))
            .WhereIf(input.Status != null, x => x.Status == input.Status)
            ;
    }
}
