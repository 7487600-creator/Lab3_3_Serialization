using System;
using System.Collections.Generic;
using System.Linq;

// Файл: EntityService.cs
// Рівень BLL: Містить усю бізнес-логіку. Не працює з консоллю чи файлами.
public class EntityService
{
    private readonly EntityContext _context;
    private readonly List<Student> _students;

    public EntityService()
    {
        _context = new EntityContext();
        _students = _context.LoadStudents(); // Завантажуємо дані при старті
    }

    // Логіка додавання студента
    public void AddStudent(Student student)
    {
        _students.Add(student);
    }

    // Логіка отримання всіх студентів
    public List<Student> GetAllStudents()
    {
        return _students;
    }

    // Логіка для варіанту 10
    public List<Student> GetKyivFifthYearFemales()
    {
        // Використовуємо LINQ для фільтрації
        var filteredList = _students.Where(s => 
                s.Course == 5 && 
                s.Gender == "Female" && 
                s.PlaceOfResidence == "Kyiv")
            .ToList();

        return filteredList;
    }

    // Метод для збереження всіх змін у файл
    public void SaveChanges()
    {
        _context.SaveStudents(_students);
    }
}
