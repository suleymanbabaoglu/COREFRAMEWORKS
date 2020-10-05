﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using System;

namespace COREVUE.Helpers.Attributes
{
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        public MyAuthorizeAttribute()
        {
            AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme;
        }

    }
}
