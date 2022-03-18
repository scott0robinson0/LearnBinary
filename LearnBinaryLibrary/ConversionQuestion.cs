using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnBinaryLibrary
{
    public class ConversionQuestion : Question
    {
        public override void CalculateCorrectAnswer()
        {
            correctAnswer_ = Convert.ToString(Value1, CorrectAnswerBase);
        }

        public override string ToString()
        {
            return "What is " + Convert.ToString(Value1, Value1Base) + " in " + validBases[CorrectAnswerBase] + "?";
        }
    }
}
