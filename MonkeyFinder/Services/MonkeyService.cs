namespace MonkeyFinder.Services;
using System.Net.Http.Json;
using MonkeyFinder.Services;

public class MonkeyService
{
    HttpClient httpClient;
    public MonkeyService()
    {
        this.httpClient = new HttpClient();

    }

    List<Monkey> monkeyList = new();
    public async Task<List<Monkey>> GetMonkeys()
    {
        if (monkeyList?.Count > 0)
            return monkeyList;

        var response = await httpClient.GetAsync("https://www.montemagno.com/monkeys.json");

        if (response.IsSuccessStatusCode)
        {
            monkeyList = await response.Content.ReadFromJsonAsync<List<Monkey>>();
        }

        return monkeyList;

        /*If you don't have Internet to access that file, use below code
         using var stream = await FileSystem.OpenAppPackageFileAsync("monkeydata.json");
         using var reader = new StreamReader(stream);
         var contents = await reader.ReadToEndAsync();
         monkeyList = JsonSerializer.Deserialize(contents, MonkeyContext.Default.ListMonkey);*/
    }


}
