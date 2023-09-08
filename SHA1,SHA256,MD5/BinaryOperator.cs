using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHA1_SHA256_MD5
{
    class BinaryOperator
    {
        private byte c;
        private bool carry;
        public byte opA;
        public BinaryOperator(byte a)
        {
            opA = a;
            carry = false;
        }

        public BinaryOperator()
        {
            carry = false;
        }

        public static BinaryOperator operator |(BinaryOperator aOP, BinaryOperator bOP)
        {
            BinaryOperator cOP = new BinaryOperator();
            cOP.opA = (byte)(aOP.opA | bOP.opA);
            return cOP;
        }
        public static BinaryOperator operator &(BinaryOperator aOP, BinaryOperator bOP)
        {
            BinaryOperator cOP = new BinaryOperator();
            cOP.opA = (byte)(aOP.opA & bOP.opA);
            return cOP;
        }
        public static BinaryOperator operator ^(BinaryOperator aOP, BinaryOperator bOP)
        {
            BinaryOperator cOP = new BinaryOperator();
            cOP.opA = (byte)(aOP.opA ^ bOP.opA);
            return cOP;
        }
        public static BinaryOperator operator ~(BinaryOperator aOP)
        {
            BinaryOperator cOP = new BinaryOperator();
            cOP.opA = (byte)~aOP.opA;
            return cOP;
        }
    }
}
