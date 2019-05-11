using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBATest.Rules
{
    public class Rule2 : Rule
    {
        private HashSet<char> parameter2;

        public Rule2() : base()
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

        private string GetP2String()
        {
            return ConfigurationManager.AppSettings["Rule2Parameter2"];
        }

        public override string GetP1String()
        {
            return ConfigurationManager.AppSettings["Rule2Parameter1"];
        }

        public override int ProcessCandidateWords(List<string> candidateWords)
        {
            int sum = 0;
            foreach (var word in candidateWords)
            {
                sum += word.Count(c => parameter2.Contains(c));
            }
            return sum;
        }

        public override string FileName()
        {
            return string.Format("count_of_{0}_in_words_starting_with_{1}", GetP2String(), GetP1String());
        }
    }
}
