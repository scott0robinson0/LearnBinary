using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnBinaryLibrary
{
    public class Question
    {

        private readonly string[] validQuestionTypes = new string[] { "conversion", "arithmetic" };

        private readonly char[] validOperators = new char[] { '+', '-', '*', '/' };

        private readonly Dictionary<int, string> validBases = new Dictionary<int, string> { { 2, "binary" }, { 10, "decimal" } };

        private readonly Random random = new Random();




        private string correctAnswer_;
        public string CorrectAnswer { get => correctAnswer_; }

        private string questionType_;
        public string QuestionType
        {
            get => questionType_;

            set => questionType_ = validQuestionTypes.Contains(value) ? value : throw new ArgumentException("Error - Invalid question type ", value);
        }


        private char operator_;
        public char Operator
        {
            get => operator_;

            set => operator_ = validOperators.Contains(value) ? value : throw new ArgumentException("Error - Invalid operator ", value.ToString());
        }


        private int value1Base_;
        public int Value1Base
        {
            get => value1Base_;

            set => value1Base_ = GetBaseIfValid(value);
        }


        private int value2Base_;
        public int Value2Base
        {
            get => value2Base_;

            set => value2Base_ = GetBaseIfValid(value);
        }


        private int answerBase_;
        public int AnswerBase
        {
            get => answerBase_;

            set => answerBase_ = GetBaseIfValid(value);
        }


        private byte value1_;
        public byte Value1
        {
            get => value1_;

            set => value1_ = GetByteIfValid(value);
        }


        private byte value2_;
        public byte Value2
        {
            get => value2_;

            set => value2_ = GetByteIfValid(value);
        }



        private int GetBaseIfValid(int _base)
        {
            return validBases.ContainsKey(_base) ? _base : throw new ArgumentException("Error - Invalid base ", _base.ToString());
        }

        private byte GetByteIfValid(byte _byte)
        {
            return _byte >= byte.MinValue && _byte <= byte.MaxValue
                ? _byte
                : throw new ArgumentOutOfRangeException("Error - Value is not within the valid range for a byte (0 to 255)", _byte.ToString());
        }



        public int GenerateRandomBase()
        {
            return validBases.ElementAt(random.Next(0, validBases.Count())).Key;
        }


        public string GenerateRandomQuestionType()
        {
            return validQuestionTypes[random.Next(0, validQuestionTypes.Length)];
        }


        public char GenerateRandomOperator()
        {
            return validOperators[random.Next(0, validOperators.Length)];
        }


        public byte GenerateRandomByte()
        {
            return Convert.ToByte(random.Next(byte.MinValue, byte.MaxValue + 1));
        }


        public void CalculateCorrectAnswer()
        {
            switch (QuestionType)
            {
                case "conversion":
                    correctAnswer_ = Convert.ToString(Value1, AnswerBase);
                    break;
                case "arithmetic":
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
                    break;
            }

        }


        public bool CheckAnswer(string answer)
        {
            return answer == correctAnswer_;
        }


        public override string ToString()
        {
            switch (QuestionType)
            {
                case "conversion":
                    return "What is " + Convert.ToString(Value1, Value1Base) + " in " + validBases[AnswerBase] + "?"; // "What is " is repeated. create string starting with "What is " and append the rest?
                case "arithmetic":
                    return "What is " + Convert.ToString(Value1, Value1Base) + " " + Operator + " " + Convert.ToString(Value2, Value2Base) + " in " + validBases[AnswerBase] + "?";
                default:
                    throw new ArgumentException("Error in ToString() - Invalid question type ", QuestionType);
            }
        }



        public Question()
        {
            QuestionType = GenerateRandomQuestionType();
            Operator = GenerateRandomOperator();
            Value1Base = GenerateRandomBase();
            Value2Base = GenerateRandomBase();
            AnswerBase = GenerateRandomBase();
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
