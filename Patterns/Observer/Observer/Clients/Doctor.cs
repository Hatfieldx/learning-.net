using System;

namespace Observer
{
    class Doctor : Person
    {
        public override NewsReceiver News
        {
            get => news;

            set
            {
                news = value;

                if (value == null)
                {
                    return;
                }

                news.newsHandler += (sender, args) => Console.WriteLine($"Я доктор и я получил новости: {((ObserverEventArgs)args).News.Newspapier}");

                news.newsErrorHandler += (sender, args) => Console.WriteLine($"Я доктор и я получил ERROR: {((ObserverEventArgs)args).Message}");
            }
        }

        public Doctor(string name, int age) : base(name, age)
        {

        }
    }
}
