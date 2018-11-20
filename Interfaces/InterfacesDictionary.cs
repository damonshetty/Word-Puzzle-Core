using System;
using System.Collections.Generic;

namespace InterfacesDictionaryData
{
    public interface IDictionaryData
    {
        string DictionaryFile { get; set; }
        HashSet<string> hashSetDictionaryData { get; set; }
        void LoadDictionaryData(string DictionaryFile);
    }

    public interface ITransform
    {
        IDictionaryData idictionaryData { get; set; }
        string StartWord { get; set; }
        string EndWord { get; set; }
        string ResultFile { get; set; }
        void TransformWord(string StartWord, string EndWord);
        bool IsOneLetterDifferent(string TestStartWord, string TestEndWord);
        List<string> Solution { get; set; }
        void Save(string ResultFile, List<string> Solution);
    }
}
