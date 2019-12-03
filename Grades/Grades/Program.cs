using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            Gradebook book = new ThrowAwayGradeBook();
            //GetBookName(book);
            AddGrades(book);

            //book.WriteGrades(Console.Out);
            //book.WriteGrades(); //overloaded
            SaveGrades(book);

            WriteResults(book);

            SpeechSynthesizer konus = new SpeechSynthesizer();
            //konus.Speak("Belma looks sad Metin Mirza");

            Console.ReadLine();

        }

        private static void WriteResults(Gradebook book)
        {
            GradeStatistics stats = book.ComputeStatistics();
            WriteResult("Average", (int)stats.AverageGrade);
            WriteResult("AverageLetterGrade", stats.LetterGrade);
            WriteResult("AverageLetterDescription", stats.Description);
            WriteResult(stats.Description, stats.LetterGrade);
            Console.WriteLine(stats.AverageGrade);
            Console.WriteLine(stats.LowestGrade);
            Console.WriteLine(stats.HighestGrade);
        }

        private static void SaveGrades(Gradebook book)
        {
            using (StreamWriter outputFile = File.CreateText("grades.txt"))
            {
                book.WriteGrades(outputFile);
            }
        }

        private static void AddGrades(Gradebook book)
        {
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);
        }

        private static void GetBookName(Gradebook book)
        {
            try
            {
                Console.WriteLine("Enter a name");
                book.Name = Console.ReadLine();

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        static void WriteResult(string description, int result)
        {
            Console.WriteLine(description + ": " + result);
        }

        static void WriteResult(string description, string result)
        {
            Console.WriteLine(description + ": " + result);
        }


        static void WriteResult(string description, float result)
        {
            Console.WriteLine(description + ": " + result);
        }

         public void WriteasBytes(int value)
        {
            byte[] bytes = BitConverter.GetBytes(value);

            for each (byte b in bytes){
                Console.WriteLine("0x{0:X2}",b);
            }
        }
    }
}
