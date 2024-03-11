using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_1_CSharp_Assessment
{
    internal class ProductValidation
    {
        public void IsStringValid(string inputString,string name)
        {
            if (string.IsNullOrWhiteSpace(inputString))
                throw new ValidateException($"!{name} Cannot be Empty!");
            if (double.TryParse(inputString, out double number))
                throw new ValidateException($"!{name} Cannot be Only Number!");
        }
        public void IsYearValid(string inputString)
        {
            if (string.IsNullOrWhiteSpace(inputString))
                throw new ValidateException("!It Cannot be Empty!");
            if (int.TryParse(inputString, out int number))
            {
                if (number < 1000 || number > 2023)
                    throw new ValidateException("!Enter a valid Year!");
            }
            else
                throw new ValidateException("!Enter Correct Format!");
        }
        public void IsPriceValid(string inputString)
        {
            if (string.IsNullOrWhiteSpace(inputString))
                throw new ValidateException("!It Cannot be Empty!");
            if (double.TryParse(inputString, out double number))
            {
                if (number < 0)
                    throw new ValidateException("Price should be positive number");
            }
            else
                throw new ValidateException("!Enter Correct Format!");
        }

    }
}
public class ValidateException : Exception
{ 
    public ValidateException(string message):base(message)
    { }
}

