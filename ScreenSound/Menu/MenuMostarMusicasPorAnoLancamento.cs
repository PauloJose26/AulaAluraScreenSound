using ScreenSound.Banco;
using ScreenSound.Shared.Modelo;

namespace ScreenSound.Menu;

internal class MenuMostarMusicasPorAnoLancamento: Menu
{
    public override void Executar(DAL<Artista> artistaDAL, DAL<Musica> musicaDAL)
    {
        base.Executar(artistaDAL, musicaDAL);
        this.ExibirTituloDaOpcao("Lista de músicas por Ano de Lançamento");

        Console.Write("\nDigire o ano de Lançamento da música: ");
        var anoLancamento = Console.ReadLine()!;

        if(!int.TryParse(anoLancamento, out int anoLancamentoMusica))
        {
            Console.WriteLine("Ano de lançamento inválido!!");
            this.Continuar();
            return;
        }

        Console.WriteLine();
        var musicas = musicaDAL.ListarPor(musica => musica.AnoLancamento.Equals(anoLancamentoMusica));
        foreach( var musica in musicas)
        {
            Console.WriteLine(musica);
        }

        this.Continuar();
    }
}
