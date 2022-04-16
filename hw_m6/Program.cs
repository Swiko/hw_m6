using System;
using System.IO;


namespace hw_m6
{
    internal class Program
    {

        static string EmployeeInfo()
        {

            string[] employeeArray = new string[7];

            //Текущее время
            employeeArray[1] = Convert.ToString(DateTime.Now);

            //Пользовательский ввод данных сотрудника
            Console.WriteLine("Input ID");
            employeeArray[0] = Console.ReadLine();

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

            //Конвертация в строку для возврата значения
            string employee = null;
            for (int i = 0; i <= 6; i++)
            {
                employee += employeeArray[i];
                employee += "#";
            }
            return employee;
        }

        //Запись данных в файл
        static void InputInfo(string path)
        {
            if (File.Exists(path))
            {
                File.AppendAllLines(path, EmployeeInfo().Split());
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine(EmployeeInfo());
                }
            }
        }

        //Чтение данных из файла
        static string OutputInfo(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                return sr.ReadToEnd();
            }
        }


        static void Main(string[] args)
        {

            string path = @"E:\directory";

            while (true)
            {
                //Управление программой
                Console.Write("Menu \n1 - for get info" +
                    "               \n2 - for input info" +
                    "               \n3 - for stop program" +
                    "               \n0 - for delete information\n");

                int choise = int.Parse(Console.ReadLine());

                if (choise == 1)
                {
                    string[] OI = OutputInfo(path).Split('#');
                    foreach (string str in OI)
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
