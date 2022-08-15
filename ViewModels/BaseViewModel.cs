using CommunityToolkit.Mvvm.ComponentModel;

namespace MonkeyFinder.ViewModels;

[INotifyPropertyChanged]
public partial class BaseViewModel
{
	private bool isBusy;
	private string title;

	public bool IsBusy
	{
		get => isBusy;
		set
		{
			if (isBusy == value)
			{
				return;
			}

			isBusy = value;
		}
	}

	public string Title
	{
		get => title;
		set
		{
			if (title == value)
			{
				return;
			}

			title = value;
		}
	}

	public bool IsNotBusy => !IsBusy;
}
