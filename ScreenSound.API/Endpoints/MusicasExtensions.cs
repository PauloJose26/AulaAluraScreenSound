using Microsoft.AspNetCore.Mvc;
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
            {
                return Results.NotFound();
            }

            return Results.Ok(musicaRecuperada);
        });

        app.MapPost("/musicas", ([FromServices] DAL<Musica> dal, [FromBody] Musica musica) =>
        {
            dal.Adicionar(musica);

            return Results.Created();
        });

        app.MapPut("/musicas", ([FromServices] DAL<Musica> dal, [FromBody] Musica musicaAtualizar) =>
        {
            var musicaRecuperada = dal.RecuperarPor(m => m.Id.Equals(musicaAtualizar.Id));
            if (musicaRecuperada is null)
            {
                return Results.NotFound();
            }

            musicaRecuperada.Nome = musicaAtualizar.Nome;
            musicaRecuperada.AnoLancamento = musicaAtualizar.AnoLancamento is not null ? musicaAtualizar.AnoLancamento : musicaRecuperada.AnoLancamento;
            dal.Atualizar(musicaRecuperada);

            return Results.Ok(musicaRecuperada);
        });

        app.MapDelete("/musicas/{id}", ([FromServices] DAL<Musica> dal, int id) =>
        {
            var musicaRecuperada = dal.RecuperarPor(m => m.Id.Equals(id));
            if (musicaRecuperada is null)
            {
                return Results.NotFound();
            }

            dal.Deletar(musicaRecuperada);
            return Results.NoContent();
        });
    }
}
