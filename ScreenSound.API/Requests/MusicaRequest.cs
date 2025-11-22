using System.ComponentModel.DataAnnotations;

namespace ScreenSound.API.Requests;

public record MusicaRequest([Required] string nome, [Required] int artistaId, int anoLancamento);

public record MusicaRequestEdit(int id, string nome, int anoLancamento, int artistaId): MusicaRequest(nome, artistaId, anoLancamento);
