using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interview
{
    public static class General
    {
        public static int RecursiveFibonacci(int index) {
            if (index.GetType() != typeof(int)) throw new ArgumentException("Parameter must be int!", "Index");
            else {
                if (index == 0) return 0;
                else if (index == 1) return 1;
                else return (RecursiveFibonacci(index - 2) + RecursiveFibonacci(index - 1));
            }
        }


        public static int Fibonacci(int index) { 
            if (index.GetType() != typeof(int)||index<0) throw new ArgumentException("Parameter must be positive int!", "Index");
            else {
                 if (index == 0) return 0;
                 if (index == 1) return 1;
                int preTwo = 0;
                int preOne = 1;
                int curValue = preTwo+preOne;
                for (int curIndex = 2; curIndex < index; curIndex++) { 
                    preTwo = preOne;
                    preOne = curValue;
                    curValue = preOne + preTwo;                
                }

                return curValue;
            }

        }
    }
}
