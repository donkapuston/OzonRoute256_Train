using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public static class MarineBattle
    {
        public static string [] ToBattle(int t, string [] a)
        {
            string[] results = new string[t];

            for (int i = 0; i< t; i++)
            {
                int countOf1 = a[i].Count(f => f == '1');
                int countOf2 = a[i].Count(f => f == '2');
                int countOf3 = a[i].Count(f => f == '3');
                int countOf4 = a[i].Count(f => f == '4');
                if (countOf1 == 4 && countOf2 == 3 && countOf3 == 2 && countOf4 == 1)
                {
                    results[i] = "YES";
                }
                else
                {
                    results[i] = "NO";
                }
            }

            return results;          
        }
    }
}
