using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relay_Blazor_Hybrid.Utils
{
    public class ScreenSizeService
    {
        private readonly IJSRuntime _jsRuntime;
        public event Action<string> OnResize;

        public ScreenSizeService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task<string> GetDeviceCategoryAsync()
        {
            return await _jsRuntime.InvokeAsync<string>("getDeviceCategory");
        }

        public async Task RegisterResizeHandlerAsync()
        {
            var dotNetRef = DotNetObjectReference.Create(this);
            await _jsRuntime.InvokeVoidAsync("registerResizeHandler", dotNetRef);
        }

        [JSInvokable]
        public void OnResizeHandler()
        {
            _ = Task.Run(async () =>
            {
                var deviceCategory = await GetDeviceCategoryAsync();
                OnResize?.Invoke(deviceCategory);
            });
        }
    }
}
