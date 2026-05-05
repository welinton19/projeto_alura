using Projeto_Alura.Domain.Entitis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Alura_TestesUnitarioseEBDD.Testes_Unitarios.Curso_Teste;

public class CursoTeste
{
    [Fact]
    public void Criar_Curso_RetornaSucesso()
    {
        // Arrange
        var curso = new Cursos
        {
            Id = 1,
            Name = "Curso de Testes Unitários",
            Type = "Tec",
            Description = "Aprenda a criar testes unitários eficazes.",
            
        };

        // Act
        var id = curso.Id;
        var name = curso.Name;
        var description = curso.Description;
        var type = curso.Type;

        // Assert
        Assert.Equal(1, id);
        Assert.Equal("Curso de Testes Unitários", name);
        Assert.Equal("Aprenda a criar testes unitários eficazes.", description);
        Assert.Equal("Tec", type);
        
    }

    [Fact]
    public void Pegar_Curso_por_Id_RetornaSucesso()
    {
        // Arrange
        var curso = new Cursos
        {
            Id = 1,
            Name = "Curso de Testes Unitários",
            Type = "Tec",
            Description = "Aprenda a criar testes unitários eficazes."
        };

        // Act
        var id = curso.Id;
        var name = curso.Name;
        var description = curso.Description;
        var type = curso.Type;

        // Assert
        Assert.Equal(1, id);
        Assert.Equal("Curso de Testes Unitários", name);
        Assert.Equal("Aprenda a criar testes unitários eficazes.", description);
        Assert.Equal("Tec", type);
    }

    [Fact]
    public void Atualizar_Curso_RetornaSucesso()
    {
        // Arrange
        var curso = new Cursos
        {
            Id = 1,
            Name = "Curso de Testes Unitários",
            Type = "Tec",
            Description = "Aprenda a criar testes unitários eficazes."
        };

        // Act
        curso.Name = "Curso de Testes Unitários Atualizado";
        curso.Type = "Tec";
        curso.Description = "Aprenda a criar testes unitários eficazes.";

        // Assert
        Assert.Equal("Curso de Testes Unitários Atualizado", curso.Name);
        Assert.Equal("Tec", curso.Type);
        Assert.Equal("Aprenda a criar testes unitários eficazes.", curso.Description);
    }

    [Fact]
    public void Deletar_Curso_RetornaSucesso()
    {
        // Arrange
        var curso = new Cursos
        {
            Id = 1,
            Name = "Curso de Testes Unitários",
            Type = "Tec",
            Description = "Aprenda a criar testes unitários eficazes."
        };

        // Act
        var id = curso.Id;
        var name = curso.Name;
        var description = curso.Description;
        var type = curso.Type;

        // Assert
        Assert.Equal(1, id);
        Assert.Equal("Curso de Testes Unitários", name);
        Assert.Equal("Aprenda a criar testes unitários eficazes.", description);
        Assert.Equal("Tec", type);
    }
}
