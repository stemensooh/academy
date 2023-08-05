using Microsoft.AspNetCore.Authorization;

namespace ACADEMY.APPLICATION.Authorization
{
    public class HasPermissionProvider : IAuthorizationPolicyProvider
    {
        const string POLICY_PREFIX = "HasPermission";
        private readonly string _tokenScheme;

        public HasPermissionProvider(string tokenScheme)
        {
            _tokenScheme = tokenScheme;
        }

        public Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
        {
            if (policyName.StartsWith(POLICY_PREFIX, StringComparison.OrdinalIgnoreCase))
            {
                var permission = policyName[POLICY_PREFIX.Length..];
                var policy = new AuthorizationPolicyBuilder(_tokenScheme);
                policy.AddRequirements(new HasPermissionRequirement(permission));
                return Task.FromResult(policy.Build());
            }
            return Task.FromResult<AuthorizationPolicy>(null);
        }

        public Task<AuthorizationPolicy> GetDefaultPolicyAsync()
        {
            var policy = new AuthorizationPolicyBuilder(_tokenScheme).RequireAuthenticatedUser();
            return Task.FromResult(policy.Build());
        }

        public Task<AuthorizationPolicy> GetFallbackPolicyAsync() => Task.FromResult<AuthorizationPolicy>(null);
    }
}