using ScreenSound.Modelo;

namespace ScreenSound.Menu;

internal class MenuMostrarArtistas: Menu
{
    public override void Executar(List<Artista> artistas)
    {
        base.Executar(artistas);
        this.ExibirTituloDaOpcao("Lista de Artistas");

        foreach(var artista in artistas) {
            Console.WriteLine(artista);
        }

        Console.Write("\nDigite qualquer tecla para sair");
        Console.ReadKey();
        Console.Clear();
    }
}
