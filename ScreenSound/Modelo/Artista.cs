namespace ScreenSound.Modelo;

internal class Artista
{
    private List<Musica> musicas = new();
    public int Id { get; set; }
    public string Nome { get; set; }
    public string FotoPerfil { get; set; }
    public string Bio {  get; set; }

    public Artista(string nome, string bio)
    {
        this.Nome = nome;
        this.Bio = bio;
        this.FotoPerfil = "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png";
    }

    public void AdionarMusica(Musica musica)
    {
        this.musicas.Add(musica);
    }

    public void ExibirDiscografia()
    {
        Console.WriteLine($"Discografia do artista {this.Nome}");
        foreach(var musica in this.musicas)
        {
            Console.WriteLine($"Música: {musica.Nome}");
        }
    }

    public override string ToString()
    {
        return $"   Id: {this.Id}\n    Nome: {this.Nome}\n    Foto de Perfil: {this.FotoPerfil}\n    Bio: {this.Bio}";
    }
}
