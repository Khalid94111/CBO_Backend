using System;
using System.Collections.Generic;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace CBO.InterestBankLendingRates
{
    public  class InterestBankLendingRateDto : FullAuditedEntityDto<Guid>
    {
     
        public DateTime EndOfPeriod { get; set; }
        public decimal AmountInRO { get; set; }
        public decimal InterestRate { get; set; }

    

    }
}