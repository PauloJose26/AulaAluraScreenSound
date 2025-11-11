using ScreenSound.Modelo;

namespace ScreenSound.Menu;

internal class MenuSair: Menu
{
    public override void Executar(List<Artista> artistas)
    {
        base.Executar(artistas);
        Console.WriteLine("\nAté Breve!!");
    }
}
