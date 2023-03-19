using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{  
    internal class Program
    {
        static void DrawingPlayingField(int FieldSize, char[,] ValuesInPlayingField)
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
                    Console.Write($"[{ValuesInPlayingField[i, j]}]");
                }
                Console.WriteLine();
            }
            return;
        }

        static bool WinCheck(char[,] ValuesInPlayingField,char Znak)
        {
            int CounterVictory;
            for (int i = 0; i < ValuesInPlayingField.GetLength(0); i++)
            {
                CounterVictory = 0;
                for (int j = 0; j < ValuesInPlayingField.GetLength(1); j++)
                {
                    if (ValuesInPlayingField[i, j] == Znak)
                    {
                        CounterVictory++;
                    }
                    if (CounterVictory == ValuesInPlayingField.GetLength(0))
                    {
                        return true;
                    }
                }

            }
            for (int i = 0; i < ValuesInPlayingField.GetLength(0); i++)
            {
                CounterVictory = 0;
                for (int j = 0; j < ValuesInPlayingField.GetLength(1); j++)
                {
                    if (ValuesInPlayingField[j, i] == Znak)
                    {
                        CounterVictory++;
                    }
                    if (CounterVictory == ValuesInPlayingField.GetLength(0))
                    {
                        return true;
                    }
                }
            }
            CounterVictory = 0;
            for (int i = 0; i < ValuesInPlayingField.GetLength(0); i++)
            {
                if (ValuesInPlayingField[i, i] == Znak)
                {
                    CounterVictory++;
                }
                if (CounterVictory == ValuesInPlayingField.GetLength(0))
                {
                    return true;
                }
            }
            CounterVictory = 0;
            for (int i = ValuesInPlayingField.GetLength(0) - 1; i >= 0; i--)
            {
                if (ValuesInPlayingField[i, i] == Znak)
                {
                    CounterVictory++;
                }
                if (CounterVictory == ValuesInPlayingField.GetLength(0))
                {
                    return true;
                }
            }
            return false;
        }

        static bool CheckIsCellFree(char[,] ValuesInPlayingField, int VerticalCoordinate, int HorizontalСoordinate)
        {
            if (ValuesInPlayingField[VerticalCoordinate - 1, HorizontalСoordinate - 1] == '\0')
            { 
                return true; 
            }
            else
            {
                return false;
            }
                
        }

            static void Main(string[] args)
        {
            int FieldSize;
            int CounterToDraw = 0;
            int VerticalCoordinate, HorizontalСoordinate;
            char SignСheck;
            char[,] ValuesInPlayingField;
            bool GameOver = false;
            bool IsCellFree = false;
            
            do
            {
                Console.Clear();
                Console.WriteLine("Введите размер поля, для игры: ");
                int.TryParse(Console.ReadLine(), out FieldSize);
            } while (FieldSize == 0);
            Console.Clear();
            ValuesInPlayingField = new char[FieldSize, FieldSize];
            DrawingPlayingField(FieldSize,ValuesInPlayingField);
            Console.WriteLine();

            do
            {
                do
                {
                    Console.WriteLine("\nХодит первый игрок!");
                    
                    do
                    {
                        Console.Write("\nВведите координату по вертикали: ");
                        int.TryParse(Console.ReadLine(), out VerticalCoordinate);
                    } while (VerticalCoordinate == 0 || VerticalCoordinate > FieldSize);
                    Console.WriteLine();
                    do
                    {
                        Console.Write("Введите координату по горизонтали: ");
                        int.TryParse(Console.ReadLine(), out HorizontalСoordinate);
                    } while (HorizontalСoordinate == 0 || HorizontalСoordinate > FieldSize);
                    if (CheckIsCellFree(ValuesInPlayingField, VerticalCoordinate, HorizontalСoordinate))
                    {
                        IsCellFree = true;
                        ValuesInPlayingField[VerticalCoordinate - 1, HorizontalСoordinate - 1] = 'X';
                    }
                } while (IsCellFree == false);
                Console.Clear();
                DrawingPlayingField(FieldSize, ValuesInPlayingField);
                Console.WriteLine();
                SignСheck = 'X';
                if (WinCheck(ValuesInPlayingField, SignСheck))
                {
                    GameOver = true;
                    break;
                }
                CounterToDraw++;
                if (CounterToDraw == FieldSize * FieldSize)
                {
                    Console.WriteLine("Ничья!!! =(");
                    break;
                }

                IsCellFree = false;
                do
                {
                    Console.WriteLine("\nХодит второй игрок!");
                    do
                    {
                        Console.Write("\nВведите координату по вертикали: ");
                        int.TryParse(Console.ReadLine(), out VerticalCoordinate);
                    } while (VerticalCoordinate == 0 || VerticalCoordinate > FieldSize);
                    Console.WriteLine();
                    do
                    {
                        Console.Write("Введите координату по горизонтали: ");
                        int.TryParse(Console.ReadLine(), out HorizontalСoordinate);
                    } while (HorizontalСoordinate == 0 || HorizontalСoordinate > FieldSize);
                    if (CheckIsCellFree(ValuesInPlayingField, VerticalCoordinate, HorizontalСoordinate))
                    {
                        IsCellFree = true;
                        ValuesInPlayingField[VerticalCoordinate - 1, HorizontalСoordinate - 1] = 'O';
                    }

                } while (IsCellFree == false);

                Console.Clear();
                DrawingPlayingField(FieldSize, ValuesInPlayingField);
                SignСheck = 'O';
                if (WinCheck(ValuesInPlayingField, SignСheck))
                {
                    GameOver = true;
                    break;
                }
                CounterToDraw++;

            } while (GameOver == false);
            if (SignСheck == 'O')
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
