using System.Threading.Tasks;
using HotChocolate;

namespace GraphQLAuthDemo
{
    public class Mutation
    {
        public Task<string> GetToken(string email, string password, [Service] IIdentityService identityService) =>
            identityService.Authenticate(email, password);
    }
}