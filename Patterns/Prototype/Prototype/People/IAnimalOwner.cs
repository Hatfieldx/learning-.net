using System;

namespace Prototype
{
    interface IAnimalOwner: ICloneable
    {
        IAnimal Animal { get; set; }

        void PrintPet();
    }
}
