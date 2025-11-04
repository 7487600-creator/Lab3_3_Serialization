using System;

// Файл: Student.cs
// Сутність, яка описує студента.
// Має публічні властивості для коректної JSON-серіалізації.
public class Student
{
    public string? LastName { get; set; }
    public string? FirstName { get; set; }
    public int Course { get; set; }
    public string? StudentID { get; set; }
    public string? Gender { get; set; }
    public string? PlaceOfResidence { get; set; }
    public string? RecordBookNumber { get; set; }

    public override string ToString()
    {
        return $"[{StudentID}] {LastName} {FirstName}, {Course} курс, {Gender}, ({PlaceOfResidence})";
    }
}
