using Microsoft.Data.SqlClient;
using ScreenSound.Modelo;

namespace ScreenSound.Banco;

internal class ArtistaDAL
{
    private readonly ScreenSoundContext context;

    public ArtistaDAL(ScreenSoundContext context)
    {
        this.context = context;
    }

    public IEnumerable<Artista> Listar()
    {
        return context.Artistas.ToList();
    }

    public void Adicionar(Artista artista)
    {
        context.Artistas.Add(artista);
        context.SaveChanges();
    }

    public void Atualizar(Artista artista)
    {
        context.Artistas.Update(artista);
        context.SaveChanges();
    }
    public void Deletar(Artista artista)
    {
        context.Artistas.Remove(artista);
        context.SaveChanges();
    }

    /*
    public Artista BuscarArtista(int id)
    {
        using var connection = new ScreenSoundContext().ObterConexao();
        connection.Open();

        var sql = "SELECT * FROM Artistas WHERE Id = @id";
        var command = new SqlCommand(sql, connection);

        command.Parameters.AddWithValue("@id", id);
        using SqlDataReader dataReader = command.ExecuteReader();

        dataReader.Read();
        var nomeArtista = Convert.ToString(dataReader["Nome"])!;
        var bioArtista = Convert.ToString(dataReader["Bio"])!;
        var fotoPerfilArtista = Convert.ToString(dataReader["FotoPerfil"])!;
        var idArtista = Convert.ToInt32(dataReader["Id"]);

        return new Artista(nomeArtista, bioArtista) { Id = idArtista, FotoPerfil = fotoPerfilArtista };
    }
    */
}
