using ConsoleFunctions;
using GenericParse;

namespace GradeCalculator
{
	internal class Program
	{
		private static int _classCount;
		private static int _studentCount;
		private static int _totalStudentCount;
		private static double _combinedGrade;

		static void Main(string[] args)
		{
			bool loopMain = true;

			while (loopMain)
			{
				GetClassCount();

				GetStudentCountsAndCalculateGrades();

				PrintOverallAverageGrade();

				ConsoleHelper.SelectEndingAction(out loopMain);
			}
		}

		private static void GetStudentCountsAndCalculateGrades()
		{
			for (int classIndex = 1; classIndex <= _classCount; classIndex++)
			{
				GetStudentCount(classIndex);
				CalculateClassGrade(classIndex);
			}
		}

		private static void GetClassCount()
		{
			bool loopValid = false;
			
			Console.Write("Enter the number of classes: ");
			do
			{
				int tempCount = GenericReadLine.TryReadLine<int>();
				if (tempCount >= 1)
				{
					_classCount = tempCount;
					loopValid = true;
				}
				else
				{
					Console.WriteLine("Invalid number of classes");
				}
			} while (!loopValid);
			
			ConsoleHelper.PrintBlank();
		}
		
		private static void GetStudentCount(int classIndex)
		{
			bool loopValid = false;

			Console.WriteLine($"Class {classIndex}:");
			Console.Write("Enter the number of students: ");
			do
			{
				int tempCount = GenericReadLine.TryReadLine<int>();
				if (tempCount >= 1)
				{
					_studentCount = tempCount;
					loopValid = true;
				}
				else
				{
					Console.WriteLine("Invalid number of students");
				}
			} while (!loopValid);
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

			classAverage = CalculateAverageScore(_studentCount, classTotal);
			classLetter = CalculateLetterGrade(classAverage);

			_combinedGrade += classTotal;
			_totalStudentCount += _studentCount;

			Console.WriteLine($"Class {index} Average Grade: {classLetter} {classAverage:F2}");
			ConsoleHelper.PrintBlank();
		}

		private static char CalculateLetterGrade(double average)
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

		private static double CalculateAverageScore(double studentCount, double totalScore)
		{
			return totalScore / studentCount;
		}

		private static void PrintOverallAverageGrade()
		{
			double overallAverage = CalculateAverageScore(_totalStudentCount, _combinedGrade);
			char overallLetter = CalculateLetterGrade(overallAverage);

			Console.WriteLine($"Overall average grade: {overallLetter} {overallAverage:F2}");
			ConsoleHelper.PrintBlank();
		}
	}
}