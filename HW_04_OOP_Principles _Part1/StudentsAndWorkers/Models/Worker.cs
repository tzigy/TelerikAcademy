namespace StudentsAndWorkers.Models
{
    using System;
    using System.Text;
    class Worker : Human
    {
        private const decimal DEFAULT_WEEK_SALARY = 400m;
        private const float DEFAULT_WORK_HOURS_PER_DAY = 7.5f;

        private decimal weekSalary;
        private float workHoursPerDay;

        public Worker(string firstName, string lastName)
            : this(firstName, lastName, DEFAULT_WEEK_SALARY, DEFAULT_WORK_HOURS_PER_DAY)
        {

        }
        public Worker(string firstName, string lastName, decimal weekSalary, float workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal WeekSalary
        {
            get { return this.weekSalary; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Week salary cannot be less than zero!");
                }

                this.weekSalary = value;
            }
        }
        public float WorkHoursPerDay
        {
            get { return this.workHoursPerDay; }
            set
            {
                if (value <= 0 || value > 24)
                {
                    throw new ArgumentOutOfRangeException("value", "Invalid working hours per day!");
                }
                this.workHoursPerDay = value;
            }
        }

        public decimal MoneyPerHour()
        {
            decimal moneyPerHour = this.WeekSalary / (decimal)(5 * this.WorkHoursPerDay);
            return moneyPerHour;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder(base.ToString());
            output.AppendFormat("; Worker; Salary per week: {0}; Work hours per day: {1}; Money per hour: {2:F2}",
                this.WeekSalary,
                this.WorkHoursPerDay,
                this.MoneyPerHour());

            return output.ToString();
        }

    }
}
