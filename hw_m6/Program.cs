using System;
using System.IO;


namespace hw_m6
{
    internal class Program
    {
        //Ввод данных для записи в файл
        static string InputEmployee(string[] constEmployee, int id)
        {
            //Инициализация переменных
            string employeeInfo = null;
            string [] tempArray = new string[constEmployee.Length];
            //Автоматический + ручной ввод данных
            tempArray[0] = $"{id}";
            tempArray[1] = Convert.ToString(DateTime.Now);
            for (int i = 2; i < tempArray.Length; i++)
            {
                Console.Write(constEmployee[i]);
                tempArray[i] = Console.ReadLine();
                employeeInfo = String.Join("#", tempArray);
            }
            employeeInfo += "\n";
            //Возврат строки
            return employeeInfo;
        }

        //Запись данных в файл
        static void InputInfo(string path, string employeeInfo)
        {
            if (File.Exists(path))
            {
                File.AppendAllText(path, employeeInfo);
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine(employeeInfo);
                }
            }
        }

        //Чтение данных из файла
        static void OutputInfo(string path, string [] constEmployee)
        {
            if (File.Exists(path))
            {
                //Инициализация переменной для хранения строки из файла
                string line;
                using (StreamReader sr = new StreamReader(path))
                {
                    //Присвоение данных строке до конца файла
                    while ((line = sr.ReadLine()) != null)
                    {
                        //Разделение строки на массив данных для последующего вывода
                        string[] lineArray = line.Split('#');
                        for (int i = 0; i < lineArray.Length - 1; i++)
                        {
                            Console.Write(constEmployee[i]);
                            Console.WriteLine(lineArray[i]);
                        }
                        Console.WriteLine();
                    }
                }
            } 
            else
            {
                //Отработка исключений для отсутствующего файла
                Console.WriteLine("Sorry, file isn`t founded.");
            }
            
        }

        static void Main(string[] args)
        {
            //Счетчик id сотрудников
            int idCount = 1;
            //Константные значения для формы заполнения и вывода
            string[] constEmployee = new string[7];
            constEmployee[0] = "ID: ";
            constEmployee[1] = "Date of creation: ";
            constEmployee[2] = "Full Name: ";
            constEmployee[3] = "Age: ";
            constEmployee[4] = "Groth: ";
            constEmployee[5] = "Day of birth: ";
            constEmployee[6] = "Place of birth: ";
            //Путь к файлу
            string path = @"E:\directory";
            //Бесконечный цикл
            while (true)
            {
                //Управление программой
                Console.Write("Menu \n1 - for get info" +
                    "               \n2 - for input info" +
                    "               \n3 - for stop program" +
                    "               \n0 - for delete information\n");

                int choise = int.Parse(Console.ReadLine());

                if (choise == 1) //Получить информацию из файла
                {
                    
                    OutputInfo(path, constEmployee);

                }
                else if (choise == 2) //Ввести информацию в файл
                {
                    string employeeInfo = InputEmployee(constEmployee, idCount);
                    InputInfo(path, employeeInfo);
                    idCount++;
                }
                else if (choise == 3) //Выйти из цикла и остановить выполнение программы
                {
                    break;
                }
                else if (choise == 0) //Удаление файла
                {
                    File.Delete(path);
                }
                else { Console.WriteLine("Unknown command"); }

            }
        }
    }
}
