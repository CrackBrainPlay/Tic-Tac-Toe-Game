using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{  
    internal class Program
    {
        static void PlayingField(int FieldSize, char[,] myArray)
        {
            Console.Write("  ");
            for (int j = 0; j < FieldSize; j++)
            {
                Console.Write($" {j + 1} ");
            }
            Console.WriteLine();
            for (int i = 0; i < FieldSize; i++)
            {
                Console.Write($"{i + 1} ");
                for (int j = 0; j < FieldSize; j++)
                {
                    Console.Write($"[{myArray[i, j]}]");
                }
                Console.WriteLine();
            }
            return;
        }

        static bool CheckWin(char[,] myArray,char Znak)
        {
            int Counter = 0;
            bool WIN = false;
            for (int i = 0; i < myArray.GetLength(0); i++)
            {
                Counter = 0;
                for (int j = 0; j < myArray.GetLength(1); j++)
                {
                    if (myArray[i, j] == Znak)
                    {
                        Counter += 1;
                    }
                    if (Counter == myArray.GetLength(0))
                    {
                        WIN = true;
                        return WIN;
                    }
                }

            }
            for (int i = 0; i < myArray.GetLength(0); i++)
            {
                Counter = 0;
                for (int j = 0; j < myArray.GetLength(1); j++)
                {
                    if (myArray[j, i] == Znak)
                    {
                        Counter += 1;
                    }
                    if (Counter == myArray.GetLength(0))
                    {
                        WIN = true;
                        return WIN;
                    }
                }
            }
            Counter = 0;
            for (int i = 0; i < myArray.GetLength(0); i++)
            {
                if (myArray[i, i] == Znak)
                {
                    Counter += 1;
                }
                if (Counter == myArray.GetLength(0))
                {
                    WIN = true;
                    return WIN;
                }
            }
            Counter = 0;
            for (int i = myArray.GetLength(0) - 1; i >= 0; i--)
            {
                if (myArray[i, i] == Znak)
                {
                    Counter += 1;
                }
                if (Counter == myArray.GetLength(0))
                {
                    WIN = true;
                    return WIN;
                }
            }

            return WIN;
        }

        

            static void Main(string[] args)
        {
            int FieldSize;
            string str;
            bool Win;
            char[,] myArray;
            int x, y;
            bool GameOver = false;
            char Znak;
            int CounterToDraw = 0;
            Console.WriteLine("Введите размер поля, для игры: ");
            str = Console.ReadLine();
            Console.Clear();
            FieldSize = int.Parse(str);
            myArray = new char[FieldSize, FieldSize];
            PlayingField(FieldSize,myArray);
            Console.WriteLine();

            bool check = false;
            do
            {
                do
                {
                    Console.WriteLine("\nХодит первый игрок!");
                    Console.Write("\nВведите координату по вертикали: ");
                    x = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    Console.Write("Введите координату по горизонтали: ");
                    y = int.Parse(Console.ReadLine());
                    if (myArray[x - 1, y - 1] == '\0')
                    {
                        check = true;
                        myArray[x - 1, y - 1] = 'X';
                    }
                } while (check == false);
                Console.Clear();
                PlayingField(FieldSize, myArray);
                Console.WriteLine();
                Znak = 'X';
                Win = CheckWin(myArray,Znak);
                if (Win == true)
                {
                    GameOver = true;
                    break;
                }
                CounterToDraw += 1;
                if (CounterToDraw == FieldSize * FieldSize)
                {
                    Console.WriteLine("Ничья! =(");
                    break;
                }

                check = false;
                do
                {
                    Console.WriteLine("\nХодит второй игрок!");
                    Console.Write("\nВведите координату по вертикали: ");
                    x = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    Console.Write("Введите координату по горизонтали: ");
                    y = int.Parse(Console.ReadLine());
                    if (myArray[x - 1, y - 1] == '\0')
                    {
                        check = true;
                        myArray[x - 1, y - 1] = 'O';
                    }

                } while (check == false);

                Console.Clear();
                PlayingField(FieldSize, myArray);
                Znak = 'O';
                Win = CheckWin(myArray, Znak);
                if (Win == true)
                {
                    GameOver = true;
                    break;
                }
                CounterToDraw += 1;

            } while (GameOver == false);
            if (Znak == 'O')
            {
                Console.WriteLine("Победил второй игрок!!!!");
            }
            else
            {
                Console.WriteLine("Победил первый игрок!!!!");
            }
            Console.ReadLine();
        }
    }
}
