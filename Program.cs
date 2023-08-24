using FibonacciSequenceGenerator;

namespace GradeCalculator
{
	internal class Program
	{
		private static int numberOfClasses;
		private static int numberOfStudents;
		private static int numberOfStudentsTotal;
		
		private static char classGradeLetter;
		private static double classGradeTotal;
		private static double classGradeAverage;

		private static char schoolGradeLetter;
		private static double schoolGradeTotal;
		private static double schoolGradeAverage;
        
		static void Main(string[] args)
		{
			Console.Write("Enter the number of classes: ");
			SimpleConsoleFunctions.ParseIntEC(out numberOfClasses);
			
			for (int classIndex = 1; classIndex <= numberOfClasses; classIndex++)
			{
				Console.WriteLine($"Class {classIndex}:");
				Console.Write("Enter the number of students:");
				SimpleConsoleFunctions.ParseIntEC(out numberOfStudents);
				
				CalculateClassGrade();

				Console.WriteLine($"Class {classIndex} Average Grade: {classGradeAverage:F2}");
				Console.WriteLine($"Class {classIndex} Letter Grade: {classGradeLetter}");
				SimpleConsoleFunctions.PrintBlank();
			}
			// school grade once all classes have been entered
			schoolGradeAverage = CalculateAverageScore(numberOfStudentsTotal, schoolGradeTotal);
			schoolGradeLetter = CalculateLetterGrade(schoolGradeAverage);

			Console.WriteLine($"Overall Average Grade: {schoolGradeAverage:F2}");
			Console.WriteLine($"Overall Letter Grade: {schoolGradeLetter}");
			SimpleConsoleFunctions.ParseEndingInput();
		}

		private static void CalculateClassGrade()
		{
			// resetting totals upon entering function from start
			classGradeTotal = 0;
			numberOfStudents = 0;
			
			for (int studentIndex = 1; studentIndex <= numberOfStudents; studentIndex++)
			{
				int tempGrade;
				Console.Write($"Enter the grade for student {studentIndex}: ");
				SimpleConsoleFunctions.ParseIntEC(out tempGrade);
				classGradeTotal += tempGrade;
			}
			// class grade once all student grades have been entered
			classGradeAverage = CalculateAverageScore(numberOfStudents, classGradeTotal);
			classGradeLetter = CalculateLetterGrade(classGradeAverage);
			
			// saving totals for school grade
			schoolGradeTotal += classGradeTotal;
			numberOfStudentsTotal += numberOfStudents;
			
		}
		
		private static double CalculateAverageScore(double studentCount, double totalScore)
		{
			return totalScore / studentCount;
		}
        
		// GPT generated function
		private static char CalculateLetterGrade(double average)
		{
			if (average >= 90 && average <= 100)
				return 'A';
			else if (average >= 80)
				return 'B';
			else if (average >= 70)
				return 'C';
			else if (average >= 60)
				return 'D';
			else
				return 'F';
		}
		
	}
}