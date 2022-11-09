namespace Domain.Entities;

public class Comment
{
    public int Id { get; set; }
    
    public string AuthorName { get; set; }
    
    public string Content { get; set; }
    
    public DateTime CreationTimestampUtc { get; set; }
}