using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOD
{
    namespace DecoratorPattern
    {
        public abstract class Beverage
        {
            public Beverage() { }
            public string Description { get; protected set; }
            public virtual double Cost { get; protected set; }
        }

        //CondimentDecorator is a decorator for instances of Beverage
        public abstract class CondimentDecorator : Beverage
        {           
            private Beverage _beverage;// an beverage instance we are going to wrap
            public CondimentDecorator(Beverage bev) { _beverage = bev; } //Constructor   
        }

        public class Expresso : Beverage
        {
            public Expresso()
            {
                 Description = "Expresso"; 
                 _cost =  1.99;   
            }
            public override double Cost { get { return _cost; } protected set { _cost = value; } }
            private double _cost;
        }

        public class HouseBlend : Beverage
        {
            public HouseBlend()
            {
                Description = "House Blend Coffee";
                _cost = 0.89;  
            }
            public override double Cost { get { return _cost; } protected set { _cost = value; } }
            private double _cost;
        }

        public class Milk : CondimentDecorator
        {
            public Milk(Beverage bev):base(bev)
            {
               Description = bev.Description + ",Milk"; 
               Cost = bev.Cost + 0.68;
            }
        }

        public class Chocolate : CondimentDecorator
        {
            public Chocolate(Beverage bev ):base(bev)
            {
                if (bev != null) { this.Description = bev.Description + ",Chocolate"; this.Cost = bev.Cost + 1.03; }
                else { this.Description = "Chocolate"; this.Cost = 1.03; }
            }
        }

    }
}

