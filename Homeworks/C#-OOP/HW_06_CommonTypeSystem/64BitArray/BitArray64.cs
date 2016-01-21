namespace BitArray
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    class BitArray64 : IEnumerable<int>
    {
        private const int BITS = 64;
        private ulong number;


        public BitArray64(ulong number)
        {
            this.Number = number;
        }

        public ulong Number
        {
            get { return this.number; }
            set
            {
                if (value < 0 || value > ulong.MaxValue)
                {
                    throw new ArgumentOutOfRangeException("Number out of ulong type range!");
                }
                this.number = value;
            }
        }

        public int Lenght
        {
            get { return BITS; }
        }

        public byte this[int index]
        {
            get
            {
                if (index < 0 || index >= BITS)
                {
                    throw new ArgumentOutOfRangeException("Index not in range [0, 63]");
                }

                return (byte)((this.Number >> index) & 1);
            }

            set
            {
                if (index < 0 || index >= BITS)
                {
                    throw new ArgumentOutOfRangeException("Invalid position: Index not in range [0, 63]!");
                }

                if (value < 0 || value > 1)
                {
                    throw new ArgumentException("Invalid value: Bit value should be 0 or 1!");
                }

                if (value == 0)
                {
                    this.Number = this.Number & (~(((ulong)1) << index));
                }
                else
                {
                    this.Number = this.Number | (((ulong)1) << index);
                }

            }
        }

        public override bool Equals(object obj)
        {
            var other = obj as BitArray64;
            return this.Number.Equals(other.Number);
        }

        public static bool operator ==(BitArray64 firstBitArray, BitArray64 secondBitArray)
        {
            return firstBitArray.Equals(secondBitArray);
        }

        public static bool operator !=(BitArray64 firstBitArray, BitArray64 secondBitArray)
        {
            return !firstBitArray.Equals(secondBitArray);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() + this.Number.GetHashCode();
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < BITS; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            for (int i = 0; i < BITS; i++)
            {
                output.Insert(0, this[i]);
            }
            //for (int i = 63; 0 <= i; i--)
            //{               
            //    output.AppendFormat("{0}", this[i]);
            //}
            return output.ToString();
        }
    }
}
