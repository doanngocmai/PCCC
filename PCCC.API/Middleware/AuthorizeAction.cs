﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PCCC.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCCC.API.Middleware
{
    public class AuthorizeAction : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var authCode = (int?)context.HttpContext.Items["AuthCode"];
            if (authCode == PCCCConsts.TOKEN_INVALID)
            {
                context.Result = new JsonResult(JsonResponse.Error(PCCCConsts.TOKEN_INVALID, PCCCConsts.MESSAGE_TOKEN_INVALID))
                { };
            }
            else if (authCode == PCCCConsts.TOKEN_ERROR)
            {
                context.Result = new JsonResult(JsonResponse.Error(PCCCConsts.TOKEN_ERROR, PCCCConsts.MESSAGE_TOKEN_ERROR))
                { };
            }
        }
    }
}
