using FibonacciSequenceGenerator;

namespace GradeCalculator
{
	internal class Program
	{
		private static int classCount;
		private static int studentCount;
		private static int totalStudentCount;
		private static double combinedGrade;
        
		static void Main(string[] args)
		{
			bool loopMain = true;
            
			while (loopMain)
			{
				bool loopClassCount = true;
				
				// reading input for number of classes
				Console.Write("Enter the number of classes: ");
				while (loopClassCount)
				{
					if (!SimpleConsoleFunctions.ParseIntEC(out classCount) || classCount < 1)
						Console.WriteLine("Invalid number of classes");
					else
						loopClassCount = false;
				}
				SimpleConsoleFunctions.PrintBlank();
				
				// loop to enter info for each class
				for (int classIndex = 1; classIndex <= classCount; classIndex++)
				{
					bool loopStudentCount = true;
					
					Console.WriteLine($"Class {classIndex}:");
					// reading input for number of students in current class
					Console.Write("Enter the number of students: ");
					while (loopStudentCount)
					{
						if (!SimpleConsoleFunctions.ParseIntEC(out studentCount) || studentCount < 1)
							Console.WriteLine("Invalid number of students");
						else
							loopStudentCount = false;
					}
					CalculateClassGrade(classIndex);
				}
				// school grade once all classes & students have been entered
				double overallAverage = CalculateAverageScore(totalStudentCount, combinedGrade);
				char overallLetter = CalculateLetterGrade(overallAverage);

				Console.WriteLine($"Overall average grade: {overallLetter} {overallAverage:F2}");
				
				SimpleConsoleFunctions.SelectEndingAction(out loopMain);
			}
		}

		private static void CalculateClassGrade(int index)
		{
			// initializing defaults for local vars
			double classAverage = 0;
			char classLetter = 'F';
			double classTotal = 0;
			
			for (int studentIndex = 1; studentIndex <= studentCount; studentIndex++)
			{
				int tempGrade;
				Console.Write($"Enter the grade for student {studentIndex}: ");
				SimpleConsoleFunctions.ParseIntEC(out tempGrade);
				classTotal += tempGrade;
			}
			// class grade once all student grades have been entered
			classAverage = CalculateAverageScore(studentCount, classTotal);
			classLetter = CalculateLetterGrade(classAverage);
			
			// saving totals for overall grade
			combinedGrade += classTotal;
			totalStudentCount += studentCount;
			
			Console.WriteLine($"Class {index} Average Grade: {classLetter} {classAverage:F2}");
			SimpleConsoleFunctions.PrintBlank();
		}
        
		// GPT generated function
		private static char CalculateLetterGrade(double average)
		{
			//if (average >= 90 && average <= 100)
			if (average >= 90)
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
		
		private static double CalculateAverageScore(double studentCount, double totalScore)
		{
			return totalScore / studentCount;
		}
	}
}