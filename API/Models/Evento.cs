namespace API.Models;
public class Evento
{
    public Evento() => CriadoEm = DateTime.Now;

    public int EventoId { get; set; }
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public ONG OngProprietaria { get; set; }
    public DateTime? DataEvento { get; set; }
    public DateTime CriadoEm { get; set; }
}
