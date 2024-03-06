using Microsoft.Azure.Functions.Worker.Http;
using System.Reflection;
using System.Web;

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

    public static TQuery? GetQuery<TQuery>(this HttpRequestData req) where TQuery : new()
    {
        try
        {
            var query = HttpUtility.ParseQueryString(req.Url.Query);
            var result = new TQuery();

            foreach (PropertyInfo prop in typeof(TQuery).GetProperties())
            {
                if (prop.CanWrite)
                {
                    string? value = query[prop.Name];
                    if (value != null)
                    {
                        Type propType = prop.PropertyType;
                        if (Nullable.GetUnderlyingType(propType) != null)
                        {
                            // Handle nullable types
                            prop.SetValue(result, Convert.ChangeType(value, Nullable.GetUnderlyingType(propType)), null);
                        }
                        else
                        {
                            // Handle non-nullable types
                            prop.SetValue(result, Convert.ChangeType(value, propType), null);
                        }
                    }
                }
            }

            return result;
        }
        catch (Exception e)
        {
            return default;
        }
    }
}
