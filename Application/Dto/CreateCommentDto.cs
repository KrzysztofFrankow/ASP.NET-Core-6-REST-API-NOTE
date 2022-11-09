namespace Application.Dto;

public class CreateCommentDto
{
    public int NoteId { get; set; }
    
    public string AuthorName { get; set; }
    
    public string Content { get; set; }
}