using ScreenSound.Banco;
using ScreenSound.Modelo;

namespace ScreenSound.Menu;

internal class MenuRegistrarMusica: Menu
{
    public override void Executar(ArtistaDAL artistaDAL)
    {
        base.Executar(artistaDAL);
        this.ExibirTituloDaOpcao("Registro de Músicas");

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

        Console.Write("\nDigite o nome da música: ");
        string nomeMusica = Console.ReadLine()!;
        var musica = new Musica(nomeMusica);
        artista.AdionarMusica(musica);

        Console.WriteLine("\nMusica Cadastrada\n");
        Console.WriteLine(musica);

        this.Continuar();
    }
}