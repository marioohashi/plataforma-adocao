namespace API.Models;
public class Animal
{
    public int AnimalId { get; set; }
    public string Nome { get; set; }
    public string? Idade { get; set; }
    public string? Especie { get; set; }
    public string? Raca { get; set; }
    public string? Porte { get; set; }
    public string? Comportamento { get; set; }
    public string? Descricao { get; set; }
    public string? Foto { get; set; }
    public string? Video { get; set; }
    public ONG? ONG { get; set; }
    public int ONGId { get; set; }
    // public Pessoa? Tutor { get; set; }

}
