namespace MobilePhone
{
    using System;
    class GSMTest
    {
        public static void Main()
        {
            GSM [] gsmArray = new GSM [3];
            gsmArray[0] = new GSM("Galaxy S5 Plus", "Samsung", 1300, "Piter Pann", new Battery("Samsung 2800mAh", 123, 12, BatteryType.NiMH), new Display(5.1, 16000000));
            gsmArray[1] = new GSM("Z3", "Sony", 990, "Pippi Longstocking", "Sony 3100mAh", 93.8, 52.9, BatteryType.LiIon, 5.2, 16000000);
            gsmArray[2] = GSM.IPhone4S;

            foreach (var gsm in gsmArray)
            {
                Console.WriteLine(gsm.ToString());
            }
        }
    }
}
