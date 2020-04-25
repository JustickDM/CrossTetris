using Tetris.Enums;

namespace Tetris.Models.Figures
{
	public class J : FigureBase
	{
		public J() : 
			base(new[,] 
			{ 
				{ 1, 1, 1 }, 
				{ 1, 0, 0 }
			}, FigureType.J)
		{

		}
	}
}