using Microsoft.AspNetCore.Authorization;

namespace ACADEMY.APPLICATION.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class HasPermissionAttribute : AuthorizeAttribute
    {
        const string POLICY_PREFIX = "HasPermission";

        public HasPermissionAttribute(params string[] permission)
        {
            Permission = string.Join(",", permission);
        }

        public string Permission
        {
            get
            {
                return Policy.Substring(POLICY_PREFIX.Length);
            }
            set
            {
                Policy = $"{POLICY_PREFIX}{value}";
            }
        }
    }
}