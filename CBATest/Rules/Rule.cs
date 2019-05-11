using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBATest.Rules
{
    public abstract class Rule : IRule
    {
        public HashSet<char> parameter1;

        public Rule()
        {
            var p1String = GetP1String();
            if (!string.IsNullOrEmpty(p1String))
            {
                parameter1 = new HashSet<char>();
                var p1List = p1String.ToCharArray();
                foreach (var c in p1List)
                {
                    parameter1.Add(c);
                }
            }
        }

        public abstract string GetP1String();

        public virtual List<string> GetCandidateWords(string[] words)
        {
            var result = new List<string>();
            foreach (var word in words)
            {
                if (IsTargetWord(word, parameter1))
                {
                    result.Add(word);
                }
            }
            return result;
        }


        public abstract int ProcessCandidateWords(List<string> candidateWords);

        public int ProcessWords(string[] words)
        {
            var candidateWords = GetCandidateWords(words);
            return ProcessCandidateWords(candidateWords);
        }


        public bool IsTargetWord(string word, HashSet<char> parameter)
        {
            if (!string.IsNullOrEmpty(word))
            {
                if (parameter.Contains(word[0]))
                    return true;
            }
            return false;
        }

        public abstract string FileName();
    }
}
