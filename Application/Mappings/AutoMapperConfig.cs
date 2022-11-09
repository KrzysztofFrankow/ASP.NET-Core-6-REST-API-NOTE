using Application.Dto;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                #region Notes

                cfg.CreateMap<Comment, CommentDto>();
                cfg.CreateMap<Note, NoteDto>();
                cfg.CreateMap<CreateNoteDto, Note>();
                cfg.CreateMap<UpdateNoteDto, Note>();

                #endregion
            }).CreateMapper();
    }
}
