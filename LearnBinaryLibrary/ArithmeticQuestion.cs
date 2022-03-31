using System;
using System.Linq;

namespace LearnBinaryLibrary
{
    public class ArithmeticQuestion : Question
    {
        private readonly char[] validOperators = new char[] { '+', '-', '*', '/' };

        public int CorrectAnswer { get; private set; }

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

        public ArithmeticQuestion()
        {
            Operator = GenerateRandomOperator();
            Value2 = GenerateRandomByte();
            Value2Base = GenerateRandomBase();

            while (Value1Base == 10 && Value2Base == 10)
            {
                Value1Base = GenerateRandomBase();
                Value2Base = GenerateRandomBase();
            }

            CalculateCorrectAnswer();

            if (CorrectAnswer < 0)
            {
                CorrectAnswerBase = 10;
            }

            while (CorrectAnswer < 1 && CorrectAnswer >= 0)
            {
                Value1 = GenerateRandomByte();
                Value2 = GenerateRandomByte();
                CalculateCorrectAnswer();
            }

        }

        public override void CalculateCorrectAnswer()
        {
            switch (Operator)
            {
                case '+':
                    CorrectAnswer = Value1 + Value2;
                    break;
                case '-':
                    CorrectAnswer = Value1 - Value2;
                    break;
                case '*':
                    CorrectAnswer = Value1 * Value2;
                    break;
                case '/':
                    while (Value2 == 0)
                    {
                        Value2 = GenerateRandomByte();
                    }
                    CorrectAnswer = Value1 / Value2;
                    break;
                default:
                    CorrectAnswer = 0;
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

        public bool CheckAnswer(string answer)
        {
            return answer == Convert.ToString(CorrectAnswer, CorrectAnswerBase);
        }
    }
}
