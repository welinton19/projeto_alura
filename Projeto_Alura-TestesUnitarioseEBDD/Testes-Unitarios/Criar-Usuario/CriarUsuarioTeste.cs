using Projeto_Alura.Domain.Entitis;
using Projeto_Alura.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Alura_TestesUnitarioseEBDD.Testes_Unitarios.Criar_Usuario;

public class CriarUsuarioTeste
{
    [Fact]
    public void CriarUsuario_UsuarioAdmin_RetornaSucesso()
    {
        // Arrange
        var usuarioService = new Users
        {
            Id = 1,
            Name = "Admin User",
            Email = "admin@example.com",
            Password = "password",
            ConfirmPassword = "password",
            Role = Roles.Admin
        };

        // Act
        var Id = usuarioService.Id;
        var Name = usuarioService.Name;
        var Email = usuarioService.Email;
        var Password = usuarioService.Password;
        var ConfirmPassword = usuarioService.ConfirmPassword;
        var Role = usuarioService.Role;

        // Assert
        Assert.Equal(1, Id);
        Assert.Equal("Admin User", Name);
        Assert.Equal("admin@example.com", Email);
        Assert.Equal("password", Password);
        Assert.Equal("password", ConfirmPassword);
        Assert.Equal(Roles.Admin, Role);

    }

    [Fact]
    public void CriarUsuario_UsuarioInstructor_RetornaSucesso()
    {
        // Arrange
        var usuarioService = new Users
        {
            Id = 2,
            Name = "Instructor User",
            Email = "instructor@example.com",
            Password = "password",
            ConfirmPassword = "password",
            Role = Roles.Instructor
        };

        // Act
        var Id = usuarioService.Id;
        var Name = usuarioService.Name;
        var Email = usuarioService.Email;
        var Password = usuarioService.Password;
        var ConfirmPassword = usuarioService.ConfirmPassword;
        var Role = usuarioService.Role;

        // Assert
        Assert.Equal(2, Id);
        Assert.Equal("Instructor User", Name);
        Assert.Equal("instructor@example.com", Email);
        Assert.Equal("password", Password);
        Assert.Equal("password", ConfirmPassword);
        Assert.Equal(Roles.Instructor, Role);
    }

    [Fact]
    public void CriarUsuario_UsuarioStudent_RetornaSucesso()
    {
        // Arrange
        var usuarioService = new Users
        {
            Id = 3,
            Name = "Student User",
            Email = "student@example.com",
            Password = "password",
            ConfirmPassword = "password",
            Role = Roles.Student
        };

        // Act
        var Id = usuarioService.Id;
        var Name = usuarioService.Name;
        var Email = usuarioService.Email;
        var Password = usuarioService.Password;
        var ConfirmPassword = usuarioService.ConfirmPassword;
        var Role = usuarioService.Role;

        // Assert
        Assert.Equal(3, Id);
        Assert.Equal("Student User", Name);
        Assert.Equal("student@example.com", Email);
        Assert.Equal("password", Password);
        Assert.Equal("password", ConfirmPassword);
        Assert.Equal(Roles.Student, Role);
    }
}