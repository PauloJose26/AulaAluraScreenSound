using Microsoft.Data.SqlClient;
using ScreenSound.Modelo;

namespace ScreenSound.Banco;

internal class ArtistaDAL
{
    public IEnumerable<Artista> Listar()
    {
        var lista = new List<Artista>();
        using var connection = new Connection().ObterConexao();
        connection.Open();

        var sql = "SELECT * FROM Artistas";
        var command = new SqlCommand(sql, connection);
        using SqlDataReader dataReader = command.ExecuteReader();

        while (dataReader.Read())
        {
            var nomeArtista = Convert.ToString(dataReader["Nome"])!;
            var bioArtista = Convert.ToString(dataReader["Bio"])!;
            var fotoPerfilArtista = Convert.ToString(dataReader["FotoPerfil"])!;
            var idArtista = Convert.ToInt32(dataReader["Id"]);

            var artista = new Artista(nomeArtista, bioArtista) { Id = idArtista, FotoPerfil = fotoPerfilArtista };
            lista.Add(artista);
        }

        return lista;
    }

    public Artista BuscarArtista(int id)
    {
        using var connection = new Connection().ObterConexao();
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

    public void Adicionar(Artista artista)
    {
        using var connection = new Connection().ObterConexao();
        connection.Open();

        var sql = "INSERT INTO Artistas (Nome, FotoPerfil, Bio) VALUES (@nome, @fotoPerfil, @bio)";
        var command = new SqlCommand(sql, connection);

        command.Parameters.AddWithValue("@nome", artista.Nome);
        command.Parameters.AddWithValue("@bio", artista.Bio);
        command.Parameters.AddWithValue("@fotoPerfil", artista.FotoPerfil);

        int retorno = command.ExecuteNonQuery();
        Console.WriteLine($"Linhas afetadas: {retorno}");
    }

    public void Atualizar(Artista artista)
    {
        using var connection = new Connection().ObterConexao();
        connection.Open();

        var sql = "UPDATE Artistas SET Nome = @nome, Bio = @bio, FotoPerfil = @fotoPerfil WHERE id = @id";
        var command = new SqlCommand(sql, connection);
        command.Parameters.AddWithValue("@id", artista.Id);
        command.Parameters.AddWithValue("@nome", artista.Nome);
        command.Parameters.AddWithValue("@bio", artista.Bio);
        command.Parameters.AddWithValue("@fotoPerfil", artista.FotoPerfil);

        int retorno = command.ExecuteNonQuery() ;
        Console.WriteLine($"Linhas afetadas: {retorno}");
    }

    public void Deletar(Artista artista)
    {
        using var connection = new Connection().ObterConexao();
        connection.Open();

        var sql = "DELETE FROM Artistas WHERE Id = @id";
        var command = new SqlCommand(sql, connection);
        command.Parameters.AddWithValue("@id", artista.Id);

        int retorno = command.ExecuteNonQuery();
        Console.WriteLine($"Linhas afetadas: {retorno}");
    }
}
