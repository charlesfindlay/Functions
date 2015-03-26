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

            int decisionLevel = 0;
            string disposition = null;
            do
            {
                if (decisionLevel == 3)
                {
                    disposition = "Approved";
                    PrintDecision(decisionLevel, disposition);
                    break;
                }
                int managerCap = caps[decisionLevel];
                string managerRule = rules[decisionLevel];

                bool expenseCheck = CanApprove(expense, managerCap);
                bool ruleCheck = AgainstRules(managerRule, description);
                if (decisionLevel == 2 && ruleCheck == false && expense <= 5000)
                    ruleCheck = true;


                disposition = ManagerLevelDisposition(expenseCheck, ruleCheck);
                PrintDecision(decisionLevel, disposition);
                decisionLevel += 1;

            } while (disposition == "Escalated");
            


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

        public static string ManagerLevelDisposition(bool expenseCheck, bool ruleCheck)
        {
            if (ruleCheck == false)
                return "Rejected";
            else if (expenseCheck == true)
                return "Approved";
            else
                return "Escalated";
        }

        public static void PrintDecision(int decisionLevel, string disposition)
        {
            switch (decisionLevel)
            {
                case (0):                                    
                    Console.WriteLine("The first level manager has {0} your expense", disposition);
                    return;                    
                case (1):
                    Console.WriteLine("The second level manager has {0} your expense", disposition);
                    return;
                case (2):
                    Console.WriteLine("The director has {0} your expense", disposition);
                    return;
                case (3):
                    Console.WriteLine("The CEO has {0} your expense", disposition);
                    return;
            }
        }




    }
}
 