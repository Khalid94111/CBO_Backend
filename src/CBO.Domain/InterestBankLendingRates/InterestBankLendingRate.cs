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
    public abstract class InterestBankLendingRateBase : FullAuditedEntity<Guid>, IHasConcurrencyStamp
    {
        public virtual DateTime EndOfPeriod { get; set; }

        public virtual decimal AmountInRO { get; set; }

        public virtual decimal InterestRate { get; set; }

        public string ConcurrencyStamp { get; set; }

        protected InterestBankLendingRateBase()
        {

        }

        public InterestBankLendingRateBase(Guid id, DateTime endOfPeriod, decimal amountInRO, decimal interestRate)
        {
            ConcurrencyStamp = Guid.NewGuid().ToString("N");
            Id = id;
            if (interestRate < InterestBankLendingRateConsts.InterestRateMinLength)
            {
                throw new ArgumentOutOfRangeException(nameof(interestRate), interestRate, "The value of 'interestRate' cannot be lower than " + InterestBankLendingRateConsts.InterestRateMinLength);
            }

            if (interestRate > InterestBankLendingRateConsts.InterestRateMaxLength)
            {
                throw new ArgumentOutOfRangeException(nameof(interestRate), interestRate, "The value of 'interestRate' cannot be greater than " + InterestBankLendingRateConsts.InterestRateMaxLength);
            }

            EndOfPeriod = endOfPeriod;
            AmountInRO = amountInRO;
            InterestRate = interestRate;
        }

    }
}