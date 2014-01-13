using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOD
{
    namespace FactoryMethod
    {
        public abstract class Pizza
        {
            private string _name;
            private string _dough;
            private string _sauce;

            protected Pizza(string name,string dough, string sauce)
            {
                _name = name;
                _dough = dough;
                _sauce = sauce;
            }
        }

        public class NeapolitanPizza : Pizza
        {
            internal NeapolitanPizza()
                : base("Neapolitan Pizza","Thin Dough","Tomato Sauce")
            {
            }
        }

        public  class LazioPizza : Pizza
        {
            internal LazioPizza()
                : base("Lazio Pizza", "Thick  Dough", "Tomato Sauce")
            {
            }
        }

        public class SicilianPizza : Pizza
        {
            internal SicilianPizza()
                : base("Sicilian Pizza", " Thick crusted and rectangular dough", "Tomato Sauce")
            {
            }
        }

        public class NewYorkSpecialPizza : Pizza
        {
            internal NewYorkSpecialPizza()
                : base("New York Special Pizza", " Thick crusted and rectangular dough", "Time Square Sauce")
            {
            }
        }

        public class BostonSpecialPizza : Pizza
        {
            internal BostonSpecialPizza()
                : base("Boston Special Pizza", " Thick crusted and rectangular dough", "Charles River Sauce")
            {
            }
        }


        public abstract class PizzaStore
        {
            // force subclasses to implement 
            public virtual Pizza CreatePizza(string pizza_name)
            {
                switch (pizza_name)
                {
                    case "Neapolitan": return new NeapolitanPizza();
                    case "LazioPizza": return new LazioPizza();
                    case "Sicilian": return new SicilianPizza();
                    default: throw new ArgumentException("Incorrect type code value"); ;
                }
            }
        }

        public class NewYorkPizzaStore : PizzaStore
        {
            public NewYorkPizzaStore()
            { 
            }

            public override Pizza CreatePizza(string pizza_name)
            {
                switch (pizza_name)
                {
                    case "Neapolitan": return new NeapolitanPizza();
                    case "LazioPizza": return new LazioPizza();
                    case "Sicilian": return new SicilianPizza();
                    case "New York Special Pizza": return new NewYorkSpecialPizza();
                    default: throw new ArgumentException("Invalid pizza name!"); ;
                }

            }
        }

        public class BostonPizzaStore : PizzaStore
        {
            public BostonPizzaStore()
            {
            }

            public override Pizza CreatePizza(string pizza_name)
            {
                switch (pizza_name)
                {
                    case "Neapolitan": return new NeapolitanPizza();
                    case "LazioPizza": return new LazioPizza();
                    case "Sicilian": return new SicilianPizza();
                    case "Boston Special Pizza": return new BostonSpecialPizza();
                    default: throw new ArgumentException("Invalid pizza name!"); ;
                }

            }
        }
    }
}
