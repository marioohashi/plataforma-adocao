namespace API.Models;
public class Pessoa
{
    public Pessoa() => CriadoEm = DateTime.Now;

    public int PessoaId { get; set; }
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public int Quantidade { get; set; }
    public double Preco { get; set; }
    public DateTime CriadoEm { get; set; }
}
