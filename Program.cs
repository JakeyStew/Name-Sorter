using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace NameSorter
{
    static class Tools 
    {
        public static string ReverseSentence(string sentence) //Class for reversing the words of each string
        {
            string[] words = sentence.Split();  //Split each word and put them into an array, swap their positions and join them back together again.
            Array.Reverse(words);
            return string.Join(" ", words);
        }
    }
    class Program
    {
        static void Main()
        {
            var reverseList = new List<string>();   //Create two empty lists that'll hold the reversed and then sorted names.
            var sortedList = new List<string>();

            string LoadfilePath = String.Format(@"{0}\unsorted-names-list.txt", Environment.CurrentDirectory);  //File path for unsorted names
            string saveFilePath = String.Format(@"{0}\sorted-names-list.txt", Environment.CurrentDirectory);    //File path for sorted names
            List<string> namesList = File.ReadAllLines(LoadfilePath).ToList();  //Read unsorted names into a list

            if (namesList != null)  //Data Validation
            {
                Console.WriteLine("Unsorted and Reversed list of names:");
                foreach (string names in namesList)
                {
                    //Console.WriteLine("Unsorted name: " + names); Test the names are valid
                    string reverseLines = Tools.ReverseSentence(names);
                    reverseList.Add(reverseLines);
                    Console.WriteLine(reverseLines);  //Test the names are reversed
                }
                reverseList.Sort(); //Use default quicksort
                Console.WriteLine(Environment.NewLine + "Sorted list of names:");
                foreach(string reverse in reverseList)
                {
                    string sortedLines = Tools.ReverseSentence(reverse);
                    sortedList.Add(sortedLines);
                    Console.WriteLine(sortedLines); //Print all sorted names
                }

                File.WriteAllLines(saveFilePath, sortedList);   //Writes names to new sorted file in current directory
            }
        }
    }
}