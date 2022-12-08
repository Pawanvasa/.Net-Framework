using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment27
{
public class NumberToWords
    {
        private static String EMPTY = String.Empty;
        private static String[] X =
            { EMPTY, "One", "Two", "Three" , "Four ", "Five ", "Six",
        "Seven ", "Eight ","Nine ", "Ten ", "Eleven ","Twelve ",
        "Thirteen ", "Fourteen ", "Fifteen ", "Sixteen ",
        "Seventeen ", "Eighteen ", "Nineteen "
    };

        private static String[] Y =
        {EMPTY, EMPTY, "Twenty ", "Thirty ", "Forty", "Fifty ","Sixty ", "Seventy ", "Eighty ", "Ninety "};

        private static String convertToDigit(int n, String suffix)
        {
            if (n == 0)
            {
                return EMPTY;
            }

            if (n > 19)
            {
                return Y[n / 10] + X[n % 10] + suffix;
            }
            else
            {
                return X[n] + suffix;
            }
        }

        public String convert(int n)
        {
            StringBuilder res = new StringBuilder();

            res.Append(convertToDigit(((n / 100000) % 100), "Lakh, "));

            res.Append(convertToDigit(((n / 1000) % 100), "Thousand "));

            res.Append(convertToDigit(((n / 100) % 10), "Hundred "));

            if ((n > 100) && (n % 100 != 0))
            {
                res.Append("and ");
            }

            res.Append(convertToDigit((n % 100), ""));

            return res.ToString();
        }
    }

}
