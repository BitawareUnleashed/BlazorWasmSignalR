using BlazorWasmSignalR.Client.Services;

namespace BlazorWasmSignalR.Client.Pages;

public partial class Index
{
    private NotificationService? notificationService;
    protected override Task OnInitializedAsync()
    {
        notificationService = new NotificationService(NavigationManager, Http);
        return base.OnInitializedAsync();
    }
}

