
namespace Otus.Console.Interactive
{
	using System;

	public static class ReadDemo
	{
		public static void Demo()
		{
			ShowKeyInfo();
			Greetings();

			ShowRead();

			
			ShowReadLine();
			ShowCapitalized();
		}

		public static void ShowKeyInfo()
		{
			var longString = string.Empty;


			ConsoleKeyInfo key;
			do
			{
				Console.Write("Жду клавишу: ");
				key = Console.ReadKey();
				longString += key.KeyChar;
				Console.WriteLine($"\nВы нажали клавишу {key.Key}, у нее символ '{key.KeyChar}', были дополнительные кнопки? Вот: {key.Modifiers}");
				Console.WriteLine($"Строка теперь равна '{longString}'");

			} while (key.Key != ConsoleKey.Escape);
		}


		/// <summary>
		/// Демо для парсинга
		/// </summary>
		public static void Parse()
		{
			string s;
			do
			{
				s = Console.ReadLine();

				var number = int.Parse(s);

				Console.WriteLine($"{number} на 2 = {number / 2}");

			} while (s != string.Empty);
		}



		public static void ShowReadLine()
		{
			Console.Write("Введите целое число: ");
			var inputString = Console.ReadLine();

			int.Parse(inputString);

			int.TryParse(inputString, out var i);

			Console.WriteLine($"Вы ввели строку, если прибавим к ней 1 то получим {i + 1}"); ;
		}


		/// <summary>
		/// Демонстрация приведения к верхнему регистру
		/// </summary>
		public static void ShowCapitalized()
		{
			ConsoleKeyInfo c;
			do
			{
				Console.Write("Введите букву: ");
				c = Console.ReadKey();

				Console.Write($"Введите буквы: {char.ToUpper(c.KeyChar)}");
			} while (c.Key != ConsoleKey.Escape);
		}


		/// <summary>
		/// Демонстрация приведения к верхнему регистру
		/// </summary>
		public static void ShowRead()
		{
			char ch;
			Console.Write("Введите буквы: ");
			do
			{

				var c = Console.Read();
				Console.WriteLine();

				ch = Convert.ToChar(c);

				Console.Write($"Вы ввели букву '{ch}' у нее код по юникоду '{c}' ");
			} while (ch != '+');
		}

		/// <summary>
		/// Программа считывает строку пользователя, и выводит его текст
		/// </summary>
		public static void Greetings()
		{
			string username;
			Console.WriteLine("Приветствую тебя, Пользователь! Как тебя зовут?");
			Console.Write("Меня зовут: ");

			username = Console.ReadLine();

			Console.WriteLine($"Очень приятно, {username}! Рад знакомству!");

			Console.ReadKey();
			Console.WriteLine();
		}
	}
}
