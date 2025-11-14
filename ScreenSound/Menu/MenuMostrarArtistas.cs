using ScreenSound.Banco;
using ScreenSound.Modelo;

namespace ScreenSound.Menu;

internal class MenuMostrarArtistas: Menu
{
    public override void Executar(DAL<Artista> artistaDAL, DAL<Musica> musicaDAL)
    {
        base.Executar(artistaDAL, musicaDAL);
        this.ExibirTituloDaOpcao("Lista de Artistas");

        foreach(var artista in artistaDAL.Listar()) {
            Console.WriteLine(artista);
        }

        this.Continuar();
    }
}