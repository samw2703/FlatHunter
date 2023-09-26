namespace FlatHunter.Console.PropertyFinders;

internal class JeremyLeafPropertyFinder : SimplePropertyFinder
{
    public JeremyLeafPropertyFinder(ExceptionStore exceptionStore)
        : base(exceptionStore)
    {
    }

    protected override string CSSSelector { get; set; } = "div > .list-item-content > a";

    protected override string GetUrl(string postCode)
        => $"https://www.jeremyleaf.co.uk/london/{postCode}/lettings/from-3-bed/up-to-3-bed/up-to-3000#/";
}