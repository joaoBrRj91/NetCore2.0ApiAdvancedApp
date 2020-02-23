namespace JohnStore.Domain.StoreContext.Repositories
{
  public interface ICustomerRepository
  {
    bool CheckDocument(string document);
    bool CheckEmail(string email);
    void Save(Entities.Customer customer);

  }
}