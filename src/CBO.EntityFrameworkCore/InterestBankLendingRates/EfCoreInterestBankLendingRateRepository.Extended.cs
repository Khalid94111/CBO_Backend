using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using CBO.EntityFrameworkCore;

namespace CBO.InterestBankLendingRates
{
    public class EfCoreInterestBankLendingRateRepository : EfCoreInterestBankLendingRateRepositoryBase, IInterestBankLendingRateRepository
    {
        public EfCoreInterestBankLendingRateRepository(IDbContextProvider<CBODbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}