namespace API.Models;
public class Evento
{
    public Evento() => CriadoEm = DateTime.Now;

    public int EventoId { get; set; }
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public int Quantidade { get; set; }
    public double Preco { get; set; }
    public DateTime CriadoEm { get; set; }
}
