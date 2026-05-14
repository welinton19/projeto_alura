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
    .WithHttpEndpoint(port: 4300, env:"PORT")
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();

builder.Build().Run();
