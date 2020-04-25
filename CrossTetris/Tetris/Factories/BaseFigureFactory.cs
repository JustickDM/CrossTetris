using System;
using System.Collections.Generic;

using Tetris.Enums;
using Tetris.Models.Figures;

namespace Tetris.Factories
{
	public abstract class BaseFigureFactory : IFigureFactory
	{
		public Dictionary<FigureType, Func<FigureBase>> Figures { get; } = new Dictionary<FigureType, Func<FigureBase>>
		{
			[FigureType.T] = () => new T(),
			[FigureType.Q] = () => new Q(),
			[FigureType.I] = () => new I(),
			[FigureType.Z] = () => new Z(),
			[FigureType.S] = () => new S(),
			[FigureType.J] = () => new J(),
			[FigureType.L] = () => new L()
		};

		public abstract FigureBase Create();
	}
}