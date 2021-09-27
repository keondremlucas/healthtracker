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
            Console.WriteLine("Welcome to the Health Tracker! What would you like to do?");
            Console.WriteLine("(Type \"help\" to see command options. Type \"quit\" to close the program.)");

            while (true)
            {
                Console.WriteLine("Please enter a command.");
                Console.Write("> ");
                var input = Console.ReadLine();
                var splitInput = input.Split(" ");

                if (splitInput.Count() > 0)
                {
                    if (splitInput[0] == "add" && splitInput.Count() == 5)
                    {
                        Sql.Insert(splitInput[1], Int32.Parse(splitInput[2]), Convert.ToDouble(splitInput[3]), Int32.Parse(splitInput[4]));
                    }
                    else if (splitInput[0] == "update" && splitInput.Count() == 6)
                    {
                        Sql.Update(Int32.Parse(splitInput[1]), splitInput[2], Int32.Parse(splitInput[3]), Convert.ToDouble(splitInput[4]), Int32.Parse(splitInput[5]));
                    }
                    else if (splitInput[0] == "delete" && splitInput.Count() == 2)
                    {
                        Sql.Delete(Int32.Parse(splitInput[1]));
                    }
                    else if (splitInput[0] == "query" && splitInput.Count() == 1)
                    {
                        Sql.Query();
                    }
                    else if (splitInput[0] == "help" && splitInput.Count() == 1)
                    {
                        Console.WriteLine();
                        Console.WriteLine("[EXAMPLE INPUTS]");
                        Console.WriteLine("Query data: query");
                        Console.WriteLine("Add item: add mm/dd/yyyy weight bmi calories");
                        Console.WriteLine("Update item: update id mm/dd/yyyy weight bmi calories");
                        Console.WriteLine("Delete item: delete id");
                        Console.WriteLine();
                    }
                    else if (splitInput[0] == "quit" && splitInput.Count() == 1)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                    }
                }
            }
        }
    }
}
