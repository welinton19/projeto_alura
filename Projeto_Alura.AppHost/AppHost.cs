var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Projeto_Alura>("projeto-alura");

builder.Build().Run();
