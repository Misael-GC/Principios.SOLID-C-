namespace InterfaceSegregation
{
    public interface IActivities : IWorkTeamActivities, IDesignActivities, IDevelopActivities, ITestActivities
    {
        // Vamos a tener o heredar toda la implementación de las demas interfaces
    }
}