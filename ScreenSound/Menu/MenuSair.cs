using ScreenSound.Banco;
using ScreenSound.Modelo;

namespace ScreenSound.Menu;

internal class MenuSair: Menu
{
    public override void Executar(ArtistaDAL artistaDAL)
    {
        base.Executar(artistaDAL);
        Console.WriteLine("\nAté Breve!!");
    }
}
