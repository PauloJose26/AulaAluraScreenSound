namespace ScreenSound.Modelo;

internal class Musica
{
    public int Id { get; set; }
    public string Nome { get; set; }

    public Musica(string nome)
    {
        this.Nome = nome;
    }

    public void FichaTecnica()
    {
        Console.WriteLine($"Nome: {this.Nome}");
    }

    public override string ToString()
    {
        return $"   Id: {this.Id}\n   Nome: {this.Nome}";
    }
}
