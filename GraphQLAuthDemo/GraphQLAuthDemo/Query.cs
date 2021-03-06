﻿using System.Collections.Generic;
using System.Linq;
using HotChocolate;
using HotChocolate.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace GraphQLAuthDemo
{
    public class Query
    {
        public string Unauthorized()
        {
            return "unauthorized";
        }

        [Authorize]
        public List<string> Authorized([Service] IHttpContextAccessor contextAccessor)
        {
            return contextAccessor.HttpContext.User.Claims.Select(x => $"{x.Type} : {x.Value}").ToList();
        }

        [Authorize]
        public List<string> AuthorizedBetterWay([CurrentUserGlobalState] CurrentUser user)
        {
            return user.Claims;
        }


        [Authorize(Roles = new[] {"leader"})]
        public List<string> AuthorizedLeader([CurrentUserGlobalState] CurrentUser user)
        {
            return user.Claims;
        }

        [Authorize(Roles = new[] {"dev"})]
        public List<string> AuthorizedDev([CurrentUserGlobalState] CurrentUser user)
        {
            return user.Claims;
        }

        [Authorize(Policy = "DevDepartment")]
        public List<string> AuthorizedDevDepartment([CurrentUserGlobalState] CurrentUser user)
        {
            return user.Claims;
        }
    }
}