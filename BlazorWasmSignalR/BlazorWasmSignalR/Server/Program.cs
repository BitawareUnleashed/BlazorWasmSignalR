using BlazorWasmSignalR.Server.Controllers;
using BlazorWasmSignalR.Server.Models.Hub;
using BlazorWasmSignalR.Server.Workers;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Hosting;
using Microsoft.JSInterop;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddSignalR();

builder.Services.AddSingleton<SimpleWorker>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");


app.MapHub<CommunicationHub>("/communicationhub", options =>
{
    options.Transports = HttpTransportType.WebSockets & HttpTransportType.LongPolling;
    //options.CloseOnAuthenticationExpiration = false;
    options.ApplicationMaxBufferSize = 65_536;
    options.TransportMaxBufferSize = 65_536;
    options.MinimumProtocolVersion = 0;
    options.TransportSendTimeout = TimeSpan.FromSeconds(10);
    options.WebSockets.CloseTimeout = TimeSpan.FromSeconds(3);
});
app.AddLightsApiEndpoints();


Task.Run(() =>
{
    var worker = app.Services.GetRequiredService<SimpleWorker>();

    _ = worker.ExecuteAsync(new CancellationToken());
});




app.Run();
