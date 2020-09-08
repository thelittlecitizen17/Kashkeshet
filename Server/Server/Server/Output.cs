using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    class Output
    {

        public void Print<T>(List<T> options)
        {
            Console.WriteLine("\nPlease enter the number of your choice\n");
            foreach(var option in options)
            {
                Console.WriteLine($"{option}\n");
            }
        }
        public void Print<T>(T value)
        {
            Console.WriteLine($"{value}\n");
        }
    }
}
