using System;
using System.Collections.Generic;

// Файл: Program.cs
// Рівень PL: Містить клас Menu та точку входу Main.
// Відповідає ТІЛЬКИ за взаємодію з користувачем (консоль).
public class Menu
{
    private readonly EntityService _service;

    public Menu()
    {
        _service = new EntityService();
    }

    // Головний метод меню
    public void MainMenu()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        bool running = true;
        while (running)
        {
            Console.WriteLine("\n--- Головне Меню ---");
            Console.WriteLine("1. Додати студента");
            Console.WriteLine("2. Показати всіх студентів");
            Console.WriteLine("3. Завдання (Варіант 10)");
            Console.WriteLine("4. Зберегти та вийти");
            Console.Write("Ваш вибір: ");
            
            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    AddStudent();
                    break;
                case "2":
                    ViewAllStudents();
                    break;
                case "3":
                    RunVariantTask();
                    break;
                case "4":
                    SaveAndExit();
                    running = false;
                    break;
                default:
                    Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                    break;
            }
        }
    }

    private void AddStudent()
    {
        try
        {
            Console.WriteLine("\n--- Додавання студента ---");
            Student student = new Student();
            
            Console.Write("Прізвище: ");
            student.LastName = Console.ReadLine();
            Console.Write("Ім'я: ");
            student.FirstName = Console.ReadLine();
            Console.Write("Курс: ");
            student.Course = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("ID квитка: ");
            student.StudentID = Console.ReadLine();
            Console.Write("Стать (Male/Female): ");
            student.Gender = Console.ReadLine();
            Console.Write("Місце проживання: ");
            student.PlaceOfResidence = Console.ReadLine();
            Console.Write("Номер залікової книжки: ");
            student.RecordBookNumber = Console.ReadLine();

            _service.AddStudent(student); // Передаємо дані в BLL
            Console.WriteLine("Студента успішно додано.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Помилка: невірний формат курсу. Має бути число.");
        }
    }

    private void ViewAllStudents()
    {
        Console.WriteLine("\n--- Список всіх студентів ---");
        var students = _service.GetAllStudents();
        if (students.Count == 0)
        {
            Console.WriteLine("Список порожній.");
            return;
        }

        foreach (var student in students)
        {
            Console.WriteLine(student);
        }
    }

    private void RunVariantTask()
    {
        Console.WriteLine("\n--- Завдання 10: Студентки 5 курсу з Києва ---");
        var students = _service.GetKyivFifthYearFemales();
        
        Console.WriteLine($"Знайдено: {students.Count} студент(ів)");
        foreach (var student in students)
        {
            Console.WriteLine(student);
        }
    }

    private void SaveAndExit()
    {
        _service.SaveChanges(); // Викликаємо BLL для збереження
        Console.WriteLine("Дані збережено у файл students.json. Вихід...");
    }
}

// Клас Program містить лише точку входу
public class Program
{
    public static void Main(string[] args)
    {
        Menu menu = new Menu();
        menu.MainMenu(); // Запуск меню
    }
}
