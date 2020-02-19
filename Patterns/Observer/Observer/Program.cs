using System;


namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {

            INews news = new News("Some news");

            Notificator<INews> notificator = new NewsNotificator();

            NewsReceiver nr = new NewsReceiver();
            
            Doctor doctor = new Doctor("Ivan", 44);

            doctor.News = nr;

            doctor.News.Unsubscriber = notificator.Subscribe(nr);

            notificator.DoNotify(news);

            notificator.DoNotify(null);

            doctor.News.Unsubscribe();

            Console.ReadKey();
        }
    }
}
