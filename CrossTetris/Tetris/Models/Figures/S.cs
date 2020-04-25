using Tetris.Enums;

namespace Tetris.Models.Figures
{
	public class S : FigureBase
	{
		public S() : 
			base(new[,] 
			{ 
				{ 0, 1, 1 }, 
				{ 1, 1, 0 }
			}, FigureType.S)
		{

		}
	}
}