using Tetris.Enums;
using Tetris.Models.Figures;

namespace Tetris.Models
{
	/// <summary>
	/// Игровое поле
	/// </summary>
	public class Field
	{
		/// <summary>
		/// Высота игрового поля
		/// </summary>
		public int N { get; }

		/// <summary>
		/// Ширина игрового поля
		/// </summary>
		public int M { get; }

		/// <summary>
		/// Игровое поле
		/// </summary>
		public CellType[,] FieldArray { get; }

		public CellType this[int i, int j] => FieldArray[i, j];
		
		public Field(int n, int m)
		{
			N = n;
			M = m;

			FieldArray = new CellType[n, m];
		}

		/// <summary>
		/// Очистка заполненных уровней
		/// </summary>
		public int Remove()
		{
			var removeCount = 0;

			for (var i = 1; i < N - 1; i++)
			{
				var s = 0;

				for (var j = 1; j < M - 1; j++)
				{
					s += (int)FieldArray[i, j];
				}

				if (s == M - 2)
				{
					for (var i1 = i - 1; i1 > 0; i1--)
					{
						for (var j1 = 1; j1 < M - 1; j1++)
						{
							FieldArray[i1 + 1, j1] = FieldArray[i1, j1];
						}
					}

					removeCount++;
				}
			}

			return removeCount;
		}

		/// <summary>
		/// Установка на поле в соответствии с трафаретом фигуры значение v
		/// </summary>
		/// <param name="gameFieldsEnum"></param>
		public void SetUp(FigureBase figure, int y, int x, CellType cellType)
		{
			for (var i = 0; i < figure.N; i++)
			{
				for (var j = 0; j < figure.M; j++)
				{
					if (figure[i, j] == (int)CellType.Border)
					{
						FieldArray[y + i, x + j] = cellType;
					}
				}
			}
		}

		/// <summary>
		/// Проверка, можно ли поставить трафарет фигуры на игровое поле с координатой x, y
		/// </summary>
		/// <param name="x">Х координата текущей фигуры</param>
		/// <param name="y">У координата текущей фигуры</param>
		/// <returns>True - да, False - нет</returns>
		public bool IsCanSetUpFigure(FigureBase figure, int x, int y)
		{
			for (var i = 0; i < figure.N; i++)
			{
				for (var j = 0; j < figure.M; j++)
				{
					if (FieldArray[y + i, x + j] == CellType.Border && figure[i, j] == (int)CellType.Border)
					{
						return false;
					}
				}
			}

			return true;
		}

		/// <summary>
		/// Функция установки границ
		/// </summary>
		public void SetBorder()
		{
			for (var i = 0; i < M; i++)
			{
				FieldArray[0, i] = FieldArray[N - 1, i] = CellType.Border;
			}

			for (var i = 0; i < N; i++)
			{
				FieldArray[i, 0] = FieldArray[i, M - 1] = CellType.Border;
			}
		}

		/// <summary>
		/// Очистить игровое поле
		/// </summary>
		public void Clear()
		{
			for (var i = 1; i < N - 1; i++)
			{
				for (var j = 1; j < M - 1; j++)
				{
					FieldArray[i, j] = CellType.Empty;
				}
			}
		}
	}
}