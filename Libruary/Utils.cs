using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libruary
{
    public static class Utils
    {
        // Методы вывода данных в нужный поток.
        // Method for output in correct stream.
        public static void RecordToString(List<Record> data,StreamWriter log) 
        
        {
            if (data.Count == 0)
            {
                log.WriteLine("Данные пусты.");
            }
            else
            {

                log.WriteLine("[");
                for (int i = 0; i < data.Count; i++)
                {
                    if (i == data.Count - 1)
                    {
                        log.WriteLine(data[i].ToString());
                    }
                    else
                    {
                        log.WriteLine(data[i].ToString() + ',');
                    }
                }
                log.WriteLine("]");
            }
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