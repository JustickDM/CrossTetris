using CrossTetris.ViewModels.Base;

using Rg.Plugins.Popup.Pages;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrossTetris.Views.Popups
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GamePausedView : PopupPage
	{
		public GamePausedView()
		{
			InitializeComponent();

			BackgroundClicked += (sender, e) => MessagingCenter.Send(this, MessagesEnum.Unpause);
		}
	}
}