using BlazorWasmSignalR.Server.Models;
using BlazorWasmSignalR.Server.Models.Hub;
using BlazorWasmSignalR.Shared.Models;

namespace BlazorWasmSignalR.Server.Controllers;

public static class IndexController
{
    private const string TestEndpoint = "/api/v1/Test";

    public static IEndpointRouteBuilder AddTestApiEndpoints(this IEndpointRouteBuilder app)
    {
        _ = app.MapGet(TestEndpoint, GetLightsConfigurationApi);
        return app;
    }

    internal static IResult GetLightsConfigurationApi(ICommunicationServer server)
    {
        server.SendChannelActivationMessage();
        return Results.Ok();
    }
}

