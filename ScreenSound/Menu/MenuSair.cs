using ScreenSound.Banco;
using ScreenSound.Shared.Modelo;

namespace ScreenSound.Menu;

internal class MenuSair: Menu
{
    public override void Executar(DAL<Artista> artistaDAL, DAL<Musica> musicaDAL)
    {
        base.Executar(artistaDAL, musicaDAL);
        Console.WriteLine("\nAté Breve!!");
    }
}
