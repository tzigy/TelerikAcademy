namespace MobilePhone
{
    using System;
    public class Display
    {
        private const double minDisplaySize = 1;
        private const double maxDisplaySize = 10;
        private const uint minNumberOfColor = 2; 


        private double size;
        private uint numberOfColors;

        public Display()
        {
            this.Size = 0.0;
            this.NumberOfColors = 0;
        }

        public Display(double size, uint numberOfColors)
        {
            this.Size = size;
            this.NumberOfColors = numberOfColors;
        }

        public double Size { 
            get 
            {
                return this.size;    
            }

            set
            {
                if (value < minDisplaySize || value > maxDisplaySize)
                {
                    throw new ArgumentOutOfRangeException("Not valid display size!");
                }

                this.size = value;
            }
        }

        public uint NumberOfColors 
        {
            get 
            { 
                return this.numberOfColors; 
            }
            set 
            {
                if (value < minNumberOfColor)
                {
                    throw new ArgumentException("Wrong input - number of colors!");
                }

                this.numberOfColors = value;
            } 
        }

        public override string ToString()
        {
            string returnStr = string.Format("(Size: {0}, Number of colors: {1})", this.Size, this.NumberOfColors);
            return returnStr;
        }
    }
}
