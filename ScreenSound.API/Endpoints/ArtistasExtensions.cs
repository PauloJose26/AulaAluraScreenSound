using Microsoft.AspNetCore.Mvc;
using ScreenSound.Shared.Banco;
using ScreenSound.Shared.Modelo;

namespace ScreenSound.API.Endpoints;

public static class ArtistasExtensions
{
    public static void AddEndpointsArtistas(this WebApplication app)
    {
        app.MapGet("/artistas", ([FromServices] DAL<Artista> dal) =>
        {
            return Results.Ok(dal.Listar());
        });

        app.MapGet("/artistas/{nome}", ([FromServices] DAL<Artista> dal, string nome) =>
        {
            var artista = dal.RecuperarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));
            if (artista is null)
            {
                return Results.NotFound();
            }

            return Results.Ok(artista);
        });

        app.MapPost("/artistas", ([FromServices] DAL<Artista> dal, [FromBody] Artista artista) => {
            artista.FotoPerfil = "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png";
            dal.Adicionar(artista);

            return Results.Created();
        });

        app.MapPut("/artistas", ([FromServices] DAL<Artista> dal, [FromBody] Artista artistaAtualizar) =>
        {
            var artistaRecuperado = dal.RecuperarPor(a => a.Id.Equals(artistaAtualizar.Id));
            if (artistaRecuperado is null)
            {
                return Results.NotFound();
            }

            artistaRecuperado.Nome = artistaAtualizar.Nome;
            artistaRecuperado.Bio = artistaAtualizar.Bio;
            artistaRecuperado.FotoPerfil = artistaAtualizar.FotoPerfil;
            dal.Atualizar(artistaRecuperado);

            return Results.Ok(artistaRecuperado);
        });

        app.MapDelete("/artistas/{id}", ([FromServices] DAL<Artista> dal, int id) => {
            var artista = dal.RecuperarPor(a => a.Id.Equals(id));
            if (artista is null)
            {
                return Results.NotFound();
            }

            dal.Deletar(artista);
            return Results.NoContent();
        });
    }
}
