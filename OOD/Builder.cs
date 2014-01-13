using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOD
{
    namespace BuiderPattern
    {

        //Intent:
        //Separate theconstructionof a complex objectfrom its representation sothat 
        //the same construction processcan create different representations. 
        public interface AnimalBuilder
        {
            void BuildHead();
            void BuildBody();
            // void BuildArms();
            // void BuildLegs();
        }

        public class BirdBuilder : AnimalBuilder
        {
            public void BuildHead() { Console.WriteLine("Bird head builded!"); }
            public void BuildBody() { Console.WriteLine("Bird body builded!"); }
            public void BuildWings() { Console.WriteLine("Bird wings builded!"); }
            // public abstract void BuildArms();
            //  public abstract void BuildLegs();
        }

        public class MammalBuilder : AnimalBuilder
        {
            public void BuildHead() { Console.WriteLine("Mammal head builded!"); }
            public void BuildBody() { Console.WriteLine("Mammal body builded!"); }
            //public void BuildWings() { Console.WriteLine("Bird wings builded!"); }
            // public abstract void BuildArms();
            //  public abstract void BuildLegs();
        }

        public class FishBuilder : AnimalBuilder
        {
            public void BuildHead() { Console.WriteLine("Fish head builded!"); }
            public void BuildBody() { Console.WriteLine("Fish body builded!"); }
            public void BuildFins() { Console.WriteLine("Fish fins builded!"); }
            public void BuildGills() { Console.WriteLine("Fish gills builded!"); }

            // public abstract void BuildArms();
            //  public abstract void BuildLegs();
        }


    }



}
