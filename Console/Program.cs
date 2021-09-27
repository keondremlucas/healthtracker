using System;
using ClassLib;
using System.Collections.Generic;
using System.Linq;

namespace MainConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Welcome to the Health Tracker! What would you like to do?");
                var input = Console.ReadLine();
                var splitInput = input.Split(" ");

                if (splitInput[0] == "add")
                {
                    Sql.Insert(splitInput[1], Int32.Parse(splitInput[2]), Convert.ToDouble(splitInput[3]), Int32.Parse(splitInput[4]));
                }
                else if (splitInput[0] == "update")
                {
                
                }
                else if (splitInput[0] == "delete")
                {
                }
                else if (splitInput[0] == "query")
                {
                    Sql.Query();
                }
            }
        }
    }
}
