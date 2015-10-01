namespace MobilePhone
{
    using System;
    using System.Collections.Generic;
    public class Call
    {
        private DateTime dateTime;
        private string dialledNumber;
        private int callDuration;

        public Call()
        {

        }
        public Call(DateTime dateTime, string dialledNumber, int callDuration)
        {
            this.DateTime = dateTime.Date;
            this.DialledNumber = dialledNumber;
            this.CallDuration = callDuration;

        }
        public DateTime DateTime
        {
            get
            {
               return this.dateTime;
            }

            set
            {
                this.dateTime = value;
            }
        }

        public string DialledNumber 
        {
            get
            {
                return this.dialledNumber;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))   // here we can check if a DialledNumber is valid ot not
                {
                    throw new ArgumentNullException("Dialled number cannot be empty!");
                }

                this.dialledNumber = value;
            }
        }

        public int CallDuration 
        {
            get
            {
                return this.callDuration;
            }
            set
            {
                if(value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Call duration cannot be negative number or zero!");
                }

                this.callDuration = value;
            }
        }        

        public override string ToString()
        {
            string returnStr = string.Format(@"Call date: {0:dd/MM/yyyy}
Dialled Number: {1}
Call Duration: {2}
", this.DateTime.Date, this.DialledNumber, this.CallDuration);

            return returnStr;
        }
    }
}
