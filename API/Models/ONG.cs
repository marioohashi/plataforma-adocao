namespace API.Models;
public class ONG
{
    public ONG() => CriadoEm = DateTime.Now;
    public int ONGId { get; set; }
    public string? Nome { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string? Missao { get; set; }
    public string? Historico { get; set; }
    public string? InformacoesContato { get; set; }
    public DateTime CriadoEm { get; set; }
}