using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnBinaryLibrary
{
    public class Calculator
    {
        private byte value1_ = byte.MinValue;
        private byte value2_ = byte.MinValue;

        public Calculator(byte val1, byte val2)
        {
            value1_ = val1;
            value2_ = val2;
        }

        public byte Add()
        {
            return (byte)(value1_ + value2_);
        }

        public byte Sub()
        {
            return (byte)(value1_ - value2_);
        }

        public byte Mul()
        {
            return (byte)(value1_ * value2_);
        }

        public byte Div()
        {
            return (byte)(value1_ / value2_);
        }
    }
}
