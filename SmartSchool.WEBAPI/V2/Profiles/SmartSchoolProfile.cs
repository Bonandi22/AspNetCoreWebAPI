using AutoMapper;
using SmartSchool.WEBAPI.Helpers;
using SmartSchool.WEBAPI.Models;
using SmartSchool.WEBAPI.V1.Dtos;

namespace SmartSchool.WEBAPI.V2.Helpers
{
    public class DataContextProfile: Profile
    {
        public DataContextProfile()
        {
            //Students
            CreateMap<Student, StudentDto>()
            .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => $"{src.Name} {src.Surname}")            
            )
            .ForMember(
                dest => dest.Age,
                opt => opt.MapFrom(src => src.BirthDate.GetCurrentAge())
            );
            CreateMap<StudentDto, Student>();
            CreateMap<Student, StudentRegisterDto>().ReverseMap();

            //Teachers
            CreateMap<Teacher, TeacherDto>()
            .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => $"{src.Name} {src.Surname}")            
            );

             CreateMap<TeacherDto, Teacher>();
            CreateMap<Teacher, TeacherRegisterDto>().ReverseMap();





        }
    }
}