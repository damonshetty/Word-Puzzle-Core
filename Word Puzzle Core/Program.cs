using System;
using InterfacesDictionaryData;
using Data_Access_Layer;
using Business;
using System.Collections.Generic;

namespace Word_Puzzle_Core
{
    public class Program
    {   
        static void Main(string[] args)
        {
            Console.WriteLine("Hello this Word Puzzle!");
            Console.WriteLine("Enter Dictionary File path");

            //Dictionary Data
            IDictionaryData iDictionaryData = new clsDictionaryData();

            //Load dictionary file into HashSet data structure
            try
            {
                iDictionaryData.LoadDictionaryData(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
                Environment.Exit(0);
            }

            ITransform iTransform = new WordTransform(iDictionaryData);

            Console.WriteLine("Enter Start Word");
            try
            {
                iTransform.StartWord = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
                Environment.Exit(0);
            }

            Console.WriteLine("Enter End Word");
            try
            {
                iTransform.EndWord = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
                Environment.Exit(0);
            }

            Console.WriteLine("Enter Results File");
            try
            {
                iTransform.ResultFile = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
                Environment.Exit(0);
            }

            //Transfor Word
            iTransform.TransformWord(iTransform.StartWord, iTransform.EndWord);

        }
    }
}
