namespace Projeto_Alura.Domain.Entitis;

public  class Matriculas
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public long CursoId { get; set; }
    public DateTime DataMatricula { get; set; }
    public Matriculas()
    {
    }
    public Matriculas(long id, long userId, long cursoId, DateTime dataMatricula)
    {
        Id = id;
        UserId = userId;
        CursoId = cursoId;
        DataMatricula = dataMatricula;
    }
}
