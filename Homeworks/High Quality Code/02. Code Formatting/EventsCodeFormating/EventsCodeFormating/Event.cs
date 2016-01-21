////Read the README.txt file in main folder to see description of all my changes
namespace EventsCodeFormating
{
    using System;
    using System.Text;

    public class Event : IComparable
    {
        private const string DateTimeFormat = "yyyy-MM-ddTHH:mm:ss";
        private DateTime date;
        private string title;
        private string location;

        public Event(DateTime date, string title, string location)
        {
            this.Date = date;
            this.Title = title;
            this.Location = location;
        }

        public DateTime Date { get; set; }

        public string Title { get; set; }

        public string Location { get; set; }

        public int CompareTo(object obj)
        {
            Event other = obj as Event;
            int comparedByDate = this.date.CompareTo(other.date);
            int comparedByTitle = this.title.CompareTo(other.title);
            int comparedByLocation = this.location.CompareTo(other.location);

            if (comparedByDate == 0)
            {
                if (comparedByTitle == 0)
                {
                    return comparedByLocation;
                }
                else
                {
                    return comparedByTitle;
                }
            }
            else
            {
                return comparedByDate;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(this.date.ToString(DateTimeFormat));
            result.Append(" | " + this.title);

            if (this.location != null && this.location != string.Empty)
            {
                result.Append(" | " + this.location);
            }

            return result.ToString();
        }
    }
}
