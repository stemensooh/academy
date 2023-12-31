﻿using Microsoft.AspNetCore.Authorization;

namespace ACADEMY.APPLICATION.Authorization
{
    public class HasPermissionRequirement : IAuthorizationRequirement
    {
        public HasPermissionRequirement(string permission) { Permission = permission; }

        public string Permission { get; set; }
    }
}