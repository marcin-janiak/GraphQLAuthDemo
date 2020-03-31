using System.Collections.Generic;
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
        public List<string> AuthorizedBetterWay([GlobalState("currentUser")] CurrentUser user)
        {
            return user.Claims;
        }


        [Authorize(Roles = new[] {"leader"})]
        public List<string> AuthenticatedLeader([GlobalState("currentUser")] CurrentUser user)
        {
            return user.Claims;
        }

        [Authorize(Roles = new[] {"dev"})]
        public List<string> AuthenticatedDev([GlobalState("currentUser")] CurrentUser user)
        {
            return user.Claims;
        }

        [Authorize(Policy = "DevDepartment")]
        public List<string> AuthenticatedDevDepartment([GlobalState("currentUser")] CurrentUser user)
        {
            return user.Claims;
        }
    }
}