public abstract class Media : IReadable
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Author { get; set; }

    public abstract void DisplayInformation();
}
