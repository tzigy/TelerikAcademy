namespace MobilePhone
{
    using System;
    using System.Collections.Generic;

    public class GSM
    {
        private static GSM iPhone4S = new GSM("IPhone 4s", "Apple", 1200, "Joe Dow", new Battery("Apple 1432mAh", 587, 345, BatteryType.LiIon), new Display(3.5, 16000000));
        private string model;
        private string manifacturer;
        private decimal price;
        private string owner;
        private Battery battery;
        private Display display;
        private List<Call> callHistory = new List<Call>();
              
        public GSM(string model, string manifacturer)
        {
            this.Model = model;
            this.Manifacturer = manifacturer;
            this.Price = 0.0m;
            this.Owner = null;
            this.Battery = new Battery();
            this.Display = new Display();           
        }
        public GSM(string model, string manifacturer, decimal price, string owner, Battery battery, Display display)
        {
            this.Model = model;
            this.Manifacturer = manifacturer;
            this.Price = price;
            this.Owner = owner;
            this.Battery = battery;
            this.Display = display;
        }

        public GSM(string model, string manifacturer, decimal price, string owner, string batteryModel, double batteryHoursIdle, double batteryHoursTalk, BatteryType batteryType, double displaySize, uint displayNumberOfColors)
        {
            this.Model = model;
            this.Manifacturer = manifacturer;
            this.Price = price;
            this.Owner = owner;
            this.Battery = new Battery(batteryModel, batteryHoursIdle, batteryHoursTalk, batteryType);
            this.Display = new Display(displaySize, displayNumberOfColors);
        }

        public static GSM IPhone4S 
        {
            get
            {
                return iPhone4S;
            }            
        }
        public string Model
        {
            get 
            {
                if (string.IsNullOrEmpty(this.model))
                {
                    throw new NullReferenceException();
                }

                return this.model; 
            }

            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("GSM model cannot be an empty string!");
                }

                this.model = value; 
            }
        }

        public string Manifacturer
        {
            get
            {
                if (string.IsNullOrEmpty(this.manifacturer))
                {
                    throw new NullReferenceException();
                }
                return this.manifacturer;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("GSM manifacturer cannot be an empty string!");
                }

                this.manifacturer = value;
            }
        }

        

        public decimal Price
        {
            get 
            { 
                return this.price; 
            }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Price cannot be less than 0!");
                }

                this.price = value; 
            }
        }


        public string Owner 
        {
            get
            {
                return this.owner;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    this.owner = "no owner";
                }

                this.owner = value;
            }
        }

        public Battery Battery 
        {
            get
            {
                return this.battery;
            }
            set
            {
                this.battery = value;
            }
        }

        public Display Display 
        {
            get
            {
                return this.display;
            }
            set
            {
                this.display = value;
            }
        }

        public List<Call> CallHistory 
        {
            get
            {
                return new List<Call>(this.callHistory);
            }             
        }

        public void AddCall(Call call)
        {
            this.callHistory.Add(call);
        }

        public void DeleteCall(Call call)
        {
            this.callHistory.Remove(call);
        }

        public void ClearCallHistory()
        {
            this.callHistory.Clear();
        }

        public decimal CalculateTotalCallPrice(decimal pricePerMinute, List<Call> callsHistory)
        {
            decimal totalCallPrice = 0.0m;

            for (int i = 0; i < callsHistory.Count; i++)
            {
                totalCallPrice += (decimal)(callsHistory[i].CallDuration / 60) * pricePerMinute;
            }

            return totalCallPrice;
        }
        public override string ToString()
        {
            string returnStr = String.Format(@"GSM model: {0}
GSM manifacturer: {1}
GSM price: {2}
GSM owner: {3}
GSM battery: {4}
GSM display: {5}
", this.Model, this.Manifacturer, this.Price, this.Owner, this.Battery.ToString(), this.Display.ToString());

            return returnStr;
        }
    }
}
