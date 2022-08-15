using System.Net.Http.Json;
using MonkeyFinder.Model;

namespace MonkeyFinder.Services;

public class MonkeyService
{
	private readonly HttpClient httpClient;
	private List<Monkey> monkeys = new();

	public MonkeyService(HttpClient httpClient)
	{
		this.httpClient = httpClient;
	}

	public async Task<IEnumerable<Monkey>> GetMonkeys()
	{
		if (monkeys?.Count > 0)
		{
			return monkeys;
		}

		var url = "https://montemagno.com/monkeys.json";
		var response = await httpClient.GetAsync(url);

		if (response.IsSuccessStatusCode)
		{
			monkeys = await response.Content.ReadFromJsonAsync<List<Monkey>>();
		}

		return monkeys;
	}
}
