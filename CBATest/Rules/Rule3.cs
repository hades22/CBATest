using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBATest.Rules
{
    public class Rule3 : Rule
    {
        public Rule3() : base() { }

        public override string GetP1String()
        {
            return ConfigurationManager.AppSettings["Rule3Parameter1"];
        }

        public override int ProcessCandidateWords(List<string> candidateWords)
        {
            int maxLength = 0;
            foreach(var word in candidateWords)
            {
                if (maxLength < word.Length)
                    maxLength = word.Length;
            }
            return maxLength;
        }

        public override string FileName()
        {
            return string.Format("longest_words_starting_with_{0}", GetP1String());
        }
    }
}
