namespace Restaurants.Infrastructure.Authorization
{
    public static class PolicyNames
    {
        public const string HasNationality = "Nationality";
        public const string AtLeast20 = "AtLeast20";
    }

    public static class AppClaimNames
    {
        public const string Nationality = "Nationality";
        public const string DateOfBirth = "DateOfBirth";
    }
}
