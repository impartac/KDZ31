using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Libruary
{
    /// <summary>
    /// Класс работы с файла формата ".json" .
    /// Class for working with a file in the ".json" format.
    /// </summary>
    public static class JsonParser
    {
        /// <summary>
        /// Проверка пути до файла, с целью его перезаписи.
        /// Checking the path to the file in order to overwrite it.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private static bool CheckPath(string path) 
        {
            try 
            {
                File.Open(path, FileMode.Open, FileAccess.Read).Dispose();
                return Path.GetExtension(path)==".json";
            }
            catch (Exception) 
            {
                return false;
            }
        }
        public static string? href;
        public static string? Href 
        {
            get { return href; }
            set 
            {
                href = CheckPath(value.Trim('"')) ? value.Trim('"') : throw new FileLoadException();
            }
        }

        /// <summary>
        /// Метод считывания и преобразования файла в массив записей.
        /// Method for reading and converting to an array of records.
        /// </summary>
        /// <returns></returns>
        public static List<Record> ReadJson()
        {
            var temp = Console.In;
            using StreamReader log = new StreamReader(href);
            Console.SetIn(log);
            var dict = Algorithms.FiniteStateMachine(log);
            log.Dispose();
            Console.SetIn(temp);
            List < Record > answer = new List< Record >();
            foreach (var v in dict) 
            {
                answer.Add(new Record(v));
            }
            
            return answer;
            
        }
        public static void WriteJson(ref List<Record> data)
        {
            var temp = Console.Out;
            using StreamWriter log = new StreamWriter(href);
            Console.SetOut(log);
            Utils.RecordToString(data, log);
            log.Dispose();
            Console.SetOut(temp);
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