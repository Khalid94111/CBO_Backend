using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using CBO.InterestBankLendingRates;

namespace CBO.InterestBankLendingRates
{
    public class InterestBankLendingRatesDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IInterestBankLendingRateRepository _interestBankLendingRateRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public InterestBankLendingRatesDataSeedContributor(IInterestBankLendingRateRepository interestBankLendingRateRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _interestBankLendingRateRepository = interestBankLendingRateRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _interestBankLendingRateRepository.InsertAsync(new InterestBankLendingRate
            (
                id: Guid.Parse("9158a832-b449-468f-a9b0-d659f9577b5c"),
                endOfPeriod: new DateTime(2010, 11, 18),
                amountInRO: 426534002,
                interestRate: 70
            ));

            await _interestBankLendingRateRepository.InsertAsync(new InterestBankLendingRate
            (
                id: Guid.Parse("bbef5d75-ed46-4887-a5a1-911e874f1bf8"),
                endOfPeriod: new DateTime(2000, 9, 4),
                amountInRO: 980720938,
                interestRate: 26
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}