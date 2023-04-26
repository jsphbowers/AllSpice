namespace AllSpice.Interfaces;

public interface IRepository<T>
{
  List<T> Get();

  T GetOne(int id);

  T Generate(T postData);

  int Update(T UpdateData);

  int Remove(int id);
}
