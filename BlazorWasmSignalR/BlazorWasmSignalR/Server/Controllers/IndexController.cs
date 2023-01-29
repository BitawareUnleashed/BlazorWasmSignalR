using BlazorWasmSignalR.Server.Models.Hub;
using BlazorWasmSignalR.Shared.Models;

namespace BlazorWasmSignalR.Server.Controllers;

public static class IndexController
{
    private const string TestEndpoint = "/api/v1/Test";

    public static IEndpointRouteBuilder AddLightsApiEndpoints(this IEndpointRouteBuilder app)
    {
        _ = app.MapGet(TestEndpoint, GetLightsConfigurationApi);
        return app;
    }

    internal static IResult GetLightsConfigurationApi(CommunicationHub hub)
    {
        _ = hub.SendMessage(new NotificationTransport()
        {
            Message = "",
            MessageType = "string"
        });
        return Results.Ok();
    }
}

