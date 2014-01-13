using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Test
{

    //client class
    class Client
    {

        public static void Main(string[] args)
        {
            OOD.FactoryMethod.NewYorkPizzaStore ny_store = new OOD.FactoryMethod.NewYorkPizzaStore();
            OOD.FactoryMethod.BostonPizzaStore boston_store = new OOD.FactoryMethod.BostonPizzaStore();

            OOD.FactoryMethod.Pizza neapolitan = ny_store.CreatePizza("Neapolitan");
            OOD.FactoryMethod.Pizza lazio = boston_store.CreatePizza("LazioPizza");
            OOD.FactoryMethod.Pizza ny_special = ny_store.CreatePizza("New York Special Pizza");
            OOD.FactoryMethod.Pizza boston_special = boston_store.CreatePizza("Boston Special Pizza");

        }
    }

}
