using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using System;
using System.Numerics;

namespace CalculatorContract
{
    /**
     * simple calculator supporting add/subtract
     * param 05 (string) add|sub
     * object[] int, int
     */
    public class Contract1 : FunctionCode
    {
        public static void Main(string operation, params object[] args)
        {
            int arg0 = (int)args[0];
            int arg1 = (int)args[1];
            int result = -1;

            Runtime.Notify("CalculatorContract Init", arg0, arg1);

            if (operation == "add")
            {
                result = CalculatorAdd(arg0, arg1);
            }

            if(operation == "sub")
            {
                result = CalculatorSub(arg0, arg1);
            }

            Runtime.Notify("Calculator", operation, result);
            return;
        }

        static private int CalculatorSub(int a, int b)
        {
            int sum = a - b;

            Runtime.Notify("CalculatorSub Received", a, b);
            Runtime.Notify("CalculatorSub Result", sum);

            return sum;
        }

        static private int CalculatorAdd(int a, int b)
        {
            int sum = a + b;

            Runtime.Notify("CalculatorAdd Received", a, b);
            Runtime.Notify("CalculatorAdd Result", sum);

            return sum;
        }
    }
}
