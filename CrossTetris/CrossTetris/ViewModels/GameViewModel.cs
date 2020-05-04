using CrossTetris.ViewModels.Base;
using CrossTetris.Views.Popups;

using Rg.Plugins.Popup.Services;

using Tetris.Enums;
using Tetris.Models;

using Xamarin.Forms;

namespace CrossTetris.ViewModels
{
	public sealed class GameViewModel : BaseViewModel
	{
		public Game Game { get; }

		public int N { get; } = 18;

		public int M { get; } = 12;

		public int Speed { get; } = 500;

		public int DownSpeed { get; } = 100;

		private int _playerScore;
		public int PlayerScore
		{
			get => _playerScore;
			set => SetProperty(ref _playerScore, value);
		}

		public Command ExitCommand { get; }
		public Command StartCommand { get; }
		public Command RestartCommand { get; }
		public Command PauseCommand { get; }
		public Command DownCommand { get; }
		public Command LeftCommand { get; }
		public Command RightCommand { get; }
		public Command TurnLeftCommand { get; }
		public Command TurnRightCommand { get; }

		public GameViewModel()
		{
			Game = new Game(N, M, Speed, DownSpeed);
			Game.PlayerScoreChanged += () => PlayerScore = Game.PlayerScore;

			ExitCommand = new Command(() =>
			{
				if(!Game.IsEndGame)
				{
					Game.Exit();
				}
			});
			StartCommand = new Command(() =>
			{
				if (!Game.IsEndGame)
				{
					Game.Restart();
				}
			});
			RestartCommand = new Command(() =>
			{
				Game.Restart();
			});
			PauseCommand = new Command(async () =>
			{
				if (!Game.IsEndGame)
				{
					Game.Pause();

					await PopupNavigation.Instance.PushAsync(new GamePausedView());
					//await Xamarin.Essentials.TextToSpeech.SpeakAsync("Игра на паузе, Motherfucker!");
				}
			});
			DownCommand = new Command(() =>
			{
				if (!Game.IsEndGame)
				{
					Game.Action(ActionType.Down);
				}
			});
			LeftCommand = new Command(() =>
			{
				if (!Game.IsEndGame)
				{
					Game.Action(ActionType.Left);
				}
			});
			RightCommand = new Command(() =>
			{
				if (!Game.IsEndGame)
				{
					Game.Action(ActionType.Right);
				}
			});
			TurnLeftCommand = new Command(() =>
			{
				if (!Game.IsEndGame)
				{
					Game.Action(ActionType.TurnLeft);
				}
			});
			TurnRightCommand = new Command(() =>
			{
				if (!Game.IsEndGame)
				{
					Game.Action(ActionType.TurnRight);
				}
			});

			MessagingCenter.Subscribe<GamePausedView>(this, MessagesEnum.Unpause, (obj) =>
			{
				if (!Game.IsEndGame)
				{
					Game.Pause();
				}
			});
		}
	}
}