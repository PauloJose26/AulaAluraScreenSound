using ScreenSound.Banco;
using ScreenSound.Modelo;

namespace ScreenSound.Menu;

internal class MenuMostrarMusicas: Menu
{
    public override void Executar(DAL<Artista> artistaDAL)
    {
        base.Executar(artistaDAL);
        this.ExibirTituloDaOpcao("Exibir detalhes de um artista");

        if (!this.BuscarArtista(artistaDAL, out var artista))
        {
            return;
        }

        artista.ExibirDiscografia();
        this.Continuar();
    }
}
