namespace FinalProject.Models;

public class Grade
{
    public string Subject { get; set; }
    public double Score { get; set; }

    public Grade(string subject, double score)
    {
        Subject = subject;
        Score = score;
    }
}