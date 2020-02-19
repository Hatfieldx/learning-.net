using Prototype.IncapsulateActions;

namespace Prototype
{
    class Camel:Animal
    {
        public Camel(string name, int age, int speed) :base(name, age, speed, new CamelActions())
        {
            
        }
    }
}
