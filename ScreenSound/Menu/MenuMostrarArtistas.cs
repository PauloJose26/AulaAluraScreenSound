using ScreenSound.Banco;

namespace ScreenSound.Menu;

internal class MenuMostrarArtistas: Menu
{
    public override void Executar(ArtistaDAL artistaDAL)
    {
        base.Executar(artistaDAL);
        this.ExibirTituloDaOpcao("Lista de Artistas");

        foreach(var artista in artistaDAL.Listar()) {
            Console.WriteLine(artista);
        }

        this.Continuar();
    }
}