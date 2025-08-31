namespace FinalProject.Models;
public class StudentRecord
{
    public string Name { get; set; } = string.Empty;
    public List<Grade> Grades { get; set; }

    /* while copilot is recommending that I have this property calculate the
       average in the getter, I think it's better to have the StudentManager
       have the responsibility of adding/updating grades and calculating the
       average grade, and then "marking" the student record wiht their average.
       It think this better reflects the single responsibility principle.
    */
    public double AverageGrade { get; set; }

    public StudentRecord()
    {
        Grades = new List<Grade>();
    }

    public StudentRecord(string name) : this()
    {
        Name = name;
    }
}