namespace GSMCallHistoryTest
{
    using System;
    using MobilePhone;
    using System.Collections.Generic;
    public class GSMCallHistoryTest
    {
        private const decimal callPricePerMinute = 0.37m;

        static void Main()
        {
            GSM phone = new GSM("Z3", "Sony", 990, "Pippi Longstocking", "Sony 3100mAh", 93.8, 52.9, BatteryType.LiIon, 5.2, 16000000);
            phone.AddCall(new Call(DateTime.Now, "+359 (0) 894 733 124", 287));
            phone.AddCall(new Call(DateTime.Now, "+359 (0) 894 788 134", 123));
            phone.AddCall(new Call(DateTime.Now.AddDays(-12), "+359 (0) 894 733 114", 90));

            PrintCallHistory(phone);

            Console.WriteLine("The total price of all calls of {0} is {1} EUR!", phone.Owner, CalculateTotalCallPrice(phone.CallHistory, callPricePerMinute));

            Console.WriteLine("The total price of all calls without the longest call of {0} is {1} EUR!", phone.Owner, CalculateTotalCallPrice(RemoveLongestCall(phone.CallHistory), callPricePerMinute));

            phone.ClearCallHistory();

            PrintCallHistory(phone);
        }

        public static void PrintCallHistory(GSM phone)
        {
            if (phone.CallHistory.Count == 0)
            {
                Console.WriteLine("The call history of {0} is Empty!", phone.Owner);
            }
            else
            {
                List<Call> callHistory = phone.CallHistory;
                Console.WriteLine("The call history of {0}:", phone.Owner);
                foreach (var call in callHistory)
                {
                    Console.WriteLine(call.ToString());
                }
            }
        }
        public static int CalculateTotalCallDuration(List<Call> callsHistory)
        {
            int totalCallsDuration = 0;

            foreach (Call call in callsHistory)
            {
                totalCallsDuration += call.CallDuration;
            }

            return totalCallsDuration;
        }

        public static decimal CalculateTotalCallPrice(List<Call> callHistory, decimal pricePerMinute)
        {
            int totalCallsDuration = CalculateTotalCallDuration(callHistory);
            return (totalCallsDuration / 60) * pricePerMinute;
        }

        public static List<Call> RemoveLongestCall(List<Call> callHistory)
        {
            Call longestCall = new Call();
            longestCall = callHistory[0];

            for (int i = 0; i < callHistory.Count; i++)
            {
                if (longestCall.CallDuration < callHistory[i].CallDuration)
                {
                    longestCall = callHistory[i];
                }
            }

            callHistory.Remove(longestCall);

            return callHistory;
        }
        
    }
}
