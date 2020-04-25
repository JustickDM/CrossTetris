using System;

using Tetris.Enums;
using Tetris.Models.Figures;

namespace Tetris.Factories
{
	public class RandomFigureFactory : BaseFigureFactory
	{
		Random Random { get; } = new Random(DateTime.Now.Millisecond);

		public override FigureBase Create()
		{
			var figure = GetFigure();
			figure = Turn(figure);

			return figure;
		}
		
		private FigureBase GetFigure()
		{
			var figureType = (FigureType)Random.Next(Figures.Count);

			var figure = Figures[figureType]?.Invoke();

			return figure;
		}

		private FigureBase Turn(FigureBase figure)
		{
			var number = Random.Next(4);

			for (var i = 0; i < number; i++)
			{
				figure.Turn();
			}

			return figure;
		}
	}
}