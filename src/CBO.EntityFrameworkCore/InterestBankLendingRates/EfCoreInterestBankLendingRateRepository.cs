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
    public abstract class EfCoreInterestBankLendingRateRepositoryBase : EfCoreRepository<CBODbContext, InterestBankLendingRate, Guid>
    {
        public EfCoreInterestBankLendingRateRepositoryBase(IDbContextProvider<CBODbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task DeleteAllAsync(
            string? filterText = null,
                        DateTime? endOfPeriodMin = null,
            DateTime? endOfPeriodMax = null,
            decimal? amountInROMin = null,
            decimal? amountInROMax = null,
            decimal? interestRateMin = null,
            decimal? interestRateMax = null,
            CancellationToken cancellationToken = default)
        {

            var query = await GetQueryableAsync();

            query = ApplyFilter(query, filterText, endOfPeriodMin, endOfPeriodMax, amountInROMin, amountInROMax, interestRateMin, interestRateMax);

            var ids = query.Select(x => x.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<InterestBankLendingRate>> GetListAsync(
            string? filterText = null,
            DateTime? endOfPeriodMin = null,
            DateTime? endOfPeriodMax = null,
            decimal? amountInROMin = null,
            decimal? amountInROMax = null,
            decimal? interestRateMin = null,
            decimal? interestRateMax = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, endOfPeriodMin, endOfPeriodMax, amountInROMin, amountInROMax, interestRateMin, interestRateMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? InterestBankLendingRateConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            DateTime? endOfPeriodMin = null,
            DateTime? endOfPeriodMax = null,
            decimal? amountInROMin = null,
            decimal? amountInROMax = null,
            decimal? interestRateMin = null,
            decimal? interestRateMax = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, endOfPeriodMin, endOfPeriodMax, amountInROMin, amountInROMax, interestRateMin, interestRateMax);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<InterestBankLendingRate> ApplyFilter(
            IQueryable<InterestBankLendingRate> query,
            string? filterText = null,
            DateTime? endOfPeriodMin = null,
            DateTime? endOfPeriodMax = null,
            decimal? amountInROMin = null,
            decimal? amountInROMax = null,
            decimal? interestRateMin = null,
            decimal? interestRateMax = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => true)
                    .WhereIf(endOfPeriodMin.HasValue, e => e.EndOfPeriod >= endOfPeriodMin!.Value)
                    .WhereIf(endOfPeriodMax.HasValue, e => e.EndOfPeriod <= endOfPeriodMax!.Value)
                    .WhereIf(amountInROMin.HasValue, e => e.AmountInRO >= amountInROMin!.Value)
                    .WhereIf(amountInROMax.HasValue, e => e.AmountInRO <= amountInROMax!.Value)
                    .WhereIf(interestRateMin.HasValue, e => e.InterestRate >= interestRateMin!.Value)
                    .WhereIf(interestRateMax.HasValue, e => e.InterestRate <= interestRateMax!.Value);
        }
    }
}