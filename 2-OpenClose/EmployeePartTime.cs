namespace OpenClose
{
    public class EmployeePartTime : Employee
    {

        public EmployeePartTime(string fullname, int hoursWorked)
        {
            Fullname = fullname;
            HoursWorked = hoursWorked;
        }        
        public override decimal CalculateSalaryMonth()
        {
            decimal hourValue = 20000M;
            decimal salary = hourValue * HoursWorked;
            return salary;
        }
    }
}