namespace FlatHunter.Console.PropertyFinders;

internal class DavidAndrewPropertyFinder : SimplePropertyFinder
{
    public DavidAndrewPropertyFinder(ExceptionStore exceptionStore) 
        : base(exceptionStore)
    {
    }

    protected override int PreWait { get; set; } = 5;

    protected override string CSSSelector { get; set; } = "div > .panel.panel-default .btn.small-button-font.thumbs-details-button.yellow";

    protected override string GetUrl(string postCode)
        => $"https://www.davidandrew.co.uk/search-grid/?instruction_type=Letting&showstc=on&showsold=on&address_keyword_full_postcode=1&address_keyword={postCode}&minprice=450&maxprice=700&bedrooms=3";
}