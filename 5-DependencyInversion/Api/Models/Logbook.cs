using System.Text;

namespace DependencyInversion
{
    public class Logbook : ILoggable
    {
        public void Add(string description)
        {
            File.AppendAllText(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logbook.txt"), $"{description}\n", Encoding.Unicode);
        }
    }
    public interface ILoggable
    {
        void Add(string description);
    }
}