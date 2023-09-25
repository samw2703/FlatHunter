namespace FlatHunter.Console.PropertyFinders;

internal class ExceptionStore
{
    public List<Exception> Exceptions { get; } = new List<Exception>();

    public void Add(Exception exception) => Exceptions.Add(exception);
}