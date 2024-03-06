using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCCC.API.Middleware
{
    public class AuthorizePermissionAttribute : TypeFilterAttribute
    {
        public AuthorizePermissionAttribute(int permission) : base(typeof(AuthorizePermissionAction))
        {
            Arguments = new object[] {
            permission
        };
        }
    }
}
