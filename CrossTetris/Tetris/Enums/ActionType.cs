namespace Tetris.Enums
{
	/// <summary>
	/// Тип действия
	/// </summary>
	public enum ActionType
	{
		/// <summary>
		/// Увеличение скорости падения фигуры
		/// </summary>
		Down,

		/// <summary>
		/// Смещение фигуры влево
		/// </summary>
		Left,

		/// <summary>
		/// Смещение фигуры вправо
		/// </summary>
		Right,

		/// <summary>
		/// Поворот фигуры против часовой стрелки
		/// </summary>
		TurnLeft,

		/// <summary>
		/// Поворот фигуры по часовой стрелке
		/// </summary>
		TurnRight,
	}
}