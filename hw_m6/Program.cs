using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace hw_m6
{
    internal class Program
    {

        static string EmployeeInfo()
        {
            string[] employeeArray = new string[7];
            Console.WriteLine("\nInput ID");
            employeeArray[0] = Console.ReadLine();
            Console.WriteLine("Input date and time");
            employeeArray[1] = Console.ReadLine();
            Console.WriteLine("Input full name");
            employeeArray[2] = Console.ReadLine();
            Console.WriteLine("Input age");
            employeeArray[3] = Console.ReadLine();
            Console.WriteLine("Input growth");
            employeeArray[4] = Console.ReadLine();
            Console.WriteLine("Input day of birth");
            employeeArray[5] = Console.ReadLine();
            Console.WriteLine("Place of birth");
            employeeArray[6] = Console.ReadLine();

            string employee = null;

            for (int i = 0; i <= 6; i++)
            {
                employee += employeeArray[i];
                employee += "#";
            }
            employee += "\n\n";
            return employee;
        }

        static void InputInfo(string path)
        {

            string employee = EmployeeInfo();

            if (File.Exists(path))
            {
            File.AppendAllText(path, employee);
            }
            else if (!File.Exists(path))
            {
            File.WriteAllText(path, employee);
            }


        }

        static string OutputInfo(string path)
        {

            if (File.Exists(path))
            {
                return File.ReadAllText(path);
            }
            else
            {
                return "\nOops, you have not created this file yet\n";
            }

        }

        static void Main(string[] args)
        {

            string path = @"E:\directory";

            while (true)
            {

                Console.Write("Menu \n1 - for get info" +
                    "               \n2 - for input info" +
                    "               \n3 - for stop program" +
                    "               \n0 - for delete information\n");

                int choise = int.Parse(Console.ReadLine());

                if (choise == 1)
                {
                    string getInfo = OutputInfo(path);
                    string[] splitInfo = getInfo.Split('#');

                    foreach(string str in splitInfo)
                    {
                        Console.WriteLine(str);
                    }

                }
                else if (choise == 2)
                {
                    InputInfo(path);
                }
                else if (choise == 3)
                {
                    break;
                }
                else if (choise == 0)
                {
                    File.Delete(path);
                }
                else { Console.WriteLine("Unknown command"); }
                
            }
        }
    }
}
