namespace GradeCalculator;

public class GradeHelper
{
    public static char ConvertGradeToLetter(double grade)
    {
        if (grade >= 90)
        {
            return 'A';
        }
        else if (grade >= 80)
        {
            return 'B';
        }
        else if (grade >= 70)
        {
            return 'C';
        }
        else if (grade >= 60)
        {
            return 'D';
        }
        else
        {
            return 'F';
        }
    }
    
    public static double GetAverageScore(double studentCount, double totalScore)
    {
        return totalScore / studentCount;
    }
}