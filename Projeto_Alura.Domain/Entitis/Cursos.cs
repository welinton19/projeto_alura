namespace Projeto_Alura.Domain.Entitis;

public class Cursos
{
    public long Id { get; set; }
    public String Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public Cursos() 
    {
    }

    public Cursos(long id, string name, string type, string description)
    {
        Id = id;
        Name = name;
        Type = type;
        Description = description;
    }
}
