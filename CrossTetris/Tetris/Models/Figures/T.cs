using Tetris.Enums;

namespace Tetris.Models.Figures
{
	public class T : FigureBase
	{
		public T() : 
			base(new[,] 
			{ 
				{ 1, 1, 1 }, 
				{ 0, 1, 0 }
			}, FigureType.T)
		{

		}
	}
}