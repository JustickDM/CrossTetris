using Tetris.Enums;

namespace Tetris.Models.Figures
{
	public class Z : FigureBase
	{
		public Z() : 
			base(new[,] 
			{ 
				{ 1, 1, 0 }, 
				{ 0, 1, 1 }
			}, FigureType.Z)
		{

		}
	}
}