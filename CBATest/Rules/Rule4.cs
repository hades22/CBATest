using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBATest.Rules
{
    public class Rule4 : Rule
    {
        private HashSet<char> parameter2;

        public Rule4() : base()
        {
            var p2String = GetP2String();
            if (!string.IsNullOrEmpty(p2String))
            {
                parameter2 = new HashSet<char>();
                var p2List = p2String.ToCharArray();
                foreach (var c in p2List)
                {
                    parameter2.Add(c);
                }
            }
        }

        public override string GetP1String()
        {
            return ConfigurationManager.AppSettings["Rule4Parameter1"];
        }

        private string GetP2String()
        {
            return ConfigurationManager.AppSettings["Rule4Parameter2"];
        }

        public override List<string> GetCandidateWords(string[] words)
        {
            var result = new List<string>();
            for (int i = 0; i < words.Length - 1; i++)
            {
                if (IsTargetWord(words[i], parameter1) && IsTargetWord(words[i + 1], parameter2))
                {
                    result.Add(words[i]);
                }
            }
            return result;
        }

        public override int ProcessCandidateWords(List<string> candidateWords)
        {
            return candidateWords.Count();
        }

        public override string FileName()
        {
            return string.Format("count_of_sequence_of_words_starting_withs_{0}_and_{1}", GetP1String(), GetP2String());
        }

    }
}
