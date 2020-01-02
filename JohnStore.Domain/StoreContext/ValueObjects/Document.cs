using FluentValidator;
using FluentValidator.Validation;
using JohnStore.Domain.StoreContext.Enums;

namespace JohnStore.Domain.StoreContext.ValueObjects
{
    public class Document : Notifiable
    {
        private Document(){}
        public Document(string number)
        {
            Number = number;
              AddNotifications(
                new ValidationContract()
                .IsTrue(DocumentIsValid(Number),"","Documento no formato Inválido."));
        }

        public string Number { get; private set; }
        public EDocumentType DocumentType  { get; private set; }

        public bool DocumentIsValid(string number,EDocumentType documentType = EDocumentType.CPF)
        {
            return true;
        } 
    }
}