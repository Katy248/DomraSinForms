namespace DomraSin.Domain.Models.FormItems;

public class PictureItem : FormItem<PictureItemId>
{
    public string PictureLink { get; set; }
    public string AltText { get; set; }
}

public readonly record struct PictureItemId : FormItemId;