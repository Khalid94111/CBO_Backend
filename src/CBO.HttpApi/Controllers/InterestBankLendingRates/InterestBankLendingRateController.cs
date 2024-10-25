using Asp.Versioning;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using CBO.InterestBankLendingRates;
using CBO;
using DevExtreme.AspNet.Data.ResponseModel;

namespace  CBO.Controllers.InterestBankLendingRates
{
    /// <summary>
    /// Manages Interest Bank Lending Rate operations.
    /// </summary>
    [RemoteService]
    [Area("app")]
    [ControllerName("InterestBankLendingRate")]
    [Route("api/app/interest-bank-lending-rates")]
    [ApiVersion("1.0")]

    public abstract class InterestBankLendingRateControllerBase : AbpController
    {
        protected IInterestBankLendingRatesAppService _interestBankLendingRatesAppService;

        public InterestBankLendingRateControllerBase(IInterestBankLendingRatesAppService interestBankLendingRatesAppService)
        {
            _interestBankLendingRatesAppService = interestBankLendingRatesAppService;
        }

        /// <summary>
        /// Retrieves all interest bank lending rate (Version 1.0).
        /// </summary>
        /// <remarks>
        /// This version provides the basic lending rate data.
        /// </remarks>
        /// <returns>
        /// Common Status Codes:
        /// - 200 OK: Lending rate retrieved successfully.
        /// - 404 Not Found: Lending rate not available.
        /// </returns>
        /// <example>GET /interest-bank-lending-rate?api-version=1.0</example>
        //[HttpGet]
        //public virtual Task<List<InterestBankLendingRateDto>> GetListAsync()
        //{
        //    return _interestBankLendingRatesAppService.GetListAsync();
        //}

        /// <summary>
        /// Retrieves all interest bank lending rate with parameters  (Version 2.0).
        /// </summary>
        /// <remarks>
        /// This version includes filtering, pagination, and sorting about the lending rate.
        /// It supports filtering, pagination, and sorting.
        /// </remarks>
        /// <param name="dataSourceLoadOptions"></param>
        /// <returns>
        /// Common Status Codes:
        /// - 200 OK: Lending rate retrieved successfully.
        /// - 404 Not Found: Lending rate not available.
        /// </returns>
        /// <example>GET /interest-bank-lending-rate/{id}</example>
        [HttpGet]
        public virtual Task<LoadResult> GetListAsync(DataSourceLoadOptions dataSourceLoadOptions)
        {
            return _interestBankLendingRatesAppService.GetListAsync(dataSourceLoadOptions);
        }


        /// <summary>
        /// Retrieves the current interest bank lending rate.
        /// </summary>
        /// <remarks>
        /// Use this method to get the latest lending rate for banks.
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>
        /// Common Status Codes:
        /// - 200 OK: Lending rate retrieved successfully.
        /// - 404 Not Found: Lending rate not available.
        /// </returns>
        /// <example>GET /interest-bank-lending-rate/{id}</example>
        [HttpGet]
        [Route("{id}")]
        public virtual Task<InterestBankLendingRateDto> GetAsync(Guid id)
        {
            return _interestBankLendingRatesAppService.GetAsync(id);
        }

        /// <summary>
        /// Submits data to the server to create a new interest bank lending rate.
        /// </summary>
        /// <remarks>
        /// Use this method to create new entries in the system.
        /// </remarks>
        /// <returns>
        /// Common Status Codes:
        /// - 201 Created: Resource created successfully.
        /// - 400 Bad Request: Invalid data.
        /// </returns>
        /// <example>POST /interest-bank-lending-rate</example>
        [HttpPost]
        public virtual Task<InterestBankLendingRateDto> CreateAsync(object input)
        {
            return _interestBankLendingRatesAppService.CreateAsync(input);
        }

        /// <summary>
        /// Updates an existing interest bank lending rate by replacing it with new data.
        /// </summary>
        /// <remarks>
        /// Use this method for full updates to an existing interest bank lending rate.
        /// </remarks>
        /// <returns>
        /// Common Status Codes:
        /// - 200 OK or 204 No Content: Resource updated successfully.
        /// - 404 Not Found: Resource not found.
        /// </returns>
        /// <example>PUT /interest-bank-lending-rate/{id}</example>
        [HttpPut]
        [Route("{id}")]
        public virtual Task<InterestBankLendingRateDto> UpdateAsync(Guid id, object input)
        {
            return _interestBankLendingRatesAppService.UpdateAsync(id, input);
        }

    
        /// <summary>
        /// Deletes  interest bank lending rate from the server.
        /// </summary>
        /// <remarks>
        /// Use this method to remove entries from the system.
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>
        /// Common Status Codes:
        /// - 204 No Content: Resource deleted successfully.
        /// - 404 Not Found: Resource not found.
        /// </returns>
        /// <example>DELETE api/app/interest-bank-lending-rate/{id}</example>
        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _interestBankLendingRatesAppService.DeleteAsync(id);
        }
    }
}