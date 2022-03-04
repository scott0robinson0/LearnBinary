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

        public ushort Add()
        {
            return (ushort)(value1_ + value2_);
        }

        public ushort Sub()
        {
            return (ushort)(value1_ - value2_);
        }

        public ushort Mul()
        {
            return (ushort)(value1_ * value2_);
        }

        public ushort Div()
        {
            return (ushort)(value1_ / value2_);
        }

        public static ushort Add(byte value1, byte value2)
        {
            return (ushort)(value1 + value2);
        }
    }
}
