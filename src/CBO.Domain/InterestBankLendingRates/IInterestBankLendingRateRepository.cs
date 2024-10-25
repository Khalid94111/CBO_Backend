using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace CBO.InterestBankLendingRates
{
    public partial interface IInterestBankLendingRateRepository : IRepository<InterestBankLendingRate, Guid>
    {

        Task DeleteAllAsync(
            string? filterText = null,
            DateTime? endOfPeriodMin = null,
            DateTime? endOfPeriodMax = null,
            decimal? amountInROMin = null,
            decimal? amountInROMax = null,
            decimal? interestRateMin = null,
            decimal? interestRateMax = null,
            CancellationToken cancellationToken = default);
        Task<List<InterestBankLendingRate>> GetListAsync(
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
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string? filterText = null,
            DateTime? endOfPeriodMin = null,
            DateTime? endOfPeriodMax = null,
            decimal? amountInROMin = null,
            decimal? amountInROMax = null,
            decimal? interestRateMin = null,
            decimal? interestRateMax = null,
            CancellationToken cancellationToken = default);
    }
}