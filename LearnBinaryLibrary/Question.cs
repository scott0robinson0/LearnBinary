using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnBinaryLibrary
{
    public class Question
    {
        protected readonly Dictionary<int, string> validBases = new Dictionary<int, string> { { 2, "binary" }, { 10, "decimal" } };

        protected readonly Random random = new Random();

        protected string correctAnswer_;
        public string CorrectAnswer => correctAnswer_;

        private int value1Base_;
        public int Value1Base
        {
            get => value1Base_;

            set => value1Base_ = GetBaseIfValid(value);
        }

        private int correctAnswerBase_;
        public int CorrectAnswerBase
        {
            get => correctAnswerBase_;

            set => correctAnswerBase_ = GetBaseIfValid(value);
        }

        private byte value1_;
        public byte Value1
        {
            get => value1_;

            set => value1_ = GetByteIfValid(value);
        }

        protected int GetBaseIfValid(int _base)
        {
            return validBases.ContainsKey(_base) ? _base : throw new ArgumentException("Error - Invalid base ", _base.ToString());
        }

        protected byte GetByteIfValid(byte _byte)
        {
            return _byte >= byte.MinValue && _byte <= byte.MaxValue
                ? _byte
                : throw new ArgumentOutOfRangeException("Error - Value is not within the valid range for a byte (0 to 255)", _byte.ToString());
        }

        public int GenerateRandomBase()
        {
            return validBases.ElementAt(random.Next(0, validBases.Count())).Key;
        }

        public byte GenerateRandomByte()
        {
            return Convert.ToByte(random.Next(byte.MinValue, byte.MaxValue + 1));
        }

        public virtual void CalculateCorrectAnswer() { }

        public bool CheckAnswer(string answer)
        {
            return answer == correctAnswer_;
        }

        public Question()
        {
            QuestionType = GenerateRandomQuestionType();
            Operator = GenerateRandomOperator();
            Value1Base = GenerateRandomBase();
            Value2Base = GenerateRandomBase();
            CorrectAnswerBase = GenerateRandomBase();
            Value1 = GenerateRandomByte();
            Value2 = GenerateRandomByte();
            CalculateCorrectAnswer();
        }










        //private string ToBinaryOrDecimal(int value)
        //{
        //    switch (random.Next(0, 2))
        //    {
        //        case 0:
        //            return Convert.ToString(value, 2);
        //        case 1:
        //            return value.ToString();
        //        default:
        //            return "ToBinaryOrDecimal() Failed";
        //    }
        //}



        //public Question(string questionType, int numberSystem) { }

        //public Question(string questionType) { }

        //public Question(int numberSystem) { }

        //public string GenerateQuestion()
        //{
        //    int value1 = random.Next(0, 256);

        //    int value2 = random.Next(0, 256);

        //    string question = "What is ";

        //    switch (random.Next(0, 2))
        //    {
        //        case 0:
        //            switch (random.Next(0, 2))
        //            {
        //                case 0:
        //                    question += "the binary equivelant of " + value1;
        //                    CorrectAnswer = Convert.ToString(value1, 2);
        //                    break;
        //                case 1:
        //                    question += "the decimal equivelant of " + Convert.ToString(value1, 2);
        //                    CorrectAnswer = value1.ToString();
        //                    break;
        //            }
        //            break;
        //        case 1:
        //            switch (random.Next(0, 2))
        //            {
        //                case 0:
        //                    switch (random.Next(0, 4))
        //                    {
        //                        case 0:
        //                            question += ToBinaryOrDecimal(value1) + " + " + ToBinaryOrDecimal(value2);
        //                            CorrectAnswer = (value1 + value2).ToString();
        //                            break;
        //                        case 1:
        //                            question += ToBinaryOrDecimal(value1) + " - " + ToBinaryOrDecimal(value2);
        //                            CorrectAnswer = (value1 - value2).ToString();
        //                            break;
        //                        case 2:
        //                            question += ToBinaryOrDecimal(value1) + " * " + ToBinaryOrDecimal(value2);
        //                            CorrectAnswer = (value1 * value2).ToString();
        //                            break;
        //                        case 3:
        //                            question += ToBinaryOrDecimal(value1) + " / " + ToBinaryOrDecimal(value2);
        //                            CorrectAnswer = (value1 / value2).ToString();
        //                            // might divide by zero
        //                            break;
        //                    }
        //                    question += " in decimal";
        //                    break;
        //                case 1:
        //                    switch (random.Next(0, 4))
        //                    {
        //                        case 0:
        //                            question += ToBinaryOrDecimal(value1) + " + " + ToBinaryOrDecimal(value2);
        //                            CorrectAnswer = Convert.ToString(value1 + value2, 2);
        //                            break;
        //                        case 1:
        //                            question += ToBinaryOrDecimal(value1) + " - " + ToBinaryOrDecimal(value2);
        //                            CorrectAnswer = Convert.ToString(value1 - value2, 2);
        //                            // answer might be negative. ask for answer in decimal?
        //                            break;
        //                        case 2:
        //                            question += ToBinaryOrDecimal(value1) + " * " + ToBinaryOrDecimal(value2);
        //                            CorrectAnswer = Convert.ToString(value1 * value2, 2);
        //                            break;
        //                        case 3:
        //                            question += ToBinaryOrDecimal(value1) + " / " + ToBinaryOrDecimal(value2);
        //                            CorrectAnswer = Convert.ToString(value1 / value2, 2);
        //                            break;
        //                    }
        //                    question += " in binary";
        //                    break;
        //            }
        //            break;
        //    }
        //    question += "?";
        //    return question;
        //}

        //public bool SubmitAnswer(string answer)
        //{
        //    return answer == CorrectAnswer;
        //}

    }
}
