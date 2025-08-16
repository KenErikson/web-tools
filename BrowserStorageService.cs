using Microsoft.JSInterop;
using System.Text.Json;

public class BrowserStorageService
{
    private readonly IJSRuntime _js;
    private const string LocalStorageSet = "localStorage.setItem";
    private const string LocalStorageGet = "localStorage.getItem";

    public BrowserStorageService(IJSRuntime js)
    {
        _js = js;
    }

    public async Task SetAsync(string key, object value)
    {
        string jsonValue = JsonSerializer.Serialize(value);
        await _js.InvokeVoidAsync(LocalStorageSet, key, jsonValue);
    }

    public async Task<T?> GetAsync<T>(string key)
    {
        var jsonValue = await _js.InvokeAsync<string>(LocalStorageGet, key);
        if (string.IsNullOrEmpty(jsonValue))
        {
            return default;
        }
        return JsonSerializer.Deserialize<T>(jsonValue);
    }
}