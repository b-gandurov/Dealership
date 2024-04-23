using Dealership.Core;
using Dealership.Core.Contracts;
using Dealership.Models;
using System;

namespace Dealership
{
    public class Startup
    {
        public static void Main()
        {
            //IRepository repository = new Repository();
            //ICommandFactory commandFactory = new CommandFactory(repository);
            //IEngine engine = new Core.Engine(commandFactory);
            //engine.Start();
            //Car newCar = new Car("Opel", "Vectra", 5000, 1);
            //Console.WriteLine(newCar);
            try
            {
                Motorcycle newMotor = new Motorcycle("Opel", "model", 5000, "heavy");
                Console.WriteLine(newMotor);
            }
            catch (NullReferenceException ex) { 
                Console.WriteLine(ex.ToString());
            }
            
        }
    }
}
