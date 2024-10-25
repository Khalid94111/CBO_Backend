using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace CBO.InterestBankLendingRates
{
    public abstract class InterestBankLendingRatesAppServiceTests<TStartupModule> : CBOApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly IInterestBankLendingRatesAppService _interestBankLendingRatesAppService;
        private readonly IRepository<InterestBankLendingRate, Guid> _interestBankLendingRateRepository;

        public InterestBankLendingRatesAppServiceTests()
        {
            _interestBankLendingRatesAppService = GetRequiredService<IInterestBankLendingRatesAppService>();
            _interestBankLendingRateRepository = GetRequiredService<IRepository<InterestBankLendingRate, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _interestBankLendingRatesAppService.GetListAsync(new DataSourceLoadOptions());

            // Assert
            result.groupCount.ShouldBe(2);
            //result.Items.Count.ShouldBe(2);
            //result.Items.Any(x => x.Id == Guid.Parse("9158a832-b449-468f-a9b0-d659f9577b5c")).ShouldBe(true);
            //result.Items.Any(x => x.Id == Guid.Parse("bbef5d75-ed46-4887-a5a1-911e874f1bf8")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _interestBankLendingRatesAppService.GetAsync(Guid.Parse("9158a832-b449-468f-a9b0-d659f9577b5c"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("9158a832-b449-468f-a9b0-d659f9577b5c"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new InterestBankLendingRateDto
            {
                EndOfPeriod = new DateTime(2003, 10, 21),
                AmountInRO = 882005649,
                InterestRate = 22
            };

            // Act
            var serviceResult = await _interestBankLendingRatesAppService.CreateAsync(input);

            // Assert
            var result = await _interestBankLendingRateRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.EndOfPeriod.ShouldBe(new DateTime(2003, 10, 21));
            result.AmountInRO.ShouldBe(882005649);
            result.InterestRate.ShouldBe(22);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new InterestBankLendingRateDto()
            {
                EndOfPeriod = new DateTime(2002, 3, 16),
                AmountInRO = 987820214,
                InterestRate = 79
            };

            // Act
            var serviceResult = await _interestBankLendingRatesAppService.UpdateAsync(Guid.Parse("9158a832-b449-468f-a9b0-d659f9577b5c"), input);

            // Assert
            var result = await _interestBankLendingRateRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.EndOfPeriod.ShouldBe(new DateTime(2002, 3, 16));
            result.AmountInRO.ShouldBe(987820214);
            result.InterestRate.ShouldBe(79);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _interestBankLendingRatesAppService.DeleteAsync(Guid.Parse("9158a832-b449-468f-a9b0-d659f9577b5c"));

            // Assert
            var result = await _interestBankLendingRateRepository.FindAsync(c => c.Id == Guid.Parse("9158a832-b449-468f-a9b0-d659f9577b5c"));

            result.ShouldBeNull();
        }
    }
}