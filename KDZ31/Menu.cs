using Libruary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace KDZ31
{
    // Класс для работы с пользователем.
    // Class for user's interface.
    internal static class Menu
    {
        internal static void TypeFileIn() 
        {
            Console.WriteLine($"Выберите способ ввода данных.");
            Console.WriteLine($"1) Стандартный поток ввода данных.");
            Console.WriteLine($"2) Файловый поток ввода данных.");
        }
        internal static void TypeFileOut()
        {
            Console.WriteLine($"Выберите способ вывода данных.");
            Console.WriteLine($"1) Стандартный поток вывода данных.");
            Console.WriteLine($"2) Файловый поток вывода данных.");
        }
        internal static void GetMenu() 
        {
            Console.WriteLine("Выберите действие.");
            Console.WriteLine("1) Отсортировать данные по одному из полей.");
            Console.WriteLine("2) Отфильтровать данные по одному из полей.");
        } 
        internal static void Repeat() 
        {
            Console.WriteLine("Нажмите Backspace, чтобы выйти.");
        }
        internal static void ChooseOutputType() 
        {
            Console.WriteLine("Выберите действие.");
            Console.WriteLine("1) Записать в новый файл.");
            Console.WriteLine("2) Перезаписать файл.");
        }

        // Метод установки пути к существующему файлу в формате json.
        // Method to set path for existed file with json format.
        internal static void SetPath(bool newFile)  
        {
           
            string href;
            bool flag = true;
            do 
            {
                Console.WriteLine("Введите путь до файла.");
                href = Console.ReadLine().Trim('"');
                try
                {
                    if (newFile)
                    {
                        File.Create(href).Dispose();
                    }
                    JsonParser.Href = href;
                    flag = false;
                    Console.WriteLine("Путь корректный.");
                }
                catch (Exception)
                {
                    Console.WriteLine("Попробуйте снова.");
                    flag = true;
                }
            }
            while ( flag );
        }
        
        public static void WriteLinesToConsole(ref List<Record> data)
        {
            using StreamWriter log = new StreamWriter(Console.OpenStandardOutput(),Console.OutputEncoding);
            Console.WriteLine("Данные выглядят так :");
            Utils.RecordToString(data,log);
            log.Dispose();    
        }

        internal static void Sorting(List<Record> data,ref List<Record>modifiedData) 
        {
            using StreamReader log = new StreamReader(Console.OpenStandardInput(),Console.InputEncoding);
            Console.WriteLine("Введите ключ, по которому отсортировать массив");
            string s  = log.ReadLine();
            try
            {
                modifiedData = DataProcessing.Sort(s, data);
                Console.WriteLine($"Сортировка по ключу \"{s}\" прошла успешно.");
            }
            catch (Exception) 
            {
                Console.WriteLine($"Такого ключа не существует.");
            }     
            log.Dispose();
        }
        internal static void Sampling(List<Record> data, ref List<Record> modifiedData) 
        {
            using StreamReader log = new StreamReader(Console.OpenStandardInput(), Console.InputEncoding);
            Console.WriteLine("Введите поле, по которому будет проведена выборка массив.");
            string field = log.ReadLine();
            if (!data[0]._record.Keys.Contains(field)) 
            {
                throw new ArgumentOutOfRangeException();
            }
            Console.WriteLine("Введите строку, эквивалент который будет искать выборка.");
            string sample = log.ReadLine();
            modifiedData = DataProcessing.Sample(sample, field, data);
            Console.WriteLine("Выборка прошла успешно.");
            log.Dispose();
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
