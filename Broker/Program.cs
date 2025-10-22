using Broker.Services;
using Broker.Services.Interfaces;
using Common;

var builder = WebApplication.CreateBuilder(args);

// === ConfigureServices ===

// Adăugăm gRPC
builder.Services.AddGrpc();

// Înregistrăm MessageStorageService ca singleton pentru interfața IMessageStorageService
builder.Services.AddSingleton<IMessageStorageService, MessageStorageService>();

var app = builder.Build();

// === Configure ===

// Mapăm PublisherService gRPC
app.MapGrpcService<PublisherService>();

// Setăm URL-ul brokerului (echivalent cu UseUrls)
app.Urls.Add(EndpointsConstants.BrokerAddress);

// Endpoint GET pentru test
app.MapGet("/", () =>
    "Communication with gRPC endpoints must be made through a gRPC client. " +
    "To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
