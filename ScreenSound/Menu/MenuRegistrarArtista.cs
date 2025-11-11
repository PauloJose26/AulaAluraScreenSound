using ScreenSound.Modelo;

namespace ScreenSound.Menu;

internal class MenuRegistrarArtista: Menu
{
    public override void Executar(List<Artista> artistas)
    {
        base.Executar(artistas);
        this.ExibirTituloDaOpcao("Registro de artistas");

        Console.Write("\nDigite o nome do artista: ");
        var nome = Console.ReadLine()!;
        Console.Write("Digite a Bio do artista: ");
        var bio = Console.ReadLine()!;
        var artista = new Artista(nome, bio);
        artistas.Add(artista);

        Console.WriteLine("\nArtista Cadastrado\n");
        Console.WriteLine(artista);

        Console.Write("\nDigite qualquer tecla para sair");
        Console.ReadKey();
        Console.Clear();
    }
}
