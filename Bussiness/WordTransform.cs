using System;
using InterfacesDictionaryData;
using System.Collections.Generic;

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
        public List<string> Solution { get; set; }

        public HashSet<string> HasVisited { get; set; } = new HashSet<string>();

        public void TransformWord(string StartWord, string EndWord)
        {
            HasVisited.Add(StartWord);
            string tempIterationStartWord = StartWord;
            Solution.Add(StartWord);
            
            restart:
            //Iterate through dictionary
            foreach(var HastSetItem in idictionaryData.hashSetDictionaryData)
            {
                //Check if one lette difference
                if (IsOneLetterDifferent(tempIterationStartWord, HastSetItem) && !HasVisited.Contains(HastSetItem))
                {   
                    //If one letter difference then check which position

                    if(ShouldAddWord(CheckWhichLetterDifferent(tempIterationStartWord, HastSetItem), HastSetItem, EndWord))
                    {
                        Console.WriteLine("Yippee!! " + tempIterationStartWord + " " + HastSetItem);
                        tempIterationStartWord = HastSetItem;
                        Solution.Add(HastSetItem);
                        HasVisited.Add(HastSetItem);

                        if (HastSetItem == EndWord)
                        {
                            Console.WriteLine("Solution Found!");
                            Console.ReadLine();
                            break;
                        }
                        else {
                            goto restart;
                        }
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

        public int CheckWhichLetterDifferent(string CheckLetterStartWord, string CheckLetterEndWord)
        {
            int letter = 0;

            for (int i = 0; i < 4; i++)
            {
                if (CheckLetterStartWord[i] != CheckLetterEndWord[i])
                {
                    return letter;
                }
                letter++;
            }
            return letter;
        }

        public bool ShouldAddWord(int LetterPosition, string AddStartWord, string AddEndWord)
        {
            bool replace = false;

                if (AddStartWord[LetterPosition] == AddEndWord[LetterPosition])
                {
                replace = true;
                }
            return replace;
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
