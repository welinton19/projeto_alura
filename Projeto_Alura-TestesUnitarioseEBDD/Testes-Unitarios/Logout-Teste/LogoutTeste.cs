using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Alura_TestesUnitarioseEBDD.Testes_Unitarios.Logout_Teste;

public class LogoutTeste
{
    [Fact]
    public void Logout_RetornaSucesso()
    {
        // Arrange
        var logoutService = new LogoutTeste();

        // Act
        var result = logoutService.Logout();

        // Assert
        Assert.True(result);
    }

    public bool Logout()
    {
        // Simula o processo de logout, como limpar cookies ou tokens
        // Neste exemplo, simplesmente retorna true para indicar sucesso
        return true;
    }
}
