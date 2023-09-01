using ConsoleFunctions;
using GenericParse;

namespace GradeCalculator
{
	internal class Program
	{
		// number of classes
		private static int _classCount;
		
		// number of students in selected class
		private static int _studentCount;
		
		// total number of students
		private static int _totalStudentCount;
		
		// total grade of all students
		private static double _combinedGrade;
		
		private static bool _loopMain = true;
		
		static void Main(string[] args)
		{
			while (_loopMain)
			{
				SetClassCount();

				CalculateStudentGrades();

				PrintOverallAverageGrade();

				ConsoleHelper.SelectEndingAction(out _loopMain);
			}
		}

		private static void SetClassCount()
		{
			Console.Write("Enter the number of classes: ");
			while (true)
			{
				// user input for number of classes
				int tempCount = GenericReadLine.TryReadLine<int>();
				if (tempCount < 1)
				{
					Console.Write("Please enter a valid number of classes: ");
				}
				else
				{
					// valid, break loop and continue program
					_classCount = tempCount;
					break;
				}
			}
			
			ConsoleHelper.PrintBlank();
		}
		
		private static void CalculateStudentGrades()
		{
			for (int classIndex = 1; classIndex <= _classCount; classIndex++)
			{
				SetStudentCount(classIndex);
				CalculateClassGrade(classIndex);
			}
		}
		
		private static void SetStudentCount(int classIndex)
		{
			Console.WriteLine($"Class {classIndex}:");
			Console.Write("Enter the number of students: ");
			while (true)
			{
				// user input for number of students in selected class
				int tempCount = GenericReadLine.TryReadLine<int>();
				if (tempCount < 1)
				{
					Console.Write("Please enter a valid number of students: ");
				}
				else
				{
					// valid, break loop and continue program
					_studentCount = tempCount;
					break;
				}
			}
		}
		
		private static void CalculateClassGrade(int index)
		{
			double classAverage = 0;
			double classTotal = 0;
			char classLetter = 'F';

			for (int studentIndex = 1; studentIndex <= _studentCount; studentIndex++)
			{
				Console.Write($"Enter the grade for student {studentIndex}: ");
				double tempGrade = GenericReadLine.TryReadLine<double>();

				classTotal += tempGrade;
			}

			classAverage = GetAverageScore(_studentCount, classTotal);
			classLetter = GetLetterGrade(classAverage);

			_combinedGrade += classTotal;
			_totalStudentCount += _studentCount;

			Console.WriteLine($"Class {index} Average Grade: {classLetter} {classAverage:F2}");
			ConsoleHelper.PrintBlank();
		}

		private static char GetLetterGrade(double average)
		{
			if (average >= 90)
				return 'A';
			if (average >= 80)
				return 'B';
			if (average >= 70)
				return 'C';
			if (average >= 60)
				return 'D';
			else
				return 'F';
		}

		private static double GetAverageScore(double studentCount, double totalScore)
		{
			return totalScore / studentCount;
		}

		private static void PrintOverallAverageGrade()
		{
			double overallAverage = GetAverageScore(_totalStudentCount, _combinedGrade);
			char overallLetter = GetLetterGrade(overallAverage);

			Console.WriteLine($"Overall average grade: {overallLetter} {overallAverage:F2}");
			ConsoleHelper.PrintBlank();
		}
	}
}