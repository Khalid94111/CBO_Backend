using System;
using CBO.Shared;
using Volo.Abp.AutoMapper;
using CBO.InterestBankLendingRates;
using AutoMapper;

namespace CBO;

public class CBOApplicationAutoMapperProfile : Profile
{
    public CBOApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<InterestBankLendingRate, InterestBankLendingRateDto>();
     }
}