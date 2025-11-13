using ScreenSound.Banco;

namespace ScreenSound.Menu;

internal class MenuMostrarMusicas: Menu
{
    public override void Executar(ArtistaDAL artistaDAL)
    {
        base.Executar(artistaDAL);
        this.ExibirTituloDaOpcao("Exibir detalhes de um artista");

        Console.Write("\nDigite o nome do artista: ");
        var nome = Console.ReadLine()!;
        Console.Clear();

        var artista = artistaDAL.BuscarPorNome(nome);
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