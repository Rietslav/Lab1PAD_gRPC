using Broker.Services;
using Common;

var builder = WebApplication.CreateBuilder(args);

// === ConfigureServices ===
builder.Services.AddGrpc();

var app = builder.Build();

// === Configure ===
app.MapGrpcService < PublisherService>();

// URL-urile (echivalent cu UseUrls)
app.Urls.Add(EndpointsConstants.BrokerAddress);

app.MapGet("/", () =>
    "Communication with gRPC endpoints must be made through a gRPC client. " +
    "To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
