

namespace Otus.Console.Interactive
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading;
	using System.Threading.Tasks;
	class ComplexMenuDemo
	{

		/// <summary>
		/// Опции меню
		/// </summary>
		private static string[] options = new[]{
			"Новая игра",
			"Загрузить игру",
			"Сохранить Игру",
			"Настройки",
		};

		/// <summary>
		/// На одну строку вниз
		/// </summary>
		private static void SetDown()
		{
			if (selectedValue < options.Length - 1)
			{
				selectedValue++;
			}
		}

		/// <summary>
		/// На одну строку вверх
		/// </summary>
		private static void SetUp()
		{
			if (selectedValue > 0)
				selectedValue--;
		}

		/// <summary>
		/// Вывести меню
		/// </summary>
		private static void PrintMenu()
		{
			Console.WriteLine("Для выхода нажмие Escape");
			for (var i = 0; i < options.Length; i++)
			{
				Console.WriteLine($"{(selectedValue == i ? ">" : " ")} {i + 1}. {options[i]}");
			}
		}

		/// <summary>
		/// Исходное положение стрелки меню
		/// </summary>
		private static int selectedValue = 0;



		/// <summary>
		/// Запуск меню
		/// </summary>
		private static void Start()
		{
			ConsoleKeyInfo ki;
			do
			{
				PrintMenu();


				ki = Console.ReadKey();


				switch (ki.Key)
				{
					case ConsoleKey.UpArrow:
						SetUp();
						break;
					case ConsoleKey.DownArrow:
						SetDown();
						break;
				}
				Console.Clear();
			} while (ki.Key != ConsoleKey.Escape);

		}

		public static void Demo()
		{
			Clear();
			Krutilca();
			Start();
		}

		private static void Clear()
		{
			var i = 0;
			while (i < 10)
			{
				Console.WriteLine($"Строка под номеро {i++}");
			}

			Console.Write("Сейчас все очищу, нажмите любую клавищу");
			Console.ReadKey();
			Console.Clear();
		}


		/// <summary>
		/// Крутилка в консоли (демонстрация CursorPosition)
		/// </summary>
		private static void Krutilca()
		{
			var a = new char[] { '\\', '|', '/', '-' };

			Console.Write("\\ Начинаем крутится");
			var i = 0;
			do
			{
				Console.SetCursorPosition(0, Console.GetCursorPosition().Top);
				Console.Write(a[(i++) % 4]);
				Thread.Sleep(300);
				// Прокручиваем 12 раз
			} while (i < 12);
		}
	}
}
