
namespace Command.FanAdapter
{
    enum AnimalTypes
    {
        Cat,
        Dog,
        Camel,
        Horse
    }

    interface IAnimal
    {
        AnimalTypes Type { get; set; }

        string Name { get; set; }

    }
}
