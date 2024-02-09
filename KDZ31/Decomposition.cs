using Libruary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static KDZ31.Decomposition;

namespace KDZ31
{
    /// <summary>
    /// Класс для декомпозиции основной программы.
    /// Class for decimposition main program.
    /// </summary>
    internal static class Decomposition
    {
        private enum InputOption
        {
            stdin = ConsoleKey.D1,
            filein = ConsoleKey.D2,
        }
        private enum OutputOption
        {
            stdout = ConsoleKey.D1,
            fileout = ConsoleKey.D2,
        }
        private enum ActionWithData 
        {
             Sort = ConsoleKey.D1,
             Sample = ConsoleKey.D2
        }
        public static void Solve()
        {
            List<Record> data = new List<Record>();

            try
            {  
                Menu.TypeFileIn();
                InData(ref data);

                Menu.GetMenu();
                List<Record> modifiedData = Action(ref data);

                Menu.TypeFileOut();
                OutData(ref modifiedData);
                Menu.Repeat();
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Такого действия нет.");
                throw new ArgumentOutOfRangeException();
            }
            catch (FileLoadException ) 
            {
                Console.WriteLine("Данные некорректные.");
                throw new FileLoadException();
            }
            catch (FormatException)
            {
                Console.WriteLine("Данные некорректные.");
                throw new FileLoadException();
            }

        }
        // Метод для выбора способа ввода данных.
        // Method for selecting the data entry method.
        private static void InData( ref List<Record> data)
        {
            InputOption x = (InputOption)(Console.ReadKey().Key);
            Console.WriteLine();
            switch (x)
            {
                case (InputOption.stdin):
                    data = Std.ReadLinesFromConsole();
                    break;
                case (InputOption.filein):
                    Menu.SetPath(false);
                    data = JsonParser.ReadJson();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            };
        }

        // Метод для выбора способа вывода данных.
        // Method for selecting the data output method.
        private static void OutData(ref List<Record> data)
        {
            OutputOption x = (OutputOption)(Console.ReadKey().Key);
            Console.WriteLine();
            switch (x)
            {
                case (OutputOption.stdout):
                    Menu.WriteLinesToConsole(ref data);
                    break;
                case (OutputOption.fileout):
                    Menu.ChooseOutputType();
                    var y = Console.ReadKey().Key;
                    Console.WriteLine();
                    switch (y) 
                    {
                        case (ConsoleKey.D1):
                            Menu.SetPath(true);
                            JsonParser.WriteJson(ref data);
                            break;
                        case (ConsoleKey.D2):
                            Menu.SetPath(false);
                            JsonParser.WriteJson(ref data);
                            break;
                    }
                    
                    break;
                default:
                    throw new ArgumentOutOfRangeException();

            };
        }
        // Метод для обработки данных.
        // Method for data processing.
        private static List<Record> Action(ref List<Record> data) 
        {
            ActionWithData x = (ActionWithData)(Console.ReadKey().Key);
            List<Record> modifiedData = new List<Record>();
            Console.WriteLine();
            switch (x)
            {
                case (ActionWithData.Sort):
                    Menu.Sorting(data, ref modifiedData);
                    break;
                case (ActionWithData.Sample):
                    Menu.Sampling(data , ref modifiedData);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            };
            return modifiedData;
        }
    }
}
/*
░░░░░░░░░░░░░░░░░░░░
░░░░░ЗАПУСКАЕМ░░░░░░░
░ГУСЯ░▄▀▀▀▄░РАБОТЯГИ░░
▄███▀░◐░░░▌░░░░░░░░░
░░░░▌░░░░░▐░░░░░░░░░
░░░░▐░░░░░▐░░░░░░░░░
░░░░▌░░░░░▐▄▄░░░░░░░
░░░░▌░░░░▄▀▒▒▀▀▀▀▄
░░░▐░░░░▐▒▒▒▒▒▒▒▒▀▀▄
░░░▐░░░░▐▄▒▒▒▒▒▒▒▒▒▒▀▄
░░░░▀▄░░░░▀▄▒▒▒▒▒▒▒▒▒▒▀▄
░░░░░░▀▄▄▄▄▄█▄▄▄▄▄▄▄▄▄▄▄▀▄
░░░░░░░░░░░▌▌░▌▌░░░░░
░░░░░░░░░░░▌▌░▌▌░░░░░
░░░░░░░░░▄▄▌▌▄▌▌░░░░░
*/