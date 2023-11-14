namespace OpenClose
{
    public class EmployeeFullTime : Employee
    {

        public EmployeeFullTime(string fullname, int hoursWorked)
        {
            Fullname = fullname;
            HoursWorked = hoursWorked;
        }
        public override decimal CalculateSalaryMonth(){
            decimal hourValue = 30000M;
            decimal salary = hourValue * HoursWorked;
            return salary;
        }
    }
}

// Console.WriteLine($"Empleado: {employeeFullTime.Fullname}, Pago: {salary:C1} ");