using ScreenSound.Shared.Banco;
using ScreenSound.Shared.Modelo;

namespace ScreenSound.Menu;

internal class MenuMostrarMusicas: Menu
{
    public override void Executar(DAL<Artista> artistaDAL, DAL<Musica> musicaDAL)
    {
        base.Executar(artistaDAL, musicaDAL);
        this.ExibirTituloDaOpcao("Exibir detalhes de um artista");

        if (!this.BuscarArtista(artistaDAL, out var artista))
        {
            return;
        }

        artista.ExibirDiscografia();
        this.Continuar();
    }
}
