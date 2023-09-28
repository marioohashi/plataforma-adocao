namespace API.Models;
public class Animal
{
    public int AnimalId { get; set; }
    public string Nome { get; set; }
    public int? Idade { get; set; }
    public string? Especie { get; set; }
    public string? Raca { get; set; }
    public string? Porte { get; set; }
    public string? Comportamento { get; set; }
    public string? Descricao { get; set; }
    public Pessoa? Tutor { get; set; }
    public List<String>? Fotos { get; set; }
    public List<String>? Videos { get; set; }

}
