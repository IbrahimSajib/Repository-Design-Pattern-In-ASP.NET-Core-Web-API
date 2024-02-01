using API_CRUD.BL.Models;
using API_CRUD.BL.DTO;
using API_CRUD.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace API_CRUD.DAL.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDbContext _context;
        public StudentRepository(StudentDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Student>> GetAllStudent()
        {
            return await _context.Students.ToListAsync();
        }
        public async Task<Student> GetStudentById(int id)
        {
            return await _context.Students.FindAsync(id);
        }
        public async Task AddStudent(StudentDTO model)
        {
            var student = new Student
            {
                Name = model.Name,
                Age = model.Age,
            };
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateStudent(int id, StudentDTO model)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                student.Name = model.Name;
                student.Age = model.Age;
            }
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }
    }
}
