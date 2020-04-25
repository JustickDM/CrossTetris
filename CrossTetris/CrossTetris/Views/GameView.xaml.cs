using CrossTetris.ViewModels;

using Tetris.Enums;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrossTetris.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GameView : ContentPage
	{
		private BoxView[,] _mainField;

		private GameViewModel _gameViewModel;

		public GameView()
		{
			_gameViewModel = new GameViewModel();
			_mainField = new BoxView[_gameViewModel.N, _gameViewModel.M];

			_gameViewModel.Game.FieldChanged += () => Draw();

			InitializeComponent();

			SetItems();

			BindingContext = _gameViewModel;
		}

		private void SetItems()
		{
			for (var i = 0; i < _gameViewModel.N; i++)
			{
				mainGrid.RowDefinitions.Add(new RowDefinition() { Height = 10 });

				for (var j = 0; j < _gameViewModel.M; j++)
				{
					_mainField[i, j] = new BoxView();
					
					Grid.SetRow(_mainField[i, j], i);
					Grid.SetColumn(_mainField[i, j], j);

					mainGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = 10 });
					mainGrid.Children.Add(_mainField[i, j]);
				}
			}
		}

		private void Draw()
		{
			Device.BeginInvokeOnMainThread(() =>
			{
				for (var i = 0; i < _gameViewModel.N; i++)
				{
					for (var j = 0; j < _gameViewModel.M; j++)
					{
						switch (_gameViewModel.Game.Field[i, j])
						{
							case CellType.Empty: _mainField[i, j].BackgroundColor = Color.Transparent; break;
							case CellType.Border: _mainField[i, j].BackgroundColor = Color.Black; break;
							case CellType.Figure: _mainField[i, j].BackgroundColor = Color.Red; break;
						}
					}
				}
			});
		}
	}
}