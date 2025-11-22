using System.ComponentModel.DataAnnotations;

namespace ScreenSound.API.Requests;

public record ArtistaRequest([Required] string nome, [Required] string bio);

public record ArtistaRequestEdit(int id, string nome, string bio): ArtistaRequest(nome, bio);
