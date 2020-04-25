using System;
using System.Timers;

using Tetris.Enums;
using Tetris.Factories;
using Tetris.Models.Figures;

namespace Tetris.Models
{
	public class Game
	{
		#region Public properties

		/// <summary>
		/// Скорость ускорения падения фигуры
		/// </summary>
		public int DownSpeed { get; }

		public Field Field { get; }

		public IFigureFactory FigureFactory { get; }

		/// <summary>
		/// Счёт игрока
		/// </summary>
		public int PlayerScore { get; private set; }

		/// <summary>
		/// Следующая фигура
		/// </summary>
		public FigureBase NextFigure { get; private set; }

		/// <summary>
		/// Конец игры
		/// </summary>
		public bool IsEndGame { get; private set; }

		/// <summary>
		/// Указывает, находится ли игра на паузе
		/// </summary>
		public bool IsPaused => !IsEndGame && !_timer.Enabled;

		#endregion

		#region Private fields

		private int _x, _y;				// Координаты левого верхнего угла падающей фигуры на игровом поле
		private FigureBase _figure;		// Текущая фигура
		private int _speed;				// Скорость падения фигуры

		private Timer _timer;			// Таймер, управляющий игрой

		#endregion

		#region Events

		public event Action FieldChanged;

		#endregion

		public Game(int n = 18, int m = 14, int speed = 1000, int downSpeed = 200)
		{
			Field = new Field(n, m);
			Field.SetBorder();

			FigureFactory = new RandomFigureFactory();

			DownSpeed = downSpeed;
			_speed = speed;

			_timer = new Timer(speed);
			_timer.Elapsed += (sender, e) => MakeIteration();
		}

		#region Public methods

		/// <summary>
		/// Перезапуск игры
		/// </summary>
		public void Restart()
		{
			Field.Clear();

			_figure = FigureFactory.Create();
			NextFigure = FigureFactory.Create();

			_x = (Field.M - _figure.M) / 2;
			_y = 1;

			PlayerScore = 0;

			FieldChanged?.Invoke();

			_timer.Start();
		}

		/// <summary>
		/// Функция опускания фигуры на единицу и проверка упала или еще летит
		/// </summary>
		public void MakeIteration()
		{
			IsEndGame = GetIsEndGame();

			if (!IsEndGame)
			{
				if (Field.IsCanSetUpFigure(_figure, _x, _y + 1))
				{
					Field.SetUp(_figure, _y, _x, CellType.Empty);
					_y++;
					Field.SetUp(_figure, _y, _x, CellType.Figure);
				}
				else
				{
					Field.SetUp(_figure, _y, _x, CellType.Border);
					_timer.Interval = _speed;

					PlayerScore += Field.Remove();

					_figure = NextFigure;

					_x = (Field.M - _figure.M) / 2;
					_y = 1;

					NextFigure = FigureFactory.Create();
				}

				FieldChanged?.Invoke();
			}
		}

		/// <summary>
		/// Действие пользователя на очередной итерации
		/// </summary>
		/// <param name="position">Тип действия</param>
		public void Action(ActionType action)
		{
			switch (action)
			{
				case ActionType.Down:
					_timer.Interval = DownSpeed;
					break;
				case ActionType.Left:
					if (Field.IsCanSetUpFigure(_figure, _x - 1, _y))
					{
						Field.SetUp(_figure, _y, _x, CellType.Empty);
						_x--;
						Field.SetUp(_figure, _y, _x, CellType.Figure);
					}
					break;
				case ActionType.Right:
					if (Field.IsCanSetUpFigure(_figure, _x + 1, _y))
					{
						Field.SetUp(_figure, _y, _x, CellType.Empty);
						_x++;
						Field.SetUp(_figure, _y, _x, CellType.Figure);
					}
					break;
				case ActionType.TurnRight:
					Field.SetUp(_figure, _y, _x, CellType.Empty);
					_figure.Turn(true);
					if (Field.IsCanSetUpFigure(_figure, _x, _y))
					{
						Field.SetUp(_figure, _y, _x, CellType.Figure);
					}
					else
					{
						_figure.Turn(false);
						Field.SetUp(_figure, _y, _x, CellType.Figure);
					}
					break;
				case ActionType.TurnLeft:
					Field.SetUp(_figure, _y, _x, CellType.Empty);
					_figure.Turn(false);
					if (Field.IsCanSetUpFigure(_figure, _x, _y))
					{
						Field.SetUp(_figure, _y, _x, CellType.Figure);
					}
					else
					{
						_figure.Turn(true);
						Field.SetUp(_figure, _y, _x, CellType.Figure);
					}
					break;
			}

			FieldChanged?.Invoke();
		}

		public void Pause()
		{
			if (IsPaused)
			{
				_timer.Start();
			}
			else
			{
				_timer.Stop();
			}
		}

		public void Exit()
		{
			IsEndGame = true;
			_timer.Stop();
		}

		#endregion

		#region Private methods

		/// <summary>
		/// Проверка на конец игры
		/// </summary>
		/// <returns></returns>
		private bool GetIsEndGame()
		{
			if (Field.IsCanSetUpFigure(_figure, _x, _y))
			{
				Field.SetUp(_figure, _y, _x, CellType.Figure);
				return false;
			}

			_timer.Stop();
			return true;
		}

		#endregion
	}
}
