using Prototype.IncapsulateActions;

namespace Prototype
{
    class Dog:Animal
    {
        public Dog(string name, int age, int speed) : base(name, age, speed, new DogActions())
        {

        }
    }
}
