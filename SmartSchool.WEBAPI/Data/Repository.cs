using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
        
        public Student[] GetAllStudents(bool includeTeacher)
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

        public Student GetStudentById( int studentId, bool includeTeacher = false)
        {
            IQueryable<Student> query = _context.Students;

            if(includeTeacher){
                query = query.Include(s=> s.StudentSubjects)
                .ThenInclude(ss => ss.Subject)
                .ThenInclude(s => s.Teacher);
            }
            query = query.AsNoTracking()
                        .OrderBy(s => s.Id)
                        .Where(s => s.Id == s.Id);
            
            return query.FirstOrDefault();
        }

        public Student GetStudentBySubject(int subjectId, bool includeTeacher = false)
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
            
            return query.FirstOrDefault();
        }

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

        public Teacher GetTeacherById(int teacherId, bool includeStudent = false)
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
            
            return query.FirstOrDefault();
        }

        public Teacher GetTeacherBySubject(int subjectId, bool includeStudent = false )
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

            
            return query.FirstOrDefault();
        }
    }
}