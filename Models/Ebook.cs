public class Ebook : Media
{
    public string? FileFormat { get; set; } 

    public override void DisplayInformation()
    {
        Console.WriteLine($"[Ebook] {Title} - {Author} ({FileFormat})");
    }
}
