using JohnStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JohnStore.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        private Document validDocument;
        private Document inValidDocument;

        public DocumentTests()
        {
            validDocument = new Document("28659170377");
            inValidDocument = new Document("2865917037");
        }

        [TestMethod]
        public void ShouldReturnNotificationWhenDocumentIsNotValid()
        {
            Assert.AreEqual(true, inValidDocument.Invalid);
            Assert.AreEqual(1, inValidDocument.Notifications.Count);
        }

        [TestMethod]
        public void ShouldReturnNotNotificationWhenDocumentIsValid()
        {
            Assert.AreEqual(true, validDocument.IsValid);
            Assert.AreEqual(0, validDocument.Notifications.Count);
        }

    }
}