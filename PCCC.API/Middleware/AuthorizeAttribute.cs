using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace PCCC.API.Middleware
{
    public class AuthorizeAttribute : TypeFilterAttribute
    {

        public AuthorizeAttribute() : base(typeof(AuthorizeAction))
        {
            
        }
    }


}
