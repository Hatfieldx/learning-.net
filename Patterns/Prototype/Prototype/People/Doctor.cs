using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Prototype.People
{
    [Serializable]
    class Doctor : Person, IAnimalOwner
    {
        public IAnimal Animal { get; set; }

        public object Clone()
        {
            BinaryFormatter bf = new BinaryFormatter();

            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, this);

                ms.Position = 0;
                
                IAnimalOwner person = (IAnimalOwner)bf.Deserialize(ms);

                return person;
            }

            throw new Exception("не удалось скопировать, сорян");
        }

        public void PrintPet()
        {
            if (Animal != null)
            {
                Console.WriteLine($"My animal is {Animal.Name}");
            }

            Animal.Shout();
        }
        
    }
}
