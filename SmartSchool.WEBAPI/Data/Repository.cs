using Microsoft.EntityFrameworkCore;
using SmartSchool.WEBAPI.Helpers;
using SmartSchool.WEBAPI.Models;

namespace SmartSchool.WEBAPI.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;      

        public Repository(DataContext context)
        {
            _context = context;            
        }        
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >0);
        }
        
        //Students
        public Student[] GetAllStudents(bool includeTeacher = false)
        {
            IQueryable<Student> query = _context.Students;

            if(includeTeacher){
                query = query.Include(s=> s.StudentSubjects)
                .ThenInclude(ss => ss.Subject)
                .ThenInclude(s => s.Teacher);
            }
            query = query.AsNoTracking().OrderBy(s => s.Id);
            
            return query.ToArray();
        }
        public async Task<PageList<Student>> GetAllStudentsAsync(
                                        PageParams pageParams,
                                        bool includeTeacher = false)
        {
            IQueryable<Student> query = _context.Students;

            if(includeTeacher){
                query = query.Include(s=> s.StudentSubjects)
                .ThenInclude(ss => ss.Subject)
                .ThenInclude(s => s.Teacher);
            }
            query = query.AsNoTracking().OrderBy(s => s.Id);
           
            if (!string.IsNullOrEmpty(pageParams.Name))
                query = query.Where(student => student.Name
                                                  .ToUpper()
                                                  .Contains(pageParams.Name.ToUpper()) ||
                                                student.Surname
                                                  .ToUpper()
                                                  .Contains(pageParams.Name.ToUpper()));

            if (pageParams.Enroll > 0)
                query = query.Where(student => student.Enroll == pageParams.Enroll);

            if (pageParams.Active != null)
                query = query.Where(student => student.Active == (pageParams.Active != 0));                

         
            
             // return await query.ToListAsync();
            return await PageList<Student>.CreateAsync(query, pageParams.PageNumber, pageParams.PageSize);
        }
        public async Task<Student> GetStudentByIdAsync( int studentId, bool includeTeacher = false)
        {
            IQueryable<Student> query = _context.Students;

            if(includeTeacher){
                query = query.Include(s=> s.StudentSubjects)
                .ThenInclude(ss => ss.Subject)
                .ThenInclude(s => s.Teacher);
            }
            query = query.AsNoTracking()
                        .OrderBy(s => s.Id)
                        .Where(s => s.Id == studentId);
            
            return await Task.FromResult(query.FirstOrDefault());
        }

        public async Task<Student> GetStudentBySubjectAsync(int subjectId, bool includeTeacher = false)
        {
             IQueryable<Student> query = _context.Students;

            if(includeTeacher){
                query = query.Include(s=> s.StudentSubjects)
                .ThenInclude(ss => ss.Subject)
                .ThenInclude(s => s.Teacher);
            }
            query = query.AsNoTracking()
                        .OrderBy(s => s.Id)
                        .Where(s => s.StudentSubjects.Any(ss => ss.SubjectId == subjectId));
            
            return await Task.FromResult(query.FirstOrDefault());
        }

        //Teachers
        public Teacher[] GetAllTeachers(bool includeStudent)
        {
            IQueryable<Teacher> query = _context.Teachers;

            if(includeStudent){
                query = query.Include(t => t.Subjects)
                .ThenInclude(ss => ss.StudentSubjects)
                .ThenInclude(s => s.Student);
            }
            query = query.AsNoTracking().OrderBy(t => t.Id);
            
            return query.ToArray();
        }

        public async Task<PageList<Teacher>> GetAllTeachersAsync(PageParams pageParams,
                                        bool includeStudent)
        {
            IQueryable<Teacher> query = _context.Teachers;

            if(includeStudent){
                query = query.Include(t => t.Subjects)
                .ThenInclude(ss => ss.StudentSubjects)
                .ThenInclude(s => s.Student);
            }
            query = query.AsNoTracking().OrderBy(t => t.Id);

            if (!string.IsNullOrEmpty(pageParams.Name))
                query = query.Where(teacher => teacher.Name
                                                  .ToUpper()
                                                  .Contains(pageParams.Name.ToUpper()) ||
                                                teacher.Surname
                                                  .ToUpper()
                                                  .Contains(pageParams.Name.ToUpper()));

            if (pageParams.Enroll > 0)
                query = query.Where(teacher => teacher.Register == pageParams.Enroll);

            if (pageParams.Active != null)
                query = query.Where(teacher => teacher.Active == (pageParams.Active != 0));
            
             return await PageList<Teacher>.CreateAsync(query, pageParams.PageNumber, pageParams.PageSize);
        }

        public async Task<Teacher> GetTeacherByIdAsync(int teacherId, bool includeStudent = false)
        {
             IQueryable<Teacher> query = _context.Teachers;

            if(includeStudent){
                query = query.Include(s=> s.Subjects)
                .ThenInclude(ss => ss.StudentSubjects)
                .ThenInclude(s => s.Student);
            }
            query = query.AsNoTracking()
                        .OrderBy(s => s.Id)
                        .Where(t => t.Id == teacherId );
            
            return await Task.FromResult(query.FirstOrDefault());
        }

        public async Task<Teacher> GetTeacherBySubjectAsync(int subjectId, bool includeStudent = false )
        {
            IQueryable<Teacher> query = _context.Teachers;

            if(includeStudent){
                query = query.Include(s=> s.Subjects)
                .ThenInclude(ss => ss.StudentSubjects)
                .ThenInclude(s => s.Student);
            }
            query = query.AsNoTracking()
                        .OrderBy(s => s.Id)
                        .Where(s => s.Subjects.Any
                        (s => s.StudentSubjects.Any(ss => ss.SubjectId == subjectId )));

            
            return await Task.FromResult(query.FirstOrDefault());
        }

    }
}