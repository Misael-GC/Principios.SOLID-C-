using OpenClose;

ShowSalaryMonthly(new List<Employee>() {
    new EmployeeFullTime("Pepito Pérez", 160),
    new EmployeePartTime("Manuel Lopera", 180),
    new EmployeeContractor("Miguel Hidalgo", 200)
});


void ShowSalaryMonthly(List<Employee> employees)
{
    foreach (var employee in employees)
    {
            Console.WriteLine($"Empleado: {employee.Fullname}, Pago: {employee.CalculateSalaryMonth():C1} ");
    }

}