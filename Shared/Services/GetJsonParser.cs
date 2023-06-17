using System.Net.Http.Headers;
using System.Text.Json;

namespace Proj_APBD.Shared.Services;

public static class GetJsonParser<T>
{
    public static async Task<T?> Parse(string url)
    {
        var client = new HttpClient();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        using var result = await client.GetAsync(url);
        if (!result.IsSuccessStatusCode) return default;
        var response = JsonSerializer.Deserialize<T>(await result.Content.ReadAsStringAsync());
        return response;
    }
}