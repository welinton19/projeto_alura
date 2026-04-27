var builder = DistributedApplication.CreateBuilder(args);

//Postgres
var postgres = builder.AddPostgres("postgres")
    .WithHostPort(5432)
    .WithDataVolume()
    .WithLifetime(ContainerLifetime.Persistent);

//API
var api  = builder.AddProject<Projects.Projeto_Alura>("projeto-alura")
    .WithReference(postgres);

//Angular
builder.AddNpmApp("frontend", "../Projeto_Alura_Front-End")
    .WithReference(api)
    .WithHttpEndpoint(port: 4200, env:"PORT")
    .WithExternalHttpEndpoints();

builder.Build().Run();
