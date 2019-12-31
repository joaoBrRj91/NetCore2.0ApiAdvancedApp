namespace JohnStore.Domain.StoreContext.ValueObjects
{
    public class Document
    {
        private Document(){}
        public Document(string number)
        {
            Number = number;
        }

        public string Number { get; private set; }
    }
}