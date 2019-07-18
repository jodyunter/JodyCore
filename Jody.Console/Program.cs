using System;
using Jody.Services.Configuration;
using System.Linq;

namespace JodyConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceConfiguration serviceConfig = new ServiceConfiguration();            
            serviceConfig.TeamService.GetAll().ToList().ForEach(r => { Console.WriteLine(r.Name); });
            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
