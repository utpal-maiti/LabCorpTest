namespace EmployeeVacationSystem.App
{
    public abstract class BaseEmployee
    {
        private float vacationDaysAccumulated;

        public float VacationDaysAccumulated
        {
            get { return vacationDaysAccumulated; }
            protected set { vacationDaysAccumulated = Math.Max(0, value); }
        }

        public BaseEmployee()
        {
            VacationDaysAccumulated = 0;
        }

        public abstract void Work(int daysWorked);

        public void TakeVacation(float days)
        {
            if (days <= VacationDaysAccumulated)
            {
                VacationDaysAccumulated -= days;
            }
            else
            {
                throw new ArgumentException("Cannot take more vacation days than accumulated.");
            }
        }
    }
}
