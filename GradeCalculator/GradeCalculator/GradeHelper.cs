namespace GradeCalculator;

public class GradeHelper
{
    public static char ConvertGradeToLetter(double grade)
    {
        if (grade >= 90)
        {
            return 'A';
        }
        if (grade >= 80)
        {
            return 'B';
        }
        if (grade >= 70)
        {
            return 'C';
        }
        if (grade >= 60)
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