
namespace Observer
{
    class News : INews
    {
        public string Newspapier { get; set; }

        public void SendNewspapier()
        {
            //throw new NotImplementedException();
        }

        public News(string news)
        {
            Newspapier = news;
        }
    }
}
