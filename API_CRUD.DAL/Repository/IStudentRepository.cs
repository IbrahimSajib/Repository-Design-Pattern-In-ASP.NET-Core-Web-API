using API_CRUD.BL.DTO;
using API_CRUD.BL.Models;

namespace API_CRUD.DAL.Repository
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudent();
        Task<Student> GetStudentById(int id);
        Task AddStudent(StudentDTO model);
        Task UpdateStudent(int id, StudentDTO model);
        Task DeleteStudent(int id);
    }
}