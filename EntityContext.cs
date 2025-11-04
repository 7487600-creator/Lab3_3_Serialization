using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json; // Потрібен NuGet пакет

// Файл: EntityContext.cs
// Рівень DAL: Відповідає ТІЛЬКИ за фізичне читання та запис у файл.
public class EntityContext
{
    private const string FilePath = "students.json";

    // Метод для завантаження списку студентів з файлу
    public List<Student> LoadStudents()
    {
        if (!File.Exists(FilePath))
        {
            return new List<Student>(); // Якщо файлу немає, повертаємо порожній список
        }

        string json = File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<List<Student>>(json) ?? new List<Student>();
    }

    // Метод для збереження списку студентів у файл
    public void SaveStudents(List<Student> students)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(students, options);
        File.WriteAllText(FilePath, json);
    }
}
