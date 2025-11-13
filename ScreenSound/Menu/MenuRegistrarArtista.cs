using ScreenSound.Banco;
using ScreenSound.Modelo;

namespace ScreenSound.Menu;

internal class MenuRegistrarArtista: Menu
{
    public override void Executar(DAL<Artista> artistaDAL)
    {
        base.Executar(artistaDAL);
        this.ExibirTituloDaOpcao("Registro de artistas");

        Console.Write("\nDigite o nome do artista: ");
        var nome = Console.ReadLine()!;
        Console.Write("Digite a Bio do artista: ");
        var bio = Console.ReadLine()!;
        var artista = new Artista(nome, bio);
        artistaDAL.Adicionar(artista);

        Console.WriteLine("\nArtista Cadastrado\n");
        Console.WriteLine(artista);

        this.Continuar();
    }
}