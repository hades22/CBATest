using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBATest
{
    public class WordsCount
    {
        private const string inputPath = "../../Input";
        private const string outputPath = "../../Output";

        public void ProcessWords()
        {
            try
            {
                var s = File.ReadAllText(string.Format("{0}/Words.txt", inputPath));
                var words = s.Split(',');
                var ruleString = ConfigurationManager.AppSettings["ActiveRules"];
                var ruleNames = ruleString.Split(',');
                foreach (var ruleName in ruleNames)
                {
                    var rule = RuleFactory.GetRule(ruleName);
                    if (rule != null)
                    {
                        var result = rule.ProcessWords(words);
                        File.WriteAllText(string.Format("{0}/{1}.txt", outputPath, rule.FileName()), result.ToString());
                    }
                }
            }
            catch(Exception e)
            {
                File.WriteAllText(string.Format("{0}/ErrorLogs.txt", outputPath), e.Message.ToString());
            }
        }
    }
}
