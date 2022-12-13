using FluxoCaixa.Application.Interfaces;
using FluxoCaixa.Data.Context;
using FluxoCaixa.Domain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace FluxoCaixa.API.EndPoints.Users
{
    public static class UserEndPoint
    {
        public static void MapUserEndPoint(this IEndpointRouteBuilder routes)
        {
            routes.MapGet("/api/User", [Authorize] (string Name, string Password,IUsersService service,AppDbContext context) =>
            {

                return service.GetUser(Name, Password);


            })
          .WithName("GetUser")
          .Produces<User>(StatusCodes.Status200OK);
        }


    }
}
