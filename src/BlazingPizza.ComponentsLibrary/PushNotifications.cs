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

        public async Task<SubscriptionInfo> RequestSubscription()
        {
            return await _jsRuntime.InvokeAsync<SubscriptionInfo>("blazorPushNotifications.requestSubscription");
        }

        public class SubscriptionInfo
        {
            public string Url { get; set; }
            public string P256dh { get; set; }
            public string Auth { get; set; }
        }
    }
}
