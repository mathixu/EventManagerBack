using Microsoft.Azure.Functions.Worker.Http;

namespace EventManager.Presentation.Helpers;

public static class HttpRequestDataHelper
{
    public static async Task<TBody?> GetBodyAsync<TBody>(this HttpRequestData req)
    {
        try
        {
            var result = await req.ReadFromJsonAsync<TBody>();
            return result;
        }
        catch (Exception)
        {
            return default;
        }
    }
}
