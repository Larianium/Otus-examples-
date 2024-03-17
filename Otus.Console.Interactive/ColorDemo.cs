
namespace Otus.Console.Interactive
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	public static class ColorDemo
	{
		public static void Demo()
		{
			Console.WriteLine("Я обычный текст");

			// Делаем фон красным
			Console.BackgroundColor = ConsoleColor.Red;

			// А текст зеленым
			Console.ForegroundColor = ConsoleColor.Green;

			Console.WriteLine("А я зеленый на красном");
			Console.ResetColor();

			Console.WriteLine("Я снова в обычном режиме");
		}
	}
}
