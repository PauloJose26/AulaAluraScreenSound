namespace ScreenSound.Shared.Modelo;

public class Musica
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int? AnoLancamento { get; set; }
    public virtual Artista? Artista { get; set; }

    public Musica() { }

    public Musica(string nome, int? anoLancamento)
    {
        this.Nome = nome;
        this.AnoLancamento = anoLancamento;
    }

    public void FichaTecnica()
    {
        Console.WriteLine($"Nome: {this.Nome}");
    }

    public override string ToString()
    {
        return $"   Id: {this.Id}\n   Nome: {this.Nome}\n   Ano de Lançamento: {this.AnoLancamento}";
    }
}
