using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data;
public class AppDataContext : DbContext
{
    public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
    {

    }

    //Classes que vão se tornar tabelas no banco de dados
    public DbSet<Animal> Animais { get; set; }
    public DbSet<Evento> Eventos { get; set; }
    public DbSet<ONG> ONGs { get; set; }
    public DbSet<Pessoa> Pessoas { get; set; }
}
