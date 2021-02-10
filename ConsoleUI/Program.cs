using Business.concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
                Console.WriteLine(car.DailyPrice);
                Console.WriteLine(car.ModelYear);
            }
            
        }
    }
}
