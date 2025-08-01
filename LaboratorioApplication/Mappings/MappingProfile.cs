// LaboratorioApplication/Mappings/MappingProfile.cs
using AutoMapper;
using LaboratorioDomain.Models;
using LaboratorioApplication.DTOs;

namespace LaboratorioApplication.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Author, AuthorDTO>();
        CreateMap<AuthorDTO, Author>();
        CreateMap<Author, AuthorCreateDTO>();
        CreateMap<Book, BookDTO>();
        CreateMap<BookDTO, Book>();
        CreateMap<Loan, LoanDTO>();
        CreateMap<LoanDTO, Loan>();
    }
}