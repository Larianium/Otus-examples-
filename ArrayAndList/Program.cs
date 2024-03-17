using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Otus.ArrayAndList
{

	/// <summary>
	/// Более правдоподобная реализация списка :)
	/// </summary>
	/// <typeparam name="T"></typeparam>
	class MyList<T>
	{
		/// <summary>
		/// Элемент списка
		/// </summary>
		/// <typeparam name="T"></typeparam>
		public class Node<T>
		{
			public T Value;

			public Node<T> Next = null;
		}


		public Node<T> _first = null;

		public Node<T> _last = null;

		public int Size { get; private set; } = 0;


		public T this[int index]
		{
			get
			{
				Node<T> current = _first;
				for (var i = 0; i < index; i++)
				{
					current = current.Next;
				}
				return current == null ? default : current.Value;
			}
		}
		public void Add(T value)
		{
			var newNode = new Node<T> { Value = value };
			if (Size == 0)
			{
				_first = newNode;
				_last = newNode;
			}
			else
			{
				_last.Next = newNode;
				_last = newNode;
			}
			Size++;
		}





	}

	public class Bar
	{
		public Bar(int a)
		{
			A = a;
		}
		public int A;

		public override string ToString()
		{
			return $"{{ A = {A} }} ";
		}


	}


	class Program
	{
		static void Main(string[] args)
		{


			

			BaseArrays();
			
			Listdefault();


			SumList();
			ReferenceListDemo();





			LinkedList();

			Cycles();

		}

		/// <summary>
		/// Демонстрация методов списков
		/// </summary>
		private static void Listdefault()
		{
			var list = new List<int> { 1, 2, 3, 4, 5, 6 };
			PrintList(list);
			list.Add(7);
			PrintList(list);
			list.Insert(1, 888);
			PrintList(list);

			list.Insert(4, 7);

			PrintList(list);
			list.Insert(4, 7);
			PrintList(list);

			list.Remove(7);
			PrintList(list);


			Console.WriteLine("Удалим четные числа");
			list.RemoveAll(x => x % 2 == 0);
			PrintList(list);


			list.RemoveAt(0);

			PrintList(list);


			list.Add(444);
			list.Add(444);
			list.Add(444);
			list.Add(444);
			list.Add(444);
			list.Add(444);

			PrintList(list);
			Console.WriteLine("Удаляем рэндж");
			list.RemoveRange(2, 3);
			Console.WriteLine("Удалили");
			PrintList(list);

			list.AddRange(new[] { 999, 333, 1124124 });
			PrintList(list);
			list.Clear();
			PrintList(list);
		}

		/// <summary>
		///  Демонстрация того, как можно менять ссылочные поля в списка
		/// </summary>
		private static void ReferenceListDemo()
		{
			var l1 = new List<Bar> { new Bar(1), new Bar(2), new Bar(3) };

			var l2 = new List<Bar> {
				l1[0],
				l1[1],
				l1[2], };

			PrintList(l1, "l1");
			PrintList(l2, "l2");

			l1.Add(new Bar(4));

			Console.WriteLine();
			PrintList(l1, "l1");
			PrintList(l2, "l2");

			l1[1] = new Bar(1000);

			Console.WriteLine();
			PrintList(l1, "l1");
			PrintList(l2, "l2");
		}

		/// <summary>
		/// Циклы
		/// </summary>
		private static void Cycles()
		{
			var ar = new[] { 11, 22, 33, 44, 55 };

			Console.WriteLine("foreach");

			foreach (var jjj in ar)
			{
				Console.WriteLine($"{jjj} + 100 = {jjj + 100}");
			}


			Console.WriteLine();
			Console.WriteLine(); Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine(); Console.WriteLine();

			var matrix1 = new[,]
			{
				{1,2,3,4 },
				{5,3242346,7,8 },
				{9,10111,11,114122 },
			};

			for (var i = 0; i < matrix1.GetLength(0); i++)
			{
				for (var j = 0; j < matrix1.GetLength(1); j++)
				{
					Console.WriteLine($"i = {matrix1[i, j]}");
				}
			}

			Console.WriteLine($"=================");
			foreach (var i in matrix1)
			{
				Console.WriteLine($"i = {i}");
			}


			PrintOneColumn(matrix1, 0);
		}

		/// <summary>
		/// Двунаправленный список
		/// </summary>
		private static void LinkedList()
		{
			var ll = new LinkedList<int>();
			PrintLinkedList(ll);
			var f = ll.AddLast(1);
			ll.AddLast(2);
			ll.AddLast(3);
			PrintLinkedList(ll);

			ll.AddFirst(4);
			PrintLinkedList(ll);
			var n = ll.AddLast(777);
			PrintLinkedList(ll);
			var qq = ll.AddBefore(n, 8888);
			PrintLinkedList(ll);
			ll.AddAfter(qq, 99999);
			PrintLinkedList(ll);






			//l = [(1), (2), (3), (4), (5)]
			// var n = l.AddLast(6)
			// 
			//                                n 
			//l =  [(1), (2), (3), (4), (5), (6)]
			//var f=  l.AddBefore(n, 7);
			//                                f  <- n 
			//l =  [(1), (2), (3), (4), (5), (7),  (6)]

		}

		/// <summary>
		/// Метод работы со списками
		/// </summary>
		private static void SumList()
		{
			// заводим пустой список
			var list = new List<int>();

			// считываем значения введеные пользователями
			var s = Console.ReadLine();
			while (s != string.Empty)
			{
				// Переводим строку в числов
				var chislo = int.Parse(s);
				list.Add(chislo);

				s = Console.ReadLine();
			}


			var sum = 0;
			// Суммируем все значения из спика
			for (var i = 0; i < list.Count; i++)
			{
				sum += list[i];
				Console.Write($"{list[i]} + ");
			}
			Console.WriteLine($"= {sum}");
		}

		/// <summary>
		/// Базовая работа с массивами
		/// </summary>
		/// <returns></returns>
		private static void BaseArrays()
		{
			// Выводим значения по умолчанию
			// (можно заменить BAR на int)
			var bar = new int[5];

			Console.WriteLine($"Длина массива bars = {bar.Length}");
			bar[4] = 10;// new Bar(100);

			for (var i = 0; i < bar.Length; i++)
			{
				Console.WriteLine($"[{i}] = {(bar[i] == null ? "null" : bar[i])}");
			}



			// Одномерный массив
			var longLength = new int[6 * 5];



			// Двумерный массив
			var matrix = new int[6, 5];


			// трехмерный массив
			var cuber = new int[6, 5, 8];


			PrintRank(longLength);
			PrintRank(matrix);
			PrintRank(cuber);
			Console.WriteLine();
			Console.WriteLine();

			PrintMatrix(matrix);


			matrix[4, 2] = 10;

			PrintMatrix(matrix);

			// Заводим двумерный массив 
			// со значениями по умолчанию
			var ar = new[,]
				{
					{ 1,3,4,4 },
					{ 2,3,4,6 },
					{ 5,6,3,6 }
				};

			PrintMatrix(ar);

			// Массив массивов (1-й уровень - три элемента)
			int[][] multi = new int[3][];



			multi[0] = new int[4];
			multi[1] = new int[10];
			multi[2] = new int[7];

			for (var i = 0; i < multi.Length; i++)
			{
				for (var j = 0; j < multi[i].Length; j++)
				{
					Console.Write($"{ multi[i][j]  } ");
				}
				Console.WriteLine();
			}



			var arrayOfMatrixes = new int[3][,];
			arrayOfMatrixes[0] = new int[2, 3];
			arrayOfMatrixes[1] = new int[3, 6];
			arrayOfMatrixes[2] = new int[5, 9];

			Console.WriteLine();
			Console.WriteLine(); Console.WriteLine(); Console.WriteLine(); Console.WriteLine(); Console.WriteLine(); Console.WriteLine(); Console.WriteLine();
			for (var i = 0; i < arrayOfMatrixes.Length; i++)
			{
				Console.WriteLine("----------------");
				PrintMatrix(arrayOfMatrixes[i]);
				Console.WriteLine("----------------");
			}


		}

		private static void PrintOneColumn(int[,] ar, int columnIndex)
		{

			for (var i = 0; i < ar.GetLength(0); i++)
			{

				Console.Write($"[{i},{columnIndex}] = {ar[i, columnIndex]} ");

				Console.WriteLine();
			}
		}

		private static void PrintList<T>(List<T> list, string Name = "")
		{
			if (Name != string.Empty)
			{
				Console.Write($"{Name}=");
			}
			Console.Write("[");
			for (var i = 0; i < list.Count; i++)
			{
				Console.Write($"{list[i]}, ");
			}
			Console.WriteLine("]");
		}


		private static void PrintLinkedList<T>(LinkedList<T> list, string Name = "")
		{
			if (Name != string.Empty)
			{
				Console.Write($"{Name}=");
			}
			var l = list.First;
			while (l != null)
			{
				Console.Write($"{l.Value}, ");
				l = l.Next;
			}


			Console.WriteLine("]");
		}
		public static void PrintMatrix(int[,] array)
		{


			Console.WriteLine("====================");
			for (var i = 0; i < array.GetLength(0); i++)
			{
				for (var j = 0; j < array.GetLength(1); j++)
				{
					Console.Write($"{array[i, j]} ");
				}

				Console.WriteLine();
			}

			Console.WriteLine("====================");
		}


		static void PrintRank(Array a)
		{
			Console.WriteLine($"Размерность массива у нас равна {a.Rank}");
		}

	}
}