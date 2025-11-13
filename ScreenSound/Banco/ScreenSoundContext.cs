using Microsoft.EntityFrameworkCore;
using ScreenSound.Modelo;

namespace ScreenSound.Banco;

internal class ScreenSoundContext: DbContext
{
    private readonly string stringConnection = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ScreenSound;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

    public DbSet<Artista> Artistas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(stringConnection);
    }
}
