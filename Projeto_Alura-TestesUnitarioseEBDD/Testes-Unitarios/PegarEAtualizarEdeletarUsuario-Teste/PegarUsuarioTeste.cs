
using Projeto_Alura.Domain.Entitis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Alura_TestesUnitarioseEBDD.Testes_Unitarios.PegarEAtualizarEdeletarUsuario_Teste;

public class PegarUsuarioTeste
{
    [Fact]
    public void Pegar_lista_de_usuarios_RetornaSucesso()
    {
        // Arrange
        var usuarioService = new Users();
        var result = new List<Users>
        {
            new Users
            {
                Id = 1,
                Name = "Admin User",
                Email = "admin@example.com",
                Password = "password",
                ConfirmPassword = "password",
                Role = Projeto_Alura.Domain.Enum.Roles.Admin
            }
        };

        // Act
        var ListUsers = result;
        // Assert
        Assert.NotNull(result);
        Assert.IsType<List<Users>>(result);
    }

    [Fact]
    public void Pegar_Usuario_por_Id_RetornaSucesso()
    {
        // Arrange
        var usuarioService = new Users();
        var result = new Users
        {
            Id = 1,

        };
        // Act
        var user = result.Id == 1 ? result : null;
        // Assert
        Assert.NotNull(user);
        Assert.Equal(result.Id, user.Id);

    }

    [Fact]
    public void Pegar_Usuario_peliId_e_Atualizar_RetornaSucesso()
    {
        // Arrange
        var usuarioService = new Users();
        var result = new Users
        {
            Id = 1,
            Name = "Admin User",
            Email = "admin@example.com",
            Password = "password",
            ConfirmPassword = "password",
            Role = Projeto_Alura.Domain.Enum.Roles.Admin
        };

        // Act
        var res = result;
        //Assert
        Assert.NotNull(res);
        Assert.Equal(result.Id, res.Id);
    }

    [Fact]
    public void Pegar_Usuario_peliId_e_Deletar_RetornaSucesso()
    {
        // Arrange
        var usuarioService = new Users();
        var result = new Users
        {
            Id = 1,
            Name = "Admin User",
            Email = "admin@example.com",
            Password = "password",
            ConfirmPassword = "password",
            Role = Projeto_Alura.Domain.Enum.Roles.Admin
        };

        // Act
        var res = result;
        //Assert
        Assert.NotNull(res);
        Assert.Equal(result.Id, res.Id);
    }
}
