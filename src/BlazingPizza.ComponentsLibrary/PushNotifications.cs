using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace BlazingPizza.ComponentsLibrary
{
    public class PushNotifications
    {
        private readonly IJSRuntime _jsRuntime;

        public PushNotifications(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task<string> RequestSubscription()
        {
            return await _jsRuntime.InvokeAsync<string>("blazorPushNotifications.requestSubscription");
        }
    }
}
