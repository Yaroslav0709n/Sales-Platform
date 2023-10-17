﻿using SalesPlatform_Application.Common.Exceptions;
using System.Security.Claims;

namespace SalesPlatform_Application.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static Guid GetCurrentUserId(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentNullException(nameof(principal));
            }
            var result = Guid.TryParse(
                principal.Claims
                    .FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier
                )?.Value, out var userId);
            if (!result)
            {
                throw new UserAccessDeniedExceptions(principal.ToString());
            }
            return userId;
        }
    }
}
