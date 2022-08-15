using CommunityToolkit.Mvvm.ComponentModel;

namespace MonkeyFinder.ViewModels;

public partial class BaseViewModel : ObservableObject
{
	public BaseViewModel()
	{
	}

	[ObservableProperty]
	//[AlsoNotifyChangeFor(nameof(IsNotBusy))]
	private bool isBusy;

	[ObservableProperty]
	private string title;

	public bool IsNotBusy => !IsBusy;
}
