using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using DevExtreme.AspNet.Data.ResponseModel;
using Volo.Abp.ObjectMapping;
using DevExtreme.AspNet.Data;
using AutoMapper.QueryableExtensions;
using CBO.Permissions;
using Newtonsoft.Json;

namespace CBO.InterestBankLendingRates
{
    [RemoteService(IsEnabled = false)]
    [Authorize(CBOPermissions.InterestBankLendingRates.Default)]
    public abstract class InterestBankLendingRatesAppServiceBase : CBOAppService
    {

        protected IInterestBankLendingRateRepository _interestBankLendingRateRepository;
        protected InterestBankLendingRateManager _interestBankLendingRateManager;

        public InterestBankLendingRatesAppServiceBase(IInterestBankLendingRateRepository interestBankLendingRateRepository, InterestBankLendingRateManager interestBankLendingRateManager)
        {

            _interestBankLendingRateRepository = interestBankLendingRateRepository;
            _interestBankLendingRateManager = interestBankLendingRateManager;
        }


        public async Task<List<InterestBankLendingRateDto>> GetListAsync()
        {
            var source = await _interestBankLendingRateRepository.GetQueryableAsync();
            return ObjectMapper.Map<List< InterestBankLendingRate> ,List<InterestBankLendingRateDto>>( source.ToList());
        }
        public async Task<LoadResult> GetListAsync(DataSourceLoadOptions loadOptions)
        {
            var config = ObjectMapper.AutoObjectMappingProvider.GetMapper().ConfigurationProvider;
            var source = await _interestBankLendingRateRepository.GetQueryableAsync();
            var result = await DataSourceLoader.LoadAsync(source.ProjectTo<InterestBankLendingRateDto>(config), loadOptions);
            return result;
        }



        public virtual async Task<InterestBankLendingRateDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<InterestBankLendingRate, InterestBankLendingRateDto>(await _interestBankLendingRateRepository.GetAsync(id));
        }



        [Authorize(CBOPermissions.InterestBankLendingRates.Create)]
        public async Task<InterestBankLendingRateDto> CreateAsync(object input)
        {
            var interestBankLendingRateDto = new InterestBankLendingRateDto();
            JsonConvert.PopulateObject(input.ToString(), interestBankLendingRateDto);
            var interestBankLendingRate = await _interestBankLendingRateManager.CreateAsync(
           interestBankLendingRateDto.EndOfPeriod, interestBankLendingRateDto.AmountInRO, interestBankLendingRateDto.InterestRate
           );
            return ObjectMapper.Map<InterestBankLendingRate, InterestBankLendingRateDto>(interestBankLendingRate);

        }

        [Authorize(CBOPermissions.InterestBankLendingRates.Edit)]
        public async Task<InterestBankLendingRateDto> UpdateAsync(Guid id, object input)
        {
            var interestBankLendingRate = await _interestBankLendingRateRepository.GetAsync(id);
            JsonConvert.PopulateObject(input.ToString(), interestBankLendingRate);
            interestBankLendingRate = await _interestBankLendingRateRepository.UpdateAsync(interestBankLendingRate);
            return ObjectMapper.Map<InterestBankLendingRate, InterestBankLendingRateDto>(interestBankLendingRate);
        }
        [Authorize(CBOPermissions.InterestBankLendingRates.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _interestBankLendingRateRepository.DeleteAsync(id);
        }
    }
}