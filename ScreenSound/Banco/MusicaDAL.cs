using ScreenSound.Modelo;

namespace ScreenSound.Banco;

internal class MusicaDAL
{
    private readonly ScreenSoundContext context;

    public MusicaDAL(ScreenSoundContext context)
    {
        this.context = context;
    }

    public IEnumerable<Musica> Listar() => context.Musicas.ToList();

    public void Adicionar(Musica musica)
    {
        context.Musicas.Add(musica);
        context.SaveChanges();
    }

    public void Atualizar(Musica musica)
    {
        context.Musicas.Update(musica);
        context.SaveChanges();
    }

    public void Deletar(Musica musica)
    {
        context.Musicas.Remove(musica);
        context.SaveChanges();
    }

    public Musica? BuscarPorNome(string nome) => context.Musicas.FirstOrDefault(musica => musica.Nome.Equals(nome));
}
