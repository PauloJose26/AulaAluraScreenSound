using ScreenSound.Modelo;

namespace ScreenSound.Menu;

internal class MenuRegistrarMusica: Menu
{
    public override void Executar(List<Artista> artistas)
    {
        base.Executar(artistas);
        this.ExibirTituloDaOpcao("Registro de Músicas");

        var artista = BuscarArtista(artistas);
        if (artista is null)
        {
            return;
        }

        Console.Write("Digite o nome da música: ");
        string nome = Console.ReadLine()!;
        var musica = new Musica(nome);
        artista.AdionarMusica(musica);

        Console.WriteLine("\nMusica Cadastrado\n");
        Console.WriteLine(musica);

        Console.Write("\nDigite qualquer tecla para sair");
        Console.ReadKey();
        Console.Clear();
    }
}
