using CBATest.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBATest
{
    public class RuleFactory
    {
        public static IRule GetRule(string ruleName)
        {
            switch (ruleName)
            {
                case "rule1":
                    return new Rule1();
                case "rule2":
                    return new Rule2();
                case "rule3":
                    return new Rule3();
                case "rule4":
                    return new Rule4();
                default:
                    return null;
            }

        }
    }
}
