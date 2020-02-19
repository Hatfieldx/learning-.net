using Prototype.IncapsulateActions;
using System;

namespace Prototype
{
    [Serializable]
    class Horse: Animal
    {
        public Horse(string name, int age, int speed) : base(name, age, speed, new HorseActions())
        {

        }
    }
}
