namespace CBO.InterestBankLendingRates
{
    public static class InterestBankLendingRateConsts
    {
        private const string DefaultSorting = "{0}EndOfPeriod asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "InterestBankLendingRate." : string.Empty);
        }

        public const decimal InterestRateMinLength = 0;
        public const decimal InterestRateMaxLength = 100;
    }
}