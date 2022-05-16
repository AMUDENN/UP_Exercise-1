﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UP_Exercise_1
{
    internal class ExceptionFunctions
    {
        static public Exception Ex_Double(string input_str, string data, double min = -1.7976931348623158e+308, double max = 1.7976931348623158e+308)
        {
            double result = 0;
            try
            {
                result = Convert.ToDouble(input_str);
                if(result < min)
                {
                    throw new Exception($"Введено число {data} меньше минимального предела: {min}");
                }
                if (result > max)
                {
                    throw new Exception($"Введено число {data} больше максимального предела: {max}");
                }
            }
            catch (Exception ex)
            {
                return ex;
            }
            return null;
        }

        static public Exception Ex_Int(string input_str, string data, int min = -2147483648, int max = 2147483647)
        {
            double result = 0;
            try
            {
                result = Convert.ToInt32(input_str);
                if (result < min)
                {
                    throw new Exception($"Введено число {data} меньше минимального предела: {min}");
                }
                if (result > max)
                {
                    throw new Exception($"Введено число {data} больше максимального предела: {max}");
                }
            }
            catch (Exception ex)
            {
                return ex;
            }
            return null;
        }
    }
}