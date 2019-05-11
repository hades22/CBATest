using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBATest.Rules
{
    public class Rule1 : Rule
    {
        public Rule1() : base() { }

        public override string GetP1String()
        {
            return ConfigurationManager.AppSettings["Rule1Parameter1"];
        }

        public override int ProcessCandidateWords(List<string> candidateWords)
        {
            int lengSum = 0;
            foreach (var word in candidateWords)
            {
                lengSum += word.Length;
            }
            return lengSum / candidateWords.Count();
        }

        public override string FileName()
        {
            return string.Format("average_length_of_words_starting_with_{0}", GetP1String());
        }
    }
}
