using CrossTetris.ViewModels.Base;

using Tetris.Enums;
using Tetris.Models;

using Xamarin.Forms;

namespace CrossTetris.ViewModels
{
	public sealed class GameViewModel : BaseViewModel
	{
		private Game _game;
		public Game Game
		{
			get => _game;
			set => SetProperty(ref _game, value);
		}

		private int _n = 18;
		public int N
		{
			get => _n;
			set => SetProperty(ref _n, value);
		}

		private int _m = 12;
		public int M
		{
			get => _m;
			set => SetProperty(ref _m, value);
		}

		private int _speed = 500;
		public int Speed
		{
			get => _speed;
			set => SetProperty(ref _speed, value);
		}

		private int _downSpeed = 100;
		public int DownSpeed
		{
			get => _downSpeed;
			set => SetProperty(ref _downSpeed, value);
		}

		private int _playerScore;
		public int PlayerScore
		{
			get => _playerScore;
			set => SetProperty(ref _playerScore, value);
		}

		public Command ExitCommand { get; set; }
		public Command StartCommand { get; set; }
		public Command RestartCommand { get; set; }
		public Command PauseCommand { get; set; }
		public Command DownCommand { get; set; }
		public Command LeftCommand { get; set; }
		public Command RightCommand { get; set; }
		public Command TurnLeftCommand { get; set; }
		public Command TurnRightCommand { get; set; }

		public GameViewModel()
		{
			Game = new Game(N, M, Speed, DownSpeed);

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
			PauseCommand = new Command(() =>
			{
				if (!Game.IsEndGame)
				{
					Game.Pause();
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
		}
	}
}