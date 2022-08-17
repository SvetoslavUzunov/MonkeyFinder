using System.Collections.ObjectModel;
using System.Diagnostics;
using MonkeyFinder.Model;
using MonkeyFinder.Services;

namespace MonkeyFinder.ViewModels;

public class MonkeysViewModel : BaseViewModel
{
	private readonly MonkeyService monkeyService;

	public MonkeysViewModel(MonkeyService monkeyService)
	{
		Title = "Monkey Finder";
		this.monkeyService = monkeyService;
		GetMonkeysCommaand = new Command(async () => await GetMonkeysAsync());
	}

	public ObservableCollection<Monkey> Monkeys { get; init; } = new();

	public Command GetMonkeysCommaand { get; init; }

	public async Task GetMonkeysAsync()
	{
		if (IsBusy)
		{
			return;
		}

		try
		{
			IsBusy = true;
			var monkeys = await monkeyService.GetMonkeysAsync();

			if (Monkeys.Any())
			{
				Monkeys.Clear();
			}

			foreach (var monkey in monkeys)
			{
				Monkeys.Add(monkey);
			}
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
			await Shell.Current.DisplayAlert("Error!", $"Unable to get monkeys: {ex.Message}", "OK");
		}
		finally
		{
			IsBusy = false;
		}
	}
}
