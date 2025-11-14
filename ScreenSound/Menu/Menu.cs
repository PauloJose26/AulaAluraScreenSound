using ScreenSound.Banco;
using ScreenSound.Shared.Modelo;

namespace ScreenSound.Menu;

internal class Menu
{
    public void ExibirTituloDaOpcao(string titulo)
    {
        Console.WriteLine(new string('*', titulo.Length));
        Console.WriteLine(titulo);
        Console.WriteLine(new string('*', titulo.Length));
    }

    public virtual void Executar(DAL<Artista> artistaDAL, DAL<Musica> musicaDAL) => Console.Clear();

    public void Continuar()
    {
        Console.Write("\nDigite qualquer tecla para sair");
        Console.ReadKey();
        Console.Clear();
    }

    public bool BuscarArtista(DAL<Artista> artistaDAL, out Artista artista)
    {
        Console.Write("\nDigite o nome do artista: ");
        var nome = Console.ReadLine()!;
        Console.Clear();

        artista = artistaDAL.RecuperarPor(art => art.Nome.Equals(nome))!;
        if (artista is null)
        {
            Console.WriteLine($"\nArtista com o nome {nome} não foi encontrado");
            this.Continuar();
            return false;
        }

        return true;
    }
}
