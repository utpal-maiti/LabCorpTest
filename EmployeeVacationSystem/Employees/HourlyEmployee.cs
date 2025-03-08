namespace EmployeeVacationSystem.App;

public class HourlyEmployee : BaseEmployee
{
    private const float VacationDaysPerYear = 10;
    private const int WorkDaysPerYear = 260;

    public override void Work(int daysWorked)
    {
        if (daysWorked < 0 || daysWorked > WorkDaysPerYear)
        {
            throw new ArgumentException("Days worked must be between 0 and 260.");
        }

        VacationDaysAccumulated += (VacationDaysPerYear / WorkDaysPerYear) * daysWorked;
    }
}
