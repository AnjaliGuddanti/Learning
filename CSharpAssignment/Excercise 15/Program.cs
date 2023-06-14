using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.ObjectModel;

namespace Exercise15
{
    class Program
    {
        static void Main(string[] args)
        {

            ObservableCollection<string> carModel = new ObservableCollection<string>
                {
                "BMW",
                "AUDI",
                "BENTLEY",
                "JEEP"
                };

            carModel.CollectionChanged += CarModelChanged;



            carModel.Remove("AUDI");
            Console.WriteLine("\nAfter removing AUDI car remaing cars present in the collection: ");
            foreach (var cars in carModel)
            {
                Console.WriteLine(cars);
            }



            carModel.Add("NISSAN");
            Console.WriteLine("\nAfter adding a car the collection of cars: ");
            foreach (var cars in carModel)
            {
                Console.WriteLine(cars);
            }
            Console.ReadLine();
        }
        private static void CarModelChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs car)
        {



            if (car.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                if (car.OldItems != null)
                {
                    foreach (var i in car.OldItems)
                    {
                        Console.WriteLine("\n{0} is removed form collection", i);
                    }
                }
            }
            if (car.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                if (car.NewItems != null)
                {
                    foreach (var i in car.NewItems)
                    {
                        Console.WriteLine("\n{0} is added to collection", i);
                    }
                }

            }

        }
    }
}