using DevExtreme.AspNet.Data.ResponseModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace CBO.InterestBankLendingRates
{
    public partial interface IInterestBankLendingRatesAppService : IApplicationService
    {

        Task<List<InterestBankLendingRateDto>> GetListAsync();

        Task<LoadResult> GetListAsync(DataSourceLoadOptions input);

        Task<InterestBankLendingRateDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<InterestBankLendingRateDto> CreateAsync(object input);

        Task<InterestBankLendingRateDto> UpdateAsync(Guid id, object input);
    }
}