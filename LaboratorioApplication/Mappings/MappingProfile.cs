using AutoMapper;
using LaboratorioDomain.Models;
using LaboratorioApplication.DTOs.Author;
using LaboratorioApplication.DTOs.Book;
using LaboratorioApplication.DTOs.Loan;

namespace LaboratorioApplication.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Author, AuthorDTO>() .ForMember(dest => dest.Books, opt => 
            opt.MapFrom(src => src.Books.Select(b => b.BookId)));
        
        CreateMap<AuthorDTO, Author>();
        CreateMap<Author, AuthorCreateDTO>();
        
        CreateMap<Book, BookDTO>();
        CreateMap<BookDTO, Book>();
        
        CreateMap<Loan, LoanDTO>();
        CreateMap<LoanDTO, Loan>();
        CreateMap<Loan, LoanCreateDTO>();
        CreateMap<Loan, LoanFineDTO>();
    }
}