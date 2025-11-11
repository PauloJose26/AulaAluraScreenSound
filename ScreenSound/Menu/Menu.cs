using ScreenSound.Modelo;

namespace ScreenSound.Menu;

internal class Menu
{
    public void ExibirTituloDaOpcao(string titulo)
    {
        Console.WriteLine(new string('*', titulo.Length));
        Console.WriteLine(titulo);
        Console.WriteLine(new string('*', titulo.Length));
    }

    public virtual void Executar(List<Artista> artistas) => Console.Clear();

    public Artista? BuscarArtista(List<Artista> artistas)
    {
        if (artistas.Count == 0)
        {
            Console.WriteLine("\nNão há artista cadastrados!");
            Console.Write("\nDigite qualquer tecla para sair");
            Console.ReadKey();
            Console.Clear();
            return null;
        }

        Console.WriteLine();
        for (int i = 0; i < artistas.Count; i++)
        {
            Console.WriteLine($"{i + 1}: {artistas[i].Nome}");
        }

        Console.Write("Escolha um artista: ");
        string opcaoArtista = Console.ReadLine()!;
        if (!int.TryParse(opcaoArtista, out int opcaoArtistaMenu) && (opcaoArtistaMenu > artistas.Count || opcaoArtistaMenu <= 0))
        {
            Console.WriteLine("\nDigite uma opção válida");
            Console.Write("\nDigite qualquer tecla para sair");
            Console.ReadKey();
            Console.Clear();
            return null;
        }

        return artistas[opcaoArtistaMenu-1];
    }
}
