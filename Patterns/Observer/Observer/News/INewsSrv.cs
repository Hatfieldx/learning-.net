
namespace Observer
{
    interface INews
    {
        string Newspapier { get; set; }
               
        //TODO запилить поле с нотификатором!

        void SendNewspapier();
                
    }
}
