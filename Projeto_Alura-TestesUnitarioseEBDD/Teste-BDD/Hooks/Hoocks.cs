using BoDi;
using TechTalk.SpecFlow;

namespace Projeto_Alura_TestesUnitarioseEBDD.Teste_BDD.Hooks;

public class Hoocks
{
    private readonly IObjectContainer _container;
    private HttpClient _httpClient = null;

    public Hoocks(IObjectContainer container)
    {
        _container = container;
    }

    [BeforeScenario]
    public void BeforeScenario()
    {
        _httpClient = new HttpClient()
        {
            BaseAddress = new Uri("https://localhost:7156") 
        };
        _container.RegisterInstanceAs(_httpClient);
    }

    [AfterScenario]
    public void AfterScenario()
    {
        _httpClient?.Dispose();
    }
}
