using System;
using System.Linq;
using System.Threading.Tasks;
using Fast.Template.Basic.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Fast.Template.Basic.Dics;

public class DicinfoRepository : EfCoreRepository<IBasicDbContext, Dicinfo, Guid>, IDicinfoRepository
{
    public DicinfoRepository(IDbContextProvider<IBasicDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<Dicinfo>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}