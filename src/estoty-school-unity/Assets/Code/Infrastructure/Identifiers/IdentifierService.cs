namespace Code.Infrastructure.Identifiers
{
  public class IdentifierService : IIdentifierService
  {
    private int _lastId;

    public int Next() => _lastId += 1;
  }
}