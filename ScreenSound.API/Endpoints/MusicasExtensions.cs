using Microsoft.AspNetCore.Mvc;
using ScreenSound.API.Requests;
using ScreenSound.API.Response;
using ScreenSound.Shared.Banco;
using ScreenSound.Shared.Modelo;

namespace ScreenSound.API.Endpoints;

public static class MusicasExtensions
{
    public static void AddEndpointsMusicas(this WebApplication app)
    {
        app.MapGet("/musicas", ([FromServices] DAL<Musica> dal) =>
        {
            return Results.Ok(dal.Listar());
        });

        app.MapGet("/musicas/{nome}", ([FromServices] DAL<Musica> dal, string nome) =>
        {
            var musicaRecuperada = dal.RecuperarPor(musica => musica.Nome.ToUpper().Equals(nome.ToUpper()));
            if (musicaRecuperada is null)
                return Results.NotFound();

            return Results.Ok(musicaRecuperada);
        });

        app.MapPost("/musicas", ([FromServices] DAL<Musica> dalMusica, [FromServices] DAL<Artista> dalArtista, [FromBody] MusicaRequest musicaRequest) =>
        {
            var artista = dalArtista.RecuperarPor(art => art.Id.Equals(musicaRequest.artistaId));
            if (artista is null)
                return Results.NotFound("Artista não encontrado");

            var musica = new Musica(musicaRequest.nome, musicaRequest.anoLancamento) { Artista = artista };
            dalMusica.Adicionar(musica);

            return Results.Created();
        });

        app.MapPut("/musicas", ([FromServices] DAL<Musica> dalMusica, [FromServices] DAL<Artista> dalArtista, [FromBody] MusicaRequestEdit musicaRequestEdit) =>
        {
            var musicaRecuperada = dalMusica.RecuperarPor(m => m.Id.Equals(musicaRequestEdit.id));
            var artistaRecuperada = dalArtista.RecuperarPor(a => a.Id.Equals(musicaRequestEdit.artistaId));
            if (musicaRecuperada is null)
                return Results.NotFound();

            if (artistaRecuperada is not null)
                musicaRecuperada.Artista = artistaRecuperada;
            if(musicaRequestEdit.nome is not null)
                musicaRecuperada.Nome = musicaRequestEdit.nome;
            musicaRecuperada.AnoLancamento = musicaRequestEdit.anoLancamento;
            dalMusica.Atualizar(musicaRecuperada);

            return Results.Ok(musicaRecuperada);
        });

        app.MapDelete("/musicas/{id}", ([FromServices] DAL<Musica> dal, int id) =>
        {
            var musicaRecuperada = dal.RecuperarPor(m => m.Id.Equals(id));
            if (musicaRecuperada is null)
                return Results.NotFound();

            dal.Deletar(musicaRecuperada);
            return Results.NoContent();
        });
    }
    private static MusicaResponse EntityToResponse(Musica musica)
    {
        return new MusicaResponse(musica.Id, musica.Nome, musica.AnoLancamento, musica.Artista!.Id, musica.Artista.Nome);
    }

    private static ICollection<MusicaResponse> EntityListToResponseList(IEnumerable<Musica> musicaList)
    {
        return musicaList.Select(a => EntityToResponse(a)).ToList();
    }
}
