using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities;

using Volo.Abp;

namespace CBO.InterestBankLendingRates
{
    public class InterestBankLendingRate : InterestBankLendingRateBase
    {
        //<suite-custom-code-autogenerated>
        protected InterestBankLendingRate()
        {

        }

        public InterestBankLendingRate(Guid id, DateTime endOfPeriod, decimal amountInRO, decimal interestRate)
            : base(id, endOfPeriod, amountInRO, interestRate)
        {
        }
        //</suite-custom-code-autogenerated>

        //Write your custom code...
    }
}