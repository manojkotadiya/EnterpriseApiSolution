namespace EnterpriseApi.Application.Common
{
    public static class AuthorizationPolicies
    {
        public const string AdminOnly =
            "AdminOnly";

        public const string ManagerOnly =
            "ManagerOnly";

        public const string AdminOrManager =
            "AdminOrManager";

        public const string AuthenticatedUser =
            "AuthenticatedUser";
    }
}