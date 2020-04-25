using Tetris.Models.Figures;

namespace Tetris.Factories
{
	public interface IFigureFactory
	{
		FigureBase Create();
	}
}