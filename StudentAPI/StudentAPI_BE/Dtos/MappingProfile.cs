using AutoMapper;
using StudentAPI_BE.Models;
using System.Globalization;

namespace StudentAPI_BE.Dtos;

public class MappingProfile : Profile
{   
   public MappingProfile() {
        //chuyển đổi dữ liệu từ model -> DTO : object -> json
        CreateMap<Student, StudentDTO>().ReverseMap();
        CreateMap<Course, CourseDTO>().ReverseMap();

        //ReverseMap chuyển đổi CategoryDTO -> Category
        //CreateMap<CategoryDTO,Category>();

        CreateMap<Student, StudentDTO>().ForMember(
            //d == destination
            d => d.Dob,
            //s == source
            s => s.MapFrom(s => s.Dob.ToString("dd/MM/yyyy"))
                );
            //.ForMember(
            //    d => d.CourseName,
            //    s => s.MapFrom(s => s.Courses) //lưu ý chổ này
            //    );
        
        CreateMap<StudentDTO, Student>().ForMember(
            d => d.Dob,
            s => s.MapFrom(s => DateTime.ParseExact(s.Dob, "dd/MM/yyyy", CultureInfo.InvariantCulture))
                );

    }
}

