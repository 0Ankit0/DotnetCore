var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.File_Management_System_ApiService>("apiservice");

builder.AddProject<Projects.File_Management_System_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
