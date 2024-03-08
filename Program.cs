using System;
using System.IO;
using System.Text.RegularExpressions;
using _2;

class Program
{
    static void Main()
    {
        try
        {
            string[] students = { "Морозов", "Долина", "Сорокин", "Кабачков"};
            Teacher teacher = new Teacher("teacher@email.com", "Андрей", 24, students); // создание экземпляра класса
        }
        catch (Exception ex) // обработка исключений
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }
}
