using Tetris.Enums;

namespace Tetris.Models.Figures
{
	public class Q : FigureBase
	{
		public Q() : 
			base(new[,] 
			{ 
				{ 1, 1 }, 
				{ 1, 1 }
			}, FigureType.Q)
		{

		}
	}
}