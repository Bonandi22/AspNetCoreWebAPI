using SmartSchool.WEBAPI.Helpers;
using SmartSchool.WEBAPI.Models;

namespace SmartSchool.WEBAPI.Data
{
    public interface IRepository
    {
        //All entity
        void Add <T> (T entity) where T: class;
        void Update <T> (T entity) where T: class;
        void Delete <T> (T entity) where T: class;
        bool SaveChanges();

        //Student
        Task<PageList<Student>> GetAllStudentsAsync(
                                        PageParams pageParams,
                                        bool includeTeacher = false);
        Student[] GetAllStudents(bool includeTeacher = false);
        Task <Student> GetStudentByIdAsync( int studentId, bool includeTeacher = false);
        Task <Student>  GetStudentBySubjectAsync(int subjectId, bool includeTeacher = false);        

        //Teacher
        Task<PageList<Teacher>> GetAllTeachersAsync(PageParams pageParams,
                                        bool includeStudent);
        Teacher[] GetAllTeachers (bool includeStudent);
        Task<Teacher> GetTeacherByIdAsync (int teacherId, bool includeStudent = false);
        Task<Teacher> GetTeacherBySubjectAsync (int subjectId, bool includeStudent = false );           

    }
}