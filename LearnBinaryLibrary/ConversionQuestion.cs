using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnBinaryLibrary
{
    public class ConversionQuestion : Question
    {
        private string correctAnswer_;
        public string CorrectAnswer => correctAnswer_;

        public override void CalculateCorrectAnswer()
        {
            correctAnswer_ = Convert.ToString(Value1, CorrectAnswerBase);
        }
        public bool CheckAnswer(string answer)
        {
            return answer == correctAnswer_;
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
    }
}
