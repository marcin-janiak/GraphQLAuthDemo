using System;
using System.Collections.Generic;
using HotChocolate;

namespace GraphQLAuthDemo
{
    public class CurrentUser
    {
        public Guid UserId { get; }
        public List<string> Claims { get; }

        public CurrentUser(Guid userId, List<string> claims)
        {
            UserId = userId;
            Claims = claims;
        }
    }

    public class AuthorizedGlobalState : GlobalStateAttribute
    {
        public AuthorizedGlobalState() : base("currentUser")
        {
        }
    }
}