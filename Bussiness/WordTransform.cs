using System;
using InterfacesDictionaryData;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data_Access_Layer;

namespace Business
{
    public class WordTransform : ITransform
    {
        public WordTransform(IDictionaryData idictionaryData)
        {
            this.idictionaryData = idictionaryData;
            Solution = new List<string>();
        }

        public IDictionaryData idictionaryData { get; set; }

        private string _startWord;
        public string StartWord
        {
            get => _startWord;
            set
            {
                if (value.Length != 4)
                {
                    throw new Exception("StartWord length must be 4 letters");
                }
                else
                {
                    _startWord = value;
                }
            }
        }

        private string _endWord;
        public string EndWord
        {
            get => _endWord;
            set
            {
                if (value.Length != 4)
                {
                    throw new Exception("EndWord length must be 4 letters");
                }
                else
                {
                    _endWord = value;
                }
            }
        }

        private string _resultFile;
        public string ResultFile
        {
            get => _resultFile;
            set
            {
                if (value.Length == 0)
                {
                    throw new Exception("ResultFile length must be greater than 0");
                }
                else
                {
                    _resultFile = value;
                }
            }
        }

        private List<string> _solution;
        public List<string> Solution
        {
            get => _solution;
            set
            {                
                    _solution = value;
            }
        }

        public void TransformWord(string StartWord, string EndWord)
        {
            string tempStartWord = StartWord;
            int i = 0;
            Solution.Add(StartWord);


            //Iterate through dictionary
            foreach(var item in idictionaryData.hashSetDictionaryData)
            {
                i++;
                //Console.WriteLine("Working.." + i);
                if (IsOneLetterDifferent(tempStartWord, item))
                {                    
                    Console.WriteLine("Yippee!! " + tempStartWord + " " + item);
                    tempStartWord = item;
                    Solution.Add(item);

                    if (item == EndWord)
                    {
                        Console.WriteLine("Solution Found!");
                        Solution.Add(EndWord);
                        break;
                    }

                }

            }
            if(Solution.Count > 0)
            {
                Save(ResultFile, Solution);
            }
                    
        }

        public bool IsOneLetterDifferent(string TestStartWord, string TestEndWord)
        {
            int differences = 0;

            for (int i = 0; i < 4; i++)
            {
                if (TestStartWord[i] != TestEndWord[i])
                {
                    differences++;
                }
            }

            return differences == 1;
        }

        public void Save(string ResultFile, List<string> Solution)
        {
            //Save file
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"" + ResultFile + ""))
            {
                foreach (string line in Solution)
                {
                    file.WriteLine(line);
                }
            }
        }
    }

}
