namespace API.Models;
public class Pessoa
{
    public Pessoa() => CriadoEm = DateTime.Now;

    public int PessoaId { get; set; }
    public string? Nome { get; set; }
    public string? Endereco { get; set; }
    public string? NumeroTelefone { get; set; }
    public string? Email { get; set; }
    public int? AnimalId { get; set; }
    public DateTime CriadoEm { get; set; }

}