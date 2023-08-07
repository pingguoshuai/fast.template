using System;
using System.Linq;
using System.Threading.Tasks;
using Fast.Template.Basic.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Fast.Template.Basic.Dics;

public class DicTypeRepository : EfCoreRepository<IBasicDbContext, DicType, Guid>, IDicTypeRepository
{
    public DicTypeRepository(IDbContextProvider<IBasicDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<DicType>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}