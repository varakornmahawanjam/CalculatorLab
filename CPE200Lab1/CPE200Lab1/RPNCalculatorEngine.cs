using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine:CalculatorEngine
    {
        public string Process(string str)
        {
            Console.WriteLine("");
            string[] strArr = str.Split(' ');
            Stack rpnStack = new Stack();
            string firstop, secondop;
            if (strArr.Length < 3) 
            {
                return "E";
            }
            foreach (string s in strArr)
            {
                //Console.WriteLine(s);
                if (isNumber(s)) 
                {
                    rpnStack.Push(s);
                }
                else if (isOperator(s))
                {
                    if(rpnStack.Count < 2)
                    {
                        return "E";
                    }
                    firstop = rpnStack.Pop().ToString();
                    secondop = rpnStack.Pop().ToString();
                    if (s == "-" || s == "÷")
                    {

                        rpnStack.Push(calculate(s, secondop, firstop));
                    }
                    else
                    {
                        rpnStack.Push(calculate(s, firstop, secondop));
                    }
                }
                //else
                //{
                //    return "E";
                //}
            }
            if (rpnStack.Count == 1)
            {
                return decimal.Parse(rpnStack.Peek().ToString()).ToString("G29");
            }
            return "E";
        }
    }
}
