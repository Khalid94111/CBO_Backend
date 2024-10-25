using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace CBO.InterestBankLendingRates
{
    public abstract class InterestBankLendingRateManagerBase : DomainService
    {
        protected IInterestBankLendingRateRepository _interestBankLendingRateRepository;

        public InterestBankLendingRateManagerBase(IInterestBankLendingRateRepository interestBankLendingRateRepository)
        {
            _interestBankLendingRateRepository = interestBankLendingRateRepository;
        }

        public virtual async Task<InterestBankLendingRate> CreateAsync(
        DateTime endOfPeriod, decimal amountInRO, decimal interestRate)
        {
            Check.NotNull(endOfPeriod, nameof(endOfPeriod));
            Check.Range(interestRate, nameof(interestRate), InterestBankLendingRateConsts.InterestRateMinLength, InterestBankLendingRateConsts.InterestRateMaxLength);

            var interestBankLendingRate = new InterestBankLendingRate(
             GuidGenerator.Create(),
             endOfPeriod, amountInRO, interestRate
             );

            return await _interestBankLendingRateRepository.InsertAsync(interestBankLendingRate);
        }

        public virtual async Task<InterestBankLendingRate> UpdateAsync(
            Guid id,
            DateTime endOfPeriod, decimal amountInRO, decimal interestRate, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNull(endOfPeriod, nameof(endOfPeriod));
            Check.Range(interestRate, nameof(interestRate), InterestBankLendingRateConsts.InterestRateMinLength, InterestBankLendingRateConsts.InterestRateMaxLength);

            var interestBankLendingRate = await _interestBankLendingRateRepository.GetAsync(id);

            interestBankLendingRate.EndOfPeriod = endOfPeriod;
            interestBankLendingRate.AmountInRO = amountInRO;
            interestBankLendingRate.InterestRate = interestRate;

            interestBankLendingRate.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _interestBankLendingRateRepository.UpdateAsync(interestBankLendingRate);
        }

    }
}