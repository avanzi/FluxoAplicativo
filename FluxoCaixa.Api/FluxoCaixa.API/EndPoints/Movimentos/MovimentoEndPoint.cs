using Microsoft.EntityFrameworkCore;
using FluxoCaixa.Data.Context;

using FluxoCaixa.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using FluxoCaixa.Domain.Interfaces;
using FluxoCaixa.Application.Interfaces;
using FluxoCaixa.Application.Services;
using Microsoft.AspNetCore.Authorization;
using FluxoCaixa.Domain.Entities.Filtros;

namespace FluxoCaixa.API.EndPoints.Movimentos
{
    public static class MovimentoEndPoint
    {

        public static void MapMovimentoEndPoint(this IEndpointRouteBuilder routes)
        {
            routes.MapGet("/api/movimentos",([FromHeader]string dia,IMovimentosService service, AppDbContext context) =>
            {

                return  service.GetSaldoDiario(DateTime.Parse(dia));


            })
           .WithName("GetSaldoDiario")
           .Produces<MovimentoDiario>(StatusCodes.Status200OK)
           .Produces(StatusCodes.Status204NoContent);

            routes.MapPut("/api/movimentos",(Movimento movimento, IMovimentosService service , AppDbContext context) =>
            {

                return service.Add(movimento);


          })
         .WithName("AddMovimento")
        .Produces<Movimento>(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);
        }

    }
}
