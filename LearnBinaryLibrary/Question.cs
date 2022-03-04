using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnBinaryLibrary
{
    public class Question
    {

        private Random random_ = new Random();

        private string correctAnswer_ = "";

        private string ToBinaryOrDecimal(int value)
        {
            switch (random_.Next(0, 2))
            {
                case 0:
                    return Convert.ToString(value, 2);
                case 1:
                    return value.ToString();
                default:
                    return "ToBinaryOrDecimal() Failed";
            }
        }

        public Question() { }

        public string GenerateQuestion()
        {
            int value1 = random_.Next(0, 256);

            int value2 = random_.Next(0, 256);

            string question = "What is ";

            switch (random_.Next(0, 2))
            {
                case 0:
                    switch (random_.Next(0, 2))
                    {
                        case 0:
                            question += "the binary equivelant of " + value1;
                            correctAnswer_ = Convert.ToString(value1, 2);
                            break;
                        case 1:
                            question += "the decimal equivelant of " + Convert.ToString(value1, 2);
                            correctAnswer_ = value1.ToString();
                            break;
                    }
                    break;
                case 1:
                    switch (random_.Next(0, 2))
                    {
                        case 0:
                            switch (random_.Next(0, 4))
                            {
                                case 0:
                                    question += ToBinaryOrDecimal(value1) + " + " + ToBinaryOrDecimal(value2);
                                    correctAnswer_ = (value1 + value2).ToString();
                                    break;
                                case 1:
                                    question += ToBinaryOrDecimal(value1) + " - " + ToBinaryOrDecimal(value2);
                                    correctAnswer_ = (value1 - value2).ToString();
                                    break;
                                case 2:
                                    question += ToBinaryOrDecimal(value1) + " * " + ToBinaryOrDecimal(value2);
                                    correctAnswer_ = (value1 * value2).ToString();
                                    break;
                                case 3:
                                    question += ToBinaryOrDecimal(value1) + " / " + ToBinaryOrDecimal(value2);
                                    correctAnswer_ = (value1 / value2).ToString();
                                    break;
                            }
                            question += " in decimal";
                            break;
                        case 1:
                            switch (random_.Next(0, 4))
                            {
                                case 0:
                                    question += ToBinaryOrDecimal(value1) + " + " + ToBinaryOrDecimal(value2);
                                    correctAnswer_ = Convert.ToString(value1 + value2, 2);
                                    break;
                                case 1:
                                    question += ToBinaryOrDecimal(value1) + " - " + ToBinaryOrDecimal(value2);
                                    correctAnswer_ = Convert.ToString(value1 - value2, 2);
                                    break;
                                case 2:
                                    question += ToBinaryOrDecimal(value1) + " * " + ToBinaryOrDecimal(value2);
                                    correctAnswer_ = Convert.ToString(value1 * value2, 2);
                                    break;
                                case 3:
                                    question += ToBinaryOrDecimal(value1) + " / " + ToBinaryOrDecimal(value2);
                                    correctAnswer_ = Convert.ToString(value1 / value2, 2);
                                    break;
                            }
                            question += " in binary";
                            break;
                    }
                    break;
            }
            question += "?";
            return question;
        }

        public bool CheckAnswer(string answer)
        {
            return answer == correctAnswer_;
        }

    }
}
