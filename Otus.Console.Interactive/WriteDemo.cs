
namespace Otus.Console.Interactive
{
	using System;
	using System.Threading;

	public class SimpleClass
	{
		private int _a;
		public SimpleClass(int a)
		{
			_a = a;
		}


		/// <summary>
		/// Когда объекта класс SimpleClass выводим в Console.WriteLine
		/// Вызывается этот метод
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return $"{{ \"a\": {_a} }}";
		}
	}

	/// <summary>
	/// Класс для демонстрации вывода данных
	/// </summary>
	public static class WriteDemo
	{


		public static void Demo()
		{
			Simple();
			Formatted();
		}

		/// <summary>
		/// Простой вывод данныех
		/// </summary>
		private static void Simple()
		{
			Console.WriteLine("Выводим обычный текст с переводом строки");


			Console.Write("Привет,");
			Console.Write(" Otus!");


			Console.ReadKey();
			Console.WriteLine();


			var obj = new SimpleClass(4);

			Console.WriteLine("1. Я пишу текст '{0}' и число {1} и даже объект {2}",
								"Привет", 2, obj);




			Console.WriteLine($"2. Я пишу текст '{"Привет"}' и число {2} и даже объект {obj}");


			Console.ReadKey();
		}

		/// <summary>
		/// Форматируемый вывод
		/// </summary>
		private static void Formatted()
		{
			Console.WriteLine($"Вот дата обычная {DateTime.Now}");
			Console.WriteLine($"Вот дата форматируемая {DateTime.Now:MM'/'dd'/'yyyy HH:mm}");

			Console.WriteLine($"Выводим 4 знака после запятой {12.34567890:n4}");
			Console.WriteLine($"Выводим с валютой согласно языку операционной системы {100:C}");
			Console.WriteLine($"Шестнадцатиричной системой {243:X}");


			Console.WriteLine($"День недели {DateTime.Now:dddd}");

			Console.ReadKey();
		}




	}
}
