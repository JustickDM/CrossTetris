using Tetris.Enums;

namespace Tetris.Models.Figures
{
	public class I : FigureBase
	{
		public I() : 
			base(new[,] 
			{ 
				{ 1, 1, 1, 1 }
			}, FigureType.I)
		{

		}
	}
}