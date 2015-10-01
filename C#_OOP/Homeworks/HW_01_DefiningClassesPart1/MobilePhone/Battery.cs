namespace MobilePhone
{
    using System;
    public enum BatteryType
    {
        LiIon,
        NiMH,
        NiCd,
        Other
    }
    
    public class Battery
    {
        private string model;
        private double hoursIdle;
        private double hoursTalk;
        private BatteryType batteryType;

        public Battery()
        {
            this.Model = null;
            this.HoursIdle = 0.0;
            this.HoursTalk = 0.0;
            //this.BattaryType = new BatteryType();
        }

        public Battery(string model, double hoursIdle, double hoursTalk, BatteryType batteryType)
        {
            this.Model = model;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
            this.BatteryType = batteryType;
        }
        public string Model 
        {
            get 
            {                
                return this.model;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Battary model is empty");
                }

                this.model = value;
            }
        }


        public double HoursTalk 
        {
            get
            {
                return this.hoursTalk;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Talk time cannot be negativ!");
                }

                this.hoursTalk = value;
            }
        }

        public double HoursIdle 
        {
            get
            {
                return this.hoursIdle;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Idle time cannot be negative!");
                }

                this.hoursIdle = value;
            }
        }

       
        public BatteryType BatteryType
        {
            get 
            { 
                return this.batteryType; 
            }
            set 
            {
                if ((value.ToString() != "LiIon") && (value.ToString() != "NiMH") && (value.ToString() != "NiCd") && (value.ToString() != "Other"))
                {
                    throw new ArgumentException("Battary type is wrong!");
                }

                this.batteryType = value; 
            }
        }
        public override string ToString()
        {
            string returnStr = string.Format("(Model: {0}, Hours Idle: {1}, Hours Talk: {2}, Battery Type: {3})", this.Model, this.HoursIdle, this.HoursTalk, this.BatteryType);
            return returnStr;
        }


    }
}
