namespace API.Models;
public class ONG
{
    public ONG() => CriadoEm = DateTime.Now;

    public int ONGId { get; set; }
    public string? Nome { get; set; }
    public string? Missao { get; set; }
    public string? Historico { get; set; }
    public string? InformacoesContato { get; set; }

    // RELAÇÂO ENTRE ONG E EVENTO
    
    // public List<string>? HabilidadesColaboradores { get; set; }
    // public List<string>? AreasAtuacao { get; set; }
    // public List<Evento>? Eventos { get; set; }
    // public List<Animal>? AnimaisDoados { get; set; }
    // public List<Animal>? AnimaisDoacao { get; set; }
    // public List<Animal>? AnimaisInteresse { get; set; }

    public DateTime CriadoEm { get; set; }
}
