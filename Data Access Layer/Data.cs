using System;
using InterfacesDictionaryData;
using System.Collections.Generic;
using System.IO;

namespace Data_Access_Layer
{
    public class clsDictionaryData : IDictionaryData
    {
        public clsDictionaryData()
        {

        }

        private string _dictionaryFile;
        public string DictionaryFile
        {
            get => _dictionaryFile;
            set
            {
                if (value.Length == 0)
                {
                    throw new Exception("DictionaryFile length must be greater than 0");
                }
                else
                {
                    _dictionaryFile = value;
                }
            }
        }

        public HashSet<string> hashSetDictionaryData { get; set; } = new HashSet<string>();

        public void LoadDictionaryData(string DictionaryFile)
        {          
            try
            {
                foreach (string line in File.ReadLines(@"" + DictionaryFile + ""))
                {
                    //Length of words to be used is 4. Only add 4 letter words. Improve adding words to graph performance
                    if((line.Length == 4) && (!line.Contains("\\")))
                        hashSetDictionaryData.Add(line.ToLower());
                }
            }
            catch (IOException ex)
            {
                throw new IOException(ex.Message);
            }

        }

    }
    
    

}
