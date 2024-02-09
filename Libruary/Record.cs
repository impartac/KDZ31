using System.Data;
using System.Globalization;

namespace Libruary
{
    public class Record
    {
        public readonly Dictionary<string, dynamic> _record = new Dictionary<string, dynamic> 
        {
            { "id", new int?() },
            { "name", null},
            { "age", new int?() },
            { "city", null },
            { "isStudent", new bool?() },
            { "grades", new int?[3] {null,null,null } }
        };
        public Record(Dictionary<string,Object> record)
        {
            try
            {
                _record["id"] = record["id"].ToString() != "null"? (int?)record["id"]:null;
                _record["name"] = record["name"].ToString() != "null" ? (string?)record["name"]:null;
                _record["age"] = record["age"].ToString() != "null" ? (int?)record["age"]:null;
                _record["city"] = record["city"].ToString() != "null" ? (string?)record["city"]:null;
                _record["isStudent"] = record["isStudent"].ToString() != "null"? (bool?)record["isStudent"]:null;
                List<int?> grades;
                if (record["grades"].ToString() != "null")
                {
                    grades = (List<int?>)record["grades"];
                }
                else 
                {
                    grades = null;
                }
                if (grades is null) 
                {
                    _record["grades"] = null;
                }
                else 
                {
                    _record["grades"] = (!(grades is null) && grades.Count == 3) ? grades.ToArray<int?>() : throw new FileLoadException();
                }
            }
            catch (Exception) 
            {
                throw new FileLoadException();
            }
        }

        public Record() { }

        public override string ToString()
        {
            if (this is null) 
            {
                return "null";
            }
            if (_record["grades"] is null) 
            {
                return $"  {{\n" +
                    $"   \"id\": {_record["id"] ?? "null"},\n" +
                    $"   \"name\": \"{_record["name"] ?? "null"}\",\n" +
                    $"   \"age\": {_record["age"] ?? "null"},\n" +
                    $"   \"city\": \"{_record["city"] ?? "null"}\",\n" +
                    $"   \"isStudent\": {_record["isStudent"] ?? "null"},\n" +
                    $"   \"grades\": null \n"+
                    $"  }}";
            }
            _record["grades"] = (int?[])(_record["grades"]);
            return $"  {{\n" +
                    $"   \"id\": {_record["id"]??"null"},\n" +
                    $"   \"name\": \"{_record["name"] ?? "null"}\",\n" +
                    $"   \"age\": {_record["age"] ?? "null"},\n" +
                    $"   \"city\": \"{_record["city"] ?? "null"}\",\n" +
                    $"   \"isStudent\": {_record["isStudent"] ?? "null"},\n" +
                    $"   \"grades\": [\n" +
                    $"     {_record["grades"][0] ?? "null"},\n" +
                    $"     {_record["grades"][1] ?? "null"},\n" +
                    $"     {_record["grades"][2] ?? "null"}\n" +
                    $"   ]\n" +
                    $"  }}";
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