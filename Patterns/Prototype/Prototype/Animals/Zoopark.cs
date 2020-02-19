
using System;
using System.Collections.Generic;

namespace Prototype.Animals
{
    class Zoopark
    {
        List<IAnimal> animals;

        //readonly string name;

        public IAnimal this[int index]
        {
            get
            {
                if (index < 0 || index > animals.Count - 1)
                    throw new IndexOutOfRangeException();

                return animals[index];
            }
            set 
            {
                if (index < 0 || index > animals.Count - 1)
                    throw new IndexOutOfRangeException();
                animals[index] = value;
            }
        }

        readonly static Lazy<Zoopark> zooInst = new Lazy<Zoopark>();
        
        public static Zoopark Current()
        {       
          return zooInst.Value;
        }

        private Zoopark()
        {
            animals = new List<IAnimal>() {

            new Dog("Lokki", 1, 20),

            new Horse("LOSHADKA", 1, 20),

            new Camel("VERBLUDE", 1, 20)
            
            };
        }
    }
}
