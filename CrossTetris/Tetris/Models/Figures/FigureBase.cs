﻿using Tetris.Enums;

namespace Tetris.Models.Figures
{
	public abstract class FigureBase
	{
		public int[,] FigureArray { get; private set; }
		public int N { get; private set; }
		public int M { get; private set; }
		public FigureType FigureType { get; }

		public int this[int i, int j] => FigureArray[i, j];

		public FigureBase(int[,] figureArray, FigureType figureType)
		{
			FigureArray = figureArray;
			N = figureArray.GetLength(0);
			M = figureArray.GetLength(1);
			FigureType = figureType;
		}

		/// <summary>
		/// Функция поворота фигуры (isСlockwise = true - по часовой стрелке, isСlockwise = false - против часовой стрелки)
		/// </summary>
		/// <param name="isСlockwise">Режим поворота</param>
		public void Turn(bool isСlockwise = true)
		{
			var temp = new int[M, N];

			for (var i = 0; i < N; i++)
			{
				for (var j = 0; j < M; j++)
				{
					if (isСlockwise)
					{
						temp[j, N - i - 1] = FigureArray[i, j];
					}
					else
					{
						temp[M - j - 1, i] = FigureArray[i, j];
					}
				}
			}

			var r = N; N = M; M = r;
			FigureArray = temp;
		}
	}
}