////Read the README.txt file in main folder to see description of all my changes
namespace EventsCodeFormating
{
    using System;
    using System.Text;

    public static class Messages
    {
        private static StringBuilder output = new StringBuilder();

        public static void EventAdded()
        {
            output.Append("Event added" + Environment.NewLine);
        }

        public static void EventDeleted(int x)
        {
            if (x == 0)
            {
                NoEventsFound();
            }
            else
            {
                output.AppendFormat("{0} events deleted{1}", x, Environment.NewLine);
            }
        }

        public static void NoEventsFound()
        {
            output.Append("No events found" + Environment.NewLine);
        }

        public static void PrintEvent(Event eventToPrint)
        {
            if (eventToPrint != null)
            {
                output.Append(eventToPrint + Environment.NewLine);
            }
        }
    }
}
