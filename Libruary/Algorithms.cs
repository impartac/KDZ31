using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libruary
{

    public class Algorithms
    {
        enum State
        {
            Start,
            Record,
            Key,
            Value,
            ValueInt,
            ValueString,
            ValueBool,
            ValueArr,
            Null
        }
        
        public static List<Dictionary<string,Object>> FiniteStateMachine(StreamReader log) 
        {
            Dictionary<string, Object> dict = new Dictionary<string, Object>();
            StringBuilder tempkey = new StringBuilder();
            Object tempvalue = new object();
            List<int?> templist = new List<int?>();
            State state = State.Start;
            List<Dictionary<string, Object>> answer = new List<Dictionary<string, object>>();
            while (true)
            {
                string line = log.ReadLine();
                foreach (char symbol in line ?? "")
                {
                    switch (state)
                    {
                        case State.Start when symbol =='[' || symbol =='{':
                            dict = new Dictionary<string, Object>();
                            tempkey = new StringBuilder();
                            tempvalue = new object();
                            templist = new List<int?>();
                            state = State.Record;
                            break;
                        case State.Start when symbol == ']':
                            return answer;
                        case State.Record:
                            switch (symbol)
                            {
                                case '"':
                                    state = State.Key;
                                    break;
                                case ':':
                                    state = State.Value;
                                    break;
                                case '}':
                                    answer.Add(dict);
                                    state = State.Start;
                                    break;
                                   
                            }
                            break;
                        case State.Key:
                            switch (symbol) 
                            {
                                case '"':
                                    state = State.Record;
                                    dict.Add(tempkey.ToString(), new Object());
                                    break;
                                default:
                                    tempkey.Append(symbol);
                                    break;
                            }
                            break;
                        case State.Value:
                            switch (symbol)
                            {
                                case '[':
                                    state = State.ValueArr;
                                    tempvalue = 0;
                                    break;
                                case '"':
                                    state = State.ValueString;
                                    tempvalue = new StringBuilder();
                                    break;
                                case 'n':
                                    state = State.Null;
                                    tempvalue = new StringBuilder();
                                    tempvalue += "n";
                                    break;
                                default:
                                    if (Char.IsDigit(symbol))
                                    {
                                        tempvalue = int.Parse(symbol.ToString());
                                        state = State.ValueInt;
                                    }
                                    else if (Char.IsLetter(symbol)) 
                                    {
                                        tempvalue = new StringBuilder(symbol.ToString());
                                        state = State.ValueBool;
                                    }
                                    break;
                            }
                            
                            break;
                        case State.ValueInt:

                            switch (symbol)
                            {
                                case ',':
                                    state = State.Record;
                                    dict[tempkey.ToString()] = (int)tempvalue;
                                    tempvalue = new StringBuilder();
                                    tempkey = new StringBuilder();
                                    break;
                                default:
                                    tempvalue = (int)tempvalue * 10 + int.Parse(symbol.ToString());
                                    break;
                            }
                            break;
                        case State.ValueBool:
                            switch (symbol)
                            {
                                case ',':
                                    dict[tempkey.ToString()] = bool.Parse(tempvalue.ToString());
                                    tempvalue = new StringBuilder();
                                    tempkey = new StringBuilder();
                                    state = State.Record;
                                    break;
                                default:
                                    tempvalue+=(symbol.ToString());
                                    break;
                            }
                            break;
                        case State.ValueString:
                            switch (symbol) 
                            {
                                case '"':
                                    dict[tempkey.ToString()] = tempvalue.ToString();
                                    state = State.Record;
                                    tempkey = new StringBuilder();
                                    tempvalue = new StringBuilder();
                                    break;
                                default:
                                    tempvalue += symbol.ToString();
                                    break;
                            }
                            break;
                        case State.ValueArr:
                            if (Char.IsDigit(symbol))
                            {
                                tempvalue = (int)tempvalue * 10 + int.Parse(symbol.ToString());
                            }
                            else if (symbol == ']')
                            {


                                templist.Add((int)tempvalue);
                                dict[tempkey.ToString()] = (List<int?>)templist;
                                state = State.Record;
                                tempvalue = new StringBuilder();
                                tempkey = new StringBuilder();
                            }
                            else if (symbol == ',')
                            {
                                templist.Add((int)tempvalue);
                                tempvalue = 0;
                            }
                            break;
                        case State.Null:
                            if (tempvalue.ToString() == "null")
                            {
                                dict[tempkey.ToString()] = tempvalue;
                                tempkey = new StringBuilder();
                                tempvalue = new StringBuilder();
                                state = State.Record;
                            }
                            else 
                            { 
                                tempvalue += symbol.ToString();
                            }
                            break;
                    }
                }
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