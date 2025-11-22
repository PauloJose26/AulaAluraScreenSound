using Microsoft.AspNetCore.Mvc;
using ScreenSound.Shared.Banco;
using ScreenSound.Shared.Modelo;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ScreenSoundContext>();
builder.Services.AddTransient<DAL<Artista>>();
builder.Services.AddTransient<DAL<Musica>>();

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
var app = builder.Build();

app.MapGet("/artistas", ([FromServices] DAL<Artista> dal) =>
{
    return Results.Ok(dal.Listar());
});

app.MapGet("/artistas/{nome}", ([FromServices] DAL<Artista> dal, string nome) =>
{
    var artista = dal.RecuperarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));
    if(artista is null)
    {
        return Results.NotFound();
    }

    return Results.Ok(artista);
});

app.MapPost("/artistas", ([FromServices] DAL<Artista> dal, [FromBody]Artista artista) => {
    artista.FotoPerfil = "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png";
    dal.Adicionar(artista);

    return Results.Created();
});

app.MapPut("/artistas", ([FromServices] DAL<Artista> dal, [FromBody] Artista artistaAtualizar) =>
{
    var artistaRecuperado = dal.RecuperarPor(a => a.Id.Equals(artistaAtualizar.Id));
    if(artistaRecuperado is null)
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
    if(artista is null)
    {
        return Results.NotFound();
    }

    dal.Deletar(artista);
    return Results.NoContent();
});

app.MapGet("/musicas", ([FromServices] DAL<Musica> dal) =>
{
    return Results.Ok(dal.Listar());
});

app.MapGet("/musicas/{nome}", ([FromServices] DAL<Musica> dal, string nome) =>
{
    var musicaRecuperada = dal.RecuperarPor(musica => musica.Nome.ToUpper().Equals(nome.ToUpper()));
    if(musicaRecuperada is null)
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
    if(musicaRecuperada is null)
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

app.Run();
