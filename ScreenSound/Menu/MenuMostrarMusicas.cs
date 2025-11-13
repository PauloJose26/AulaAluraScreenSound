using ScreenSound.Banco;
using ScreenSound.Modelo;

namespace ScreenSound.Menu;

internal class MenuMostrarMusicas: Menu
{
    public override void Executar(DAL<Artista> artistaDAL)
    {
        base.Executar(artistaDAL);
        this.ExibirTituloDaOpcao("Exibir detalhes de um artista");

        Console.Write("\nDigite o nome do artista: ");
        var nome = Console.ReadLine()!;
        Console.Clear();

        var artista = artistaDAL.RecuperarPor(art => art.Nome.Equals(nome));
        if (artista is null)
        {
            Console.WriteLine($"\nArtista com o nome {nome} não foi encontrado");
            this.Continuar();
            return;
        }

        artista.ExibirDiscografia();
        this.Continuar();
    }
}