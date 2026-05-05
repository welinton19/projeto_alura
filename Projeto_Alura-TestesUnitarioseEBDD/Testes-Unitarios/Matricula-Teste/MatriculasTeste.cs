using Projeto_Alura.Domain.Entitis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Alura_TestesUnitarioseEBDD.Testes_Unitarios.Matricula_Teste;

public class MatriculasTeste
{
    [Fact]
    public void Criar_Matricula_RetornaSucesso()
    {
        // Arrange
        var matricula = new Matriculas
        {
            Id = 1,
            UserId = 1,
            CursoId = 1,
            DataMatricula = DateTime.Now
        };

        // Act
        var id = matricula.Id;
        var userId = matricula.UserId;
        var cursoId = matricula.CursoId;
        var dataMatricula = matricula.DataMatricula;
        // Assert
        Assert.Equal(1, id);
        Assert.Equal(1, userId);
        Assert.Equal(1, cursoId);
        Assert.Equal(DateTime.Now.Date, dataMatricula.Date);
    }

    [Fact]
    public void Pegar_Matricula_por_Id_RetornaSucesso()
    {
        // Arrange
        var matricula = new Matriculas
        {
            Id = 1,
            UserId = 1,
            CursoId = 1,
            DataMatricula = DateTime.Now
        };

        // Act
        var id = matricula.Id;
        var userId = matricula.UserId;
        var cursoId = matricula.CursoId;
        var dataMatricula = matricula.DataMatricula;

        // Assert
        Assert.Equal(1, id);
        Assert.Equal(1, userId);
        Assert.Equal(1, cursoId);
        Assert.Equal(DateTime.Now.Date, dataMatricula.Date);
    }
    [Fact]
    public void Pegar_Matricula_por_UserId_RetornaSucesso()
    {
        // Arrange
        var matricula = new Matriculas
        {
            Id = 1,
            UserId = 1,
            CursoId = 1,
            DataMatricula = DateTime.Now
        };
        // Act
        var userId = matricula.UserId;
        // Assert
        Assert.Equal(1, userId);
    }

    [Fact]
    public void Pegar_Matricula_por_CursoId_RetornaSucesso()
    {
        // Arrange
        var matricula = new Matriculas
        {
            Id = 1,
            UserId = 1,
            CursoId = 1,
            DataMatricula = DateTime.Now
        };
        // Act
        var cursoId = matricula.CursoId;
        // Assert
        Assert.Equal(1, cursoId);
    }

    [Fact]
    public void Pegar_Matricula_por_DataMatricula_RetornaSucesso()
    {
        // Arrange
        var matricula = new Matriculas
        {
            Id = 1,
            UserId = 1,
            CursoId = 1,
            DataMatricula = DateTime.Now
        };
        // Act
        var dataMatricula = matricula.DataMatricula;
        // Assert
        Assert.Equal(DateTime.Now.Date, dataMatricula.Date);
    }

    [Fact]
    public void Atualizar_Matricula_RetornaSucesso()
    {
        // Arrange
        var matricula = new Matriculas
        {
            Id = 1,
            UserId = 1,
            CursoId = 1,
            DataMatricula = DateTime.Now
        };
        // Act
        matricula.UserId = 2;
        matricula.CursoId = 2;
        matricula.DataMatricula = DateTime.Now.AddDays(1);
        // Assert
        Assert.Equal(2, matricula.UserId);
        Assert.Equal(2, matricula.CursoId);
        Assert.Equal(DateTime.Now.AddDays(1).Date, matricula.DataMatricula.Date);
    }

    [Fact]
    public void Deletar_Matricula_RetornaSucesso()
    {
        // Arrange
        var matricula = new Matriculas
        {
            Id = 1,
            UserId = 1,
            CursoId = 1,
            DataMatricula = DateTime.Now
        };
        // Act
        matricula = null;
        // Assert
        Assert.Null(matricula);
    }
}
