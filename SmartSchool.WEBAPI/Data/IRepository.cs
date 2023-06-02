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
         Student[] GetAllStudents(bool includeTeacher);
         Student GetStudentById( int studentId, bool includeTeacher = false);
         Student GetStudentBySubject(int subjectId, bool includeTeacher = false);        

        //Teacher

        Teacher[] GetAllTeachers(bool includeStudent);
         Teacher GetTeacherById(int teacherId, bool includeStudent = false);
         Teacher GetTeacherBySubject(int subjectId, bool includeStudent = false );
         
       



    }
}