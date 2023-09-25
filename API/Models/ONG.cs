namespace API.Models;
public class ONG
{
    public ONG() => CriadoEm = DateTime.Now;

    public int ONGId { get; set; }
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public int Quantidade { get; set; }
    public double Preco { get; set; }
    public DateTime CriadoEm { get; set; }
}
