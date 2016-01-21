////Read the README.txt file in main folder to see description of all my changes
namespace EventsCodeFormating
{
    using System;
    using Wintellect.PowerCollections;

    public class EventHolder
    {
        private MultiDictionary<string, Event> groupedByTitle = new MultiDictionary<string, Event>(true);
        private OrderedBag<Event> groupedByDate = new OrderedBag<Event>();

        public void AddEvent(DateTime date, string title, string location)
        {
            Event newEvent = new Event(date, title, location);
            this.groupedByTitle.Add(title.ToLower(), newEvent);
            this.groupedByDate.Add(newEvent);
            Messages.EventAdded();
        }

        public void DeleteEvents(string titleToDelete)
        {
            string title = titleToDelete.ToLower();
            int removed = 0;

            foreach (var eventToRemove in this.groupedByTitle[title])
            {
                removed++;
                this.groupedByDate.Remove(eventToRemove);
            }

            this.groupedByTitle.Remove(title);
            Messages.EventDeleted(removed);
        }

        public void ListEvents(DateTime date, int count)
        {
            OrderedBag<Event>.View eventsToShow = this.groupedByDate.RangeFrom(new Event(date, string.Empty, string.Empty), true);
            int showed = 0;

            foreach (var eventToShow in eventsToShow)
            {
                if (showed == count)
                {
                    break;
                }

                Messages.PrintEvent(eventToShow);
                showed++;
            }

            if (showed == 0)
            {
                Messages.NoEventsFound();
            }
        }
    }
}
