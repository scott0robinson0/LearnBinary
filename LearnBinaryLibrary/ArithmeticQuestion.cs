using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnBinaryLibrary
{
    public class ArithmeticQuestion : Question
    {
        private readonly char[] validOperators = new char[] { '+', '-', '*', '/' };

        private char operator_;
        public char Operator
        {
            get => operator_;

            set => operator_ = validOperators.Contains(value) ? value : throw new ArgumentException("Error - Invalid operator ", value.ToString());
        }

        private int value2Base_;
        public int Value2Base
        {
            get => value2Base_;

            set => value2Base_ = GetBaseIfValid(value);
        }

        private byte value2_;
        public byte Value2
        {
            get => value2_;

            set => value2_ = GetByteIfValid(value);
        }

        public override void CalculateCorrectAnswer()
        {
            switch (Operator) // better to use operator_?
            {
                case '+':
                    correctAnswer_ = (Value1 + Value2).ToString();
                    break;
                case '-':
                    correctAnswer_ = (Value1 - Value2).ToString();
                    break;
                case '*':
                    correctAnswer_ = (Value1 * Value2).ToString();
                    break;
                case '/':
                    correctAnswer_ = (Value1 / Value2).ToString();
                    break;
            }
        }

        public override string ToString()
        {
            return "What is " + Convert.ToString(Value1, Value1Base) + " " + Operator + " " + Convert.ToString(Value2, Value2Base) + " in " + validBases[CorrectAnswerBase] + "?";
        }

        public char GenerateRandomOperator()
        {
            return validOperators[random.Next(0, validOperators.Length)];
        }
    }
}
