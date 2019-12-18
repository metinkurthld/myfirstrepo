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

            book.NameChanged += OnNameChanged;

            try
            {
                book.Name = "Metin's new fantastic gradebook";
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            
            //book.NameChanged += new NameChangedDelegate(OnNameChanged);
            //book.NameChanged += new NameChangedDelegate(OnNameChanged2); //overrides onnamechanged if += is not used
             //now working with eventargs
            //book.NameChanged += OnNameChanged2; //overrides onnamechanged if += is not used
            //book.NameChanged -= OnNameChanged; removes 1 onNameChanged event from the list if exists any
           

            //book.NameChanged = null; // this assignment can only be made for delegates but can not be done for events. events accepts only subscribe or unscribe. 
            //this is why events are preferred over delegated in order to provide protection

            //GetBookName(book);

            book.Name = "Metin's Gradebook";
            book.Name = "Metin's Gradebook2";

            AddGrades(book);

            //book.WriteGrades(Console.Out);
            //book.WriteGrades(); //overloaded
            SaveGrades(book);
            SpeechSynthesizer konus = new SpeechSynthesizer();
            //konus.Speak("writeresults removes lowest grade in throwawaygradebook.computestatistics so must be executed before writeresults");
            //konus.Speak("I have added a little wait here. no rush please. nereye gidiyon boyle a lahn");
            WriteGradesInBytes(book); //writeresults removes lowest grade in throwawaygradebook.computestatistics so must be executed before writeresults


            WriteResults(book);

            //konus.Speak("writeresults removes lowest grade in throwawaygradebook.computestatistics so must be executed before writeresults");

            Console.ReadLine();

        }

        private static void WriteGradesInBytes(Gradebook book)
        {

            foreach (float grade in book.grades)
            {
                WriteasBytes((int)grade);
            }
        }

        private static void WriteResults(Gradebook book)
        {
            GradeStatistics stats = book.ComputeStatistics();
            WriteResult("Average", (int)stats.AverageGrade);
            WriteResult("AverageFloat", stats.AverageGrade);
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
            //Console.WriteLine("{0}:;;;; {1}", description, result);
            Console.WriteLine($"{description}::: {result}");
        }

         static void WriteasBytes(int value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            //var bytes = BitConverter.GetBytes(value);

            foreach (byte b in bytes)
            {
                Console.WriteLine("0x{0:X2}",b);
                //Console.WriteLine(bytes);
            }
        }

        static void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"Gradebook name changed from {args.ExistingName} to {args.NewName}");
        }

        /*
        static void OnNameChanged2(string existingName, string newName)
        {
            Console.WriteLine("***888");
        }*/
    }
}
