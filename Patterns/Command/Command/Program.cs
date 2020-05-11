using System;
using Command.FanDecorator;

namespace Command
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. Нужен интерфейс ICommand, который содержит Execute and Undo
            //2. Нужен класс, реализующий этот интерфейс
            //3. Нужен класс инициатор, который будет создавать экземпляр Исполнителя и вызывать комманды
            //4. Нужен класс, который инкапсулирует выполняемые действия

            //Конкретная комманда содержит рессивер (агрегация). Рессивер устанавливается в конструкторе. 
            // В рессивере находится реализация методов.
            // Конкретная комманда вызывается методы рессивера!
            // Есть клас Инвокер, который содержит ссылку на класс каманды. получает ссылку через метод SetCommand
            // Инвокер содержит методы Run и Cancel, которые вызывают Execute и Undo у комманды, которыя вызывает конкретную реализацию у ресивера.


            //Состояние паттерн состоит из двух сущностей: Контекст и Состояние. Контекст это объект, который переходит из одного состояния в другое, 
            // Для каждого состояния объекта должен быть реализован класс, реализоция которого должна переводить объект из одного состояния в другое.

            Person p = new Person("Ivan", 44, new NormalStatus());

            p.DoAction();

            p.DoAction();

            p.DoAction();

            p.DoAction();

            p.DoAction();

            p.DoAction();

            p.DoRelax();

            p.DoRelax();

            p.DoRelax();

            p.DoRelax();

            p.DoRelax();

            
            
            //decor

            Car batman = new BatmanCar("Batman car", 8);
                       
            batman.GetPrice();

            batman.Drive();

            CarDecorator newBat = new BatmanCarDecorate("Upgraded Batman", 12, batman);

            newBat.GetPriceAdd();

            newBat.DriveAdd();

            Console.ReadKey();
        }
    }
}
