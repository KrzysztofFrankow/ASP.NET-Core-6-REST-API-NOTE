using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;
        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [SwaggerOperation(Summary = "Retrieves all notes")]
        [HttpGet]
        public IActionResult Get()
        {
            var notes = _noteService.GetAllNotes();
            return Ok(notes);
        }

        [SwaggerOperation(Summary = "Retrieves a specific note by unique id")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var note = _noteService.GetNoteById(id);
            if(note == null)
            {
                return NotFound();
            }
            return Ok(note);
        }

        [SwaggerOperation(Summary = "Create a new note")]
        [HttpPost]
        public IActionResult Create(CreateNoteDto newNote)
        {
            var note = _noteService.AddNewNote(newNote);
            return Created($"api/notes/{note.Id}", note);
        }

        [SwaggerOperation(Summary = "Update an existing note")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateNoteDto updateNote)
        {
            _noteService.UpdateNote(id, updateNote);
            return NoContent();
        }

        [SwaggerOperation(Summary = "Delete a specific note")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _noteService.DeleteNote(id);
            return NoContent();
        }

        [SwaggerOperation(Summary = "Creates a note comment")]
        [HttpPost("/{noteId:int}/comments")]
        public async Task<IActionResult> GetCommentsAsync(
            [FromRoute] int noteId,
            [FromBody] CreateCommentDto createCommentDto,
            CancellationToken cancellationToken = default)
        {
            createCommentDto.NoteId = noteId;
            var commentDto = await _noteService.AddCommentAsync(createCommentDto, cancellationToken);
            // ToDo: replace with Created, after implementing Get methods
            return Ok(commentDto);
        }
    }
}
