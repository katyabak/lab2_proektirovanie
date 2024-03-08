using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _2
{
    class Teacher 
    {
        private string email; 
        private string name; 
        private int age; 
        private string[] students; 

        public Teacher(string email, string name, int age, string[] students) // конструктор класса с параметрами
        {
            try // блок для обработки исключений
            {
                // проверка валидности почты, имени и возраста
                ValidateEmail(email); 
                ValidateName(name); 
                ValidateAge(age);
                // присвоение значений полям
                this.email = email; 
                this.name = name; 
                this.age = age; 
                this.students = students;
            }
            catch (Exception ex) // обработка исключений
            {
                LogError(ex.Message); // запись ошибки в лог
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
        private void ValidateEmail(string email) // метод для валидации почты
        {
            string emailPattern = @"^[a-zA-Z]+@[a-zA-Z]+\.[a-zA-Z]+$"; // регулярное выражение для проверки формата почты
            if (!Regex.IsMatch(email, emailPattern)) // если почта не соответствует шаблону
            {
                throw new Exception("Ошибка валидации почты: некорректный формат"); // генерация исключения с сообщением об ошибке
            }
        }
        private void ValidateName(string name) // метод для валидации имени
        {
            string namePattern = @"^[а-яА-Я]+$"; // проверка наличия только русских букв в имени
            if (!Regex.IsMatch(name, namePattern)) 
            {
                throw new Exception("Ошибка валидации имени: допустимы только русские буквы"); 
            }
        }

        private void ValidateAge(int age) // метод для валидации возраста
        {
            if (age <= 0 && age <= 150) 
            {
                throw new Exception("Ошибка валидации возраста: значение должно быть больше нуля"); 
            }
        }
        private void LogError(string errorMessage)
        {
            string logFileName = "error_log.txt";

            try
            {
                // создаем файл или открываем для добавления текста
                using (StreamWriter sw = File.AppendText(logFileName))
                {
                    string logMessage = $"{DateTime.Now}: {errorMessage}{Environment.NewLine}"; // формирование строки для записи в лог
                    sw.Write(logMessage); // запись строки в файл
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка записи в лог: {ex.Message}");
            }
        }
    }
}
