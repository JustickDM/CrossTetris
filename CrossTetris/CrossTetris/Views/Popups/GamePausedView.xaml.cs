using CrossTetris.ViewModels.Base;

using Rg.Plugins.Popup.Pages;

using System.Threading.Tasks;

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

		protected override void OnAppearing()
		{
			base.OnAppearing();
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
		}

		protected override void OnAppearingAnimationBegin()
		{
			base.OnAppearingAnimationBegin();
		}

		protected override void OnAppearingAnimationEnd()
		{
			base.OnAppearingAnimationEnd();
		}

		// Invoked before an animation disappearing
		protected override void OnDisappearingAnimationBegin()
		{
			base.OnDisappearingAnimationBegin();
		}

		// Invoked after an animation disappearing
		protected override void OnDisappearingAnimationEnd()
		{
			base.OnDisappearingAnimationEnd();
		}

		protected override Task OnAppearingAnimationBeginAsync()
		{
			return base.OnAppearingAnimationBeginAsync();
		}

		protected override Task OnAppearingAnimationEndAsync()
		{
			return base.OnAppearingAnimationEndAsync();
		}

		protected override Task OnDisappearingAnimationBeginAsync()
		{
			return base.OnDisappearingAnimationBeginAsync();
		}

		protected override Task OnDisappearingAnimationEndAsync()
		{
			return base.OnDisappearingAnimationEndAsync();
		}

		// ### Overrided methods which can prevent closing a popup page ###

		// Invoked when a hardware back button is pressed
		protected override bool OnBackButtonPressed()
		{
			// Return true if you don't want to close this popup page when a back button is pressed
			return base.OnBackButtonPressed();
		}

		// Invoked when background is clicked
		protected override bool OnBackgroundClicked()
		{
			// Return false if you don't want to close this popup page when a background of the popup page is clicked
			return base.OnBackgroundClicked();
		}
	}
}