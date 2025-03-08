using EmployeeVacationSystem.App;

using System.Collections;
using System.Collections.Generic;

namespace EmployeeVacationSystem.Tests
{
    public class EmployeeTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new HourlyEmployee(), 260, 10 };
            yield return new object[] { new SalariedEmployee(), 260, 15 };
            yield return new object[] { new Manager(), 260, 30 };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    public class EmployeeTests
    {
        [Theory]
        [ClassData(typeof(EmployeeTestData))]
        public void Employee_WorkAndTakeVacation(BaseEmployee employee, int daysWorked, float expectedVacationDays)
        {
            employee.Work(daysWorked);
            Assert.Equal(expectedVacationDays, employee.VacationDaysAccumulated);

            employee.TakeVacation(5);
            Assert.Equal(expectedVacationDays - 5, employee.VacationDaysAccumulated);

            Assert.Throws<ArgumentException>(() => employee.TakeVacation(expectedVacationDays - 4));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(261)]
        public void Work_InvalidDays_ThrowsException(int daysWorked)
        {
            var employee = new HourlyEmployee();
            Assert.Throws<ArgumentException>(() => employee.Work(daysWorked));
        }
    }
}