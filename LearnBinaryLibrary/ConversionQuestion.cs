using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnBinaryLibrary
{
    public class ConversionQuestion : Question
    {

        public string CorrectAnswer { get; private set; }

        public override void CalculateCorrectAnswer()
        {
            CorrectAnswer = Convert.ToString(Value1, CorrectAnswerBase);
        }

        public override string ToString()
        {
            return "What is " + Convert.ToString(Value1, Value1Base) + " in " + validBases[CorrectAnswerBase] + "?";
        }

        public ConversionQuestion()
        {
            while (CorrectAnswerBase == Value1Base)
            {
                CorrectAnswerBase = GenerateRandomBase();
            }
            CalculateCorrectAnswer();
        }

        public bool CheckAnswer(string answer)
        {
            return answer == CorrectAnswer;
        }
    }
}
