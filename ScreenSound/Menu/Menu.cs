using ScreenSound.Banco;
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

    public virtual void Executar(ArtistaDAL artistaDAL) => Console.Clear();

    public void Continuar()
    {
        Console.Write("\nDigite qualquer tecla para sair");
        Console.ReadKey();
        Console.Clear();
    }
}
