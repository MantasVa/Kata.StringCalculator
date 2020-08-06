using Kata.StringCalculator.Infrastructure.Interfaces;
using System;
using System.Linq;
using System.Text;

namespace Kata.StringCalculator
{
    public class StringCalculator : IStringCalculator
    {
        public int Add(string numbers)
        {
            int total = 0;

            if (numbers == "")
                return total;

            char delimeter = DetermineDelimeter(ref numbers);
            CheckForNegativeNumbers(numbers);

            numbers.Replace('\n', delimeter).Split(delimeter).ToList().ForEach(x => total += int.Parse(x));
            return total;
        }

        private static char DetermineDelimeter(ref string numbers)
        {
            char delimeter = ',';
            if (numbers.StartsWith("//"))
            {
                delimeter = numbers[2];
                numbers = numbers.Remove(0, 4);
            }

            return delimeter;
        }

        private static void CheckForNegativeNumbers(string numbers)
        {
            if (numbers.Contains('-'))
            {
                StringBuilder negativeNumbers = new StringBuilder();
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] == '-')
                        negativeNumbers.Append("-" + numbers[i + 1] + " ");
                }
                throw new ArgumentException("Negative numbers not allowed! " + negativeNumbers);
            }
        }
    }
}
