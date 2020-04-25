using Tetris.Enums;

namespace Tetris.Models.Figures
{
	public class L : FigureBase
	{
		public L() : 
			base(new[,] 
			{ 
				{ 1, 0, 0 }, 
				{ 1, 1, 1 }
			}, FigureType.L)
		{

		}
	}
}