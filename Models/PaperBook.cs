public class PaperBook : Media
{
    public int NumberOfPages { get; set; }

    public override void DisplayInformation()
    {
        Console.WriteLine($"[Livre papier] {Title} - {Author}, {NumberOfPages} pages");
    }
}
