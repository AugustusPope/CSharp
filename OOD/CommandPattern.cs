using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOD
{
    namespace  CommandPattern
    {
        public interface Command
        { 
            void Execute();
        }


        public class RemoteController
        {
            private Command _command;
            public RemoteController() { }
            public void SendCommand(Command cmd) { _command = cmd; _command.Execute(); }
        }

        public class Light
        {
            public void On() { Console.WriteLine("Light On!"); }
            public void Off() { Console.WriteLine("Light Off!"); }

        }

        public class AirConditioner
        {
            public void Cool() { Console.WriteLine("AirConditioner is cooling!"); }
            public void Heat() { Console.WriteLine("AirConditioner is heating!"); }
            public void Cold() { Console.WriteLine("AirConditioner is colding!"); }
            public void Off() { Console.WriteLine("AirConditioner is off!"); }
        }

        public class LightOnCommand : Command
        {
            private Light _light;

            public LightOnCommand(Light light)
            {
                _light = light; 
            }

            public void Execute()
            {
                _light.On();
            }


        }

        public class AirConditionerHeatCommand : Command
        { 
            private AirConditioner _airConditioner;

            public AirConditionerHeatCommand(AirConditioner airConditioner)
            {
                _airConditioner = airConditioner; 
            }

            public void Execute()
            {
                _airConditioner.Heat();
            }
        }




    }
}
