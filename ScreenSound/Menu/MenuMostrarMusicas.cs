using ScreenSound.Modelo;

namespace ScreenSound.Menu;

internal class MenuMostrarMusicas: Menu
{
    public override void Executar(List<Artista> artistas)
    {
        base.Executar(artistas);
        this.ExibirTituloDaOpcao("Exibir detalhes de um artista");

        var artista = BuscarArtista(artistas);
        if (artista is null)
        {
            return;
        }

        artista.ExibirDiscografia();

        Console.Write("\nDigite qualquer tecla para sair");
        Console.ReadKey();
        Console.Clear();
    }
}
