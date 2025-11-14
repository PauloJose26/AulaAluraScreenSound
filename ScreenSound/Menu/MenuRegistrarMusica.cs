using ScreenSound.Banco;
using ScreenSound.Shared.Modelo;

namespace ScreenSound.Menu;

internal class MenuRegistrarMusica: Menu
{
    public override void Executar(DAL<Artista> artistaDAL, DAL<Musica> musicaDAL)
    {
        base.Executar(artistaDAL, musicaDAL);
        this.ExibirTituloDaOpcao("Registro de Músicas");

        if (!this.BuscarArtista(artistaDAL, out var artista))
        {
            return;
        }

        Console.Write("\nDigite o nome da música: ");
        var nomeMusica = Console.ReadLine()!;
        Console.Write("Digite o ano de lançamento da música: ");
        var anoLancamento = Console.ReadLine()!;
        if(!int.TryParse(anoLancamento, out var anoLancamentoMusica))
        {
            Console.WriteLine("Ano de lançamento inválido!!");
            this.Continuar();
            return;
        }

        var musica = new Musica(nomeMusica) {AnoLancamento = anoLancamentoMusica};
        artista.AdionarMusica(musica);
        artistaDAL.Atualizar(artista);

        Console.WriteLine("\nMusica Cadastrada\n");
        Console.WriteLine(musica);

        this.Continuar();
    }
}
