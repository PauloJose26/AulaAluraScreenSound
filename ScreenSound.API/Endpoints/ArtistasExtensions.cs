using Microsoft.AspNetCore.Mvc;
using ScreenSound.API.Requests;
using ScreenSound.API.Response;
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
                return Results.NotFound();

            return Results.Ok(artista);
        });

        app.MapPost("/artistas", ([FromServices] DAL<Artista> dal, [FromBody] ArtistaRequest artistaRequest) => {
            var artista = new Artista(artistaRequest.nome, artistaRequest.bio);
            dal.Adicionar(artista);

            return Results.Created();
        });

        app.MapPut("/artistas", ([FromServices] DAL<Artista> dal, [FromBody] ArtistaRequestEdit artistaRequestEdit) =>
        {
            var artistaRecuperado = dal.RecuperarPor(a => a.Id.Equals(artistaRequestEdit.id));
            if (artistaRecuperado is null)
                return Results.NotFound();

            if(artistaRequestEdit.nome is not null)
                artistaRecuperado.Nome = artistaRequestEdit.nome;
            if(artistaRequestEdit.bio is not null)
                artistaRecuperado.Bio = artistaRequestEdit.bio;
            dal.Atualizar(artistaRecuperado);

            return Results.Ok(artistaRecuperado);
        });

        app.MapDelete("/artistas/{id}", ([FromServices] DAL<Artista> dal, int id) => {
            var artista = dal.RecuperarPor(a => a.Id.Equals(id));
            if (artista is null)
                return Results.NotFound();

            dal.Deletar(artista);
            return Results.NoContent();
        });
    }

    private static ArtistaResponse EntityToResponse(Artista artista)
    {
        return new ArtistaResponse(artista.Id, artista.Nome, artista.Bio, artista.FotoPerfil);
    }

    private static ICollection<ArtistaResponse> EntityListToResponseList(IEnumerable<Artista> listaDeArtistas)
    {
        return listaDeArtistas.Select(a => EntityToResponse(a)).ToList();
    }
}
