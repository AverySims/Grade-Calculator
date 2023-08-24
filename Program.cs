using FibonacciSequenceGenerator;

namespace GradeCalculator
{
	internal class Program
	{
		static void Main(string[] args)
		{
			// GPT generated code
			Console.Write("Enter the number of classes: ");
			int numClasses = int.Parse(Console.ReadLine());

			double overallTotalGrades = 0;
			int overallTotalStudents = 0;

			for (int classNum = 1; classNum <= numClasses; classNum++)
			{
				Console.WriteLine($"Class {classNum}:");

				Console.Write("Enter the number of students: ");
				int numStudents = int.Parse(Console.ReadLine());
				int totalGrades = 0;

				for (int student = 1; student <= numStudents; student++)
				{
					Console.Write($"Enter the grade for student {student}: ");
					int grade = int.Parse(Console.ReadLine());
					totalGrades += grade;
				}

				double classAverage = (double)totalGrades / numStudents;
				overallTotalGrades += totalGrades;
				overallTotalStudents += numStudents;

				char classLetterGrade = CalculateLetterGrade(classAverage);

				Console.WriteLine($"Class {classNum} Average Grade: {classAverage:F2}");
				Console.WriteLine($"Class {classNum} Letter Grade: {classLetterGrade}");
				Console.WriteLine();
			}

			double overallAverage = (double)overallTotalGrades / overallTotalStudents;
			char overallLetterGrade = CalculateLetterGrade(overallAverage);

			Console.WriteLine($"Overall Average Grade: {overallAverage:F2}");
			Console.WriteLine($"Overall Letter Grade: {overallLetterGrade}");

			SimpleConsoleFunctions.ParseEndingInput();
		}
		
		// GPT generated code
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