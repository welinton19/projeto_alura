using Projeto_Alura.Domain.Entitis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Alura_TestesUnitarioseEBDD.Testes_Unitarios.Login_teste;

public class LoginTeste
{
    [Fact]
    public void Login_UsuarioValido_RetornaSucesso()
    {
        // Arrange
        var newLogin = new Users
        {
            
            
            Email = "user@example.com",
            Password = "password"
        };

        // Act
        var email = newLogin.Email;
        var password = newLogin.Password;

        // Assert
        Assert.Equal("user@example.com", email);
        Assert.Equal("password", password);
    }
}
