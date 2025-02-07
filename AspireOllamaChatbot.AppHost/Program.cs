var builder = DistributedApplication.CreateBuilder(args);

var ollama = builder.AddOllama("ollama")
    .WithDataVolume();

var llamaModel = ollama.AddHuggingFaceModel("llama", 
    "bartowski/Llama-3.2-1B-Instruct-GGUF:IQ4_XS");

var apiService = builder.AddProject<Projects.AspireOllamaChatbot_ApiService>("apiservice");

builder.AddProject<Projects.AspireOllamaChatbot_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WithReference(llamaModel)
    .WaitFor(apiService);

builder.Build().Run();
