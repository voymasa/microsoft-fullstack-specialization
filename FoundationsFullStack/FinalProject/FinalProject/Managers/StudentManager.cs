namespace FinalProject.Managers;

using FinalProject.Models;

/// <summary>
/// Manages student records, including adding/updating grades and calculating average grades.
/// </summary>
public class StudentManager
{
    public Dictionary<string, StudentRecord> Students { get; set; }

    public StudentManager()
    {
        Students = new Dictionary<string, StudentRecord>();
    }

    /// <summary>
    /// Adds a new student to the manager. Will not add if a student with the same ID already exists.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    public void AddStudent(string id, string name)
    {
        // make sure the id is trimmed of leading/trailing whitespace to avoid IDs that appear the same
        id = id.Trim();
        if (Students.ContainsKey(id))
        {
            Console.WriteLine($"Student with ID {id} already exists.");
            return;
        }

        // check if the name is empty, only whitespace, or has invalid characters
        if (string.IsNullOrWhiteSpace(name) || name.Any(c => !char.IsLetter(c) && !char.IsWhiteSpace(c)))
        {
            Console.WriteLine("Invalid name. Name must be non-empty and contain only letters and spaces.");
            return;
        }

        Students.Add(id, new StudentRecord(name));
        Console.WriteLine($"Added student: {name} with ID: {id}");
    }

    /// <summary>
    /// Adds a grade to the student's record.
    /// </summary>
    /// <param name="student"></param>
    /// <param name="subject"></param>
    /// <param name="score"></param>
    public void GradeSubject(string studentId, string subject, double score)
    {
        // make sure the student exists; Trim used to avoid issues with leading/trailing whitespace
        studentId = studentId.Trim();
        if (!Students.TryGetValue(studentId, out StudentRecord? student))
        {
            Console.WriteLine($"Student with ID {studentId} not found.");
            return;
        }

        // check for valid score
        if (score < 0 || score > 100)
        {
            Console.WriteLine("Invalid score. Score must be between 0 and 100.");
            return;
        }

        // if the student already has a grade for the subject, update it
        var existingGrade = student.Grades.FirstOrDefault(g => g.Subject == subject);
        if (existingGrade != null)
        {
            existingGrade.Score = score;
            Console.WriteLine($"Updated grade for {student.Name}: {subject} - {score}");
        }
        else // otherwise, add a new grade
        {
            student.Grades.Add(new Grade(subject, score));
            Console.WriteLine($"Added new grade for {student.Name}: {subject} - {score}");
        }
    }

    /// <summary>
    /// Calculates the average grade for each student and updates their AverageGrade property.
    /// </summary>
    public void CalculateGradeAverages()
    {
        // if there are no students then notify the user and return
        if (Students.Count == 0)
        {
            Console.WriteLine("No students to calculate averages for.");
            return;
        }

        // calculate the average grade for each student
        foreach (var studentRecord in Students.Values)
        {
            if (studentRecord.Grades.Count == 0)
            {
                studentRecord.AverageGrade = 0;
            }
            else
            {
                studentRecord.AverageGrade = studentRecord.Grades.Average(g => g.Score);
            }
        }
        Console.WriteLine("Calculated average grades for all students.");
    }

    /// <summary>
    /// Displays all student records, including their grades and average grade.
    /// </summary>
    public void DisplayStudentRecords()
    {
        if (Students.Count == 0)
        {
            Console.WriteLine("No students to display.");
            return;
        }

        foreach (var student in Students.Values)
        {
            // get the key (student ID) for the student
            var studentId = Students.FirstOrDefault(pair => pair.Value == student).Key;
            Console.WriteLine($"Student ID: {studentId}, Name: {student.Name}, Average Grade: {student.AverageGrade:F2}");
            if (student.Grades.Count == 0)
            {
                Console.WriteLine("  No grades recorded.");
            }
            else
            {
                foreach (var grade in student.Grades)
                {
                    Console.WriteLine($"  Subject: {grade.Subject}, Score: {grade.Score}");
                }
            }
            Console.WriteLine(); // Blank line for readability
        }
    }
}