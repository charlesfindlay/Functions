using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string[] rules = { "entertainment", "towncar", "hardware" };
            int[] caps = { 250, 500, 1000 };

            Console.WriteLine("Please describe your expense:");
            string description = Console.ReadLine();

            Console.Write("Enter the amount of the expense: ");
            decimal expense = decimal.Parse(Console.ReadLine());


            // Probalby enclose in a do - while loop
            int decisionLevel = 0;
            int managerCap = caps[decisionLevel];
            string managerRule = rules[decisionLevel];
            


        }

        
        enum level
        {
            first,
            second,
            director,
            ceo
        }

        public static bool CanApprove(decimal expense, int managerCap)
        {
            return (expense <= managerCap) ? true : false;
        }

        public static bool AgainstRules(string managerRule, string description)
        {
            foreach (string word in description.Split().ToArray())
            {
                if (word == managerRule)
                    return false;
            }
            return true;
          
        }


    }
}
