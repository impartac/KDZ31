using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Libruary
{
    public static class DataProcessing
    {

        private static string reg = "";
        public static List<Record> Sample(string sample, string keyName, List<Record> data)
        {
            List<Record> modifiedData = new List<Record>();
            foreach (var record in data)
            {
                /* 
                 * Это было сделано для проверки обнуляемых полей в данных 
                 * и для выборки по массивам (оценкам).
                 * That was done for check nullable fileds in data
                 * and for sampling by arrays (grades).
                */
                string temp;
                if (record._record[keyName] is null)
                {
                    temp = "null";
                }
                else
                {
                    temp = record._record[keyName].ToString();
                    if (temp == "System.Nullable`1[System.Int32][]")
                    {
                        temp = $"[{record._record[keyName][0] ?? "null"}," +
                            $"{record._record[keyName][1] ?? "null"}," +
                            $"{record._record[keyName][2] ?? "null"}]";
                    }
                }
                if (temp == sample)
                {
                    modifiedData.Add(record);
                }
            }
            return modifiedData;
        }

        // Метод подготовки полей к сортировке.
        // Method for preparing fields to sorting.
        private static dynamic ToSort(Record record, string keyName) 
        {
            if (keyName == "grades") 
            {
                if (record._record[keyName] is null) 
                {
                    return Int32.MinValue;
                }
                return record._record[keyName][0]+
                    record._record[keyName][1]+
                    record._record[keyName][2];
            }
            return record._record[keyName];

        }
        public static List<Record> Sort(string KeyName, List<Record> data)
        {
            List<Record> modifiedData = new List<Record>();
            try
            {
                modifiedData = data.OrderBy(x =>
                ToSort(x,KeyName)).ToList<Record>();
            }
            catch (Exception)
            {
                throw new ArgumentOutOfRangeException();
            }
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