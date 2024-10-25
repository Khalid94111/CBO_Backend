using Asp.Versioning;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using CBO.Controllers.InterestBankLendingRates;
using CBO.InterestBankLendingRates;
using System.Collections.Generic;
using DevExtreme.AspNet.Data.ResponseModel;

namespace CBO.Controllers.InterestBankLendingRates
{
    [RemoteService]
    [Area("app")]
    [ControllerName("InterestBankLendingRate")]
    [Route("api/app/interest-bank-lending-rates")]

    public class InterestBankLendingRateController : InterestBankLendingRateControllerBase
    {
        public InterestBankLendingRateController(IInterestBankLendingRatesAppService interestBankLendingRatesAppService) : base(interestBankLendingRatesAppService)
        {
        }

     
    }
}