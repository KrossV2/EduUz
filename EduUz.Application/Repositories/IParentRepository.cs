using System.Collections.Generic;
using System.Threading.Tasks;
using EduUz.Core.Entities;

namespace EduUz.Application.Repositories
{
    public interface IParentRepository
    {
        Task<Parent> GetByIdAsync(int id);
        Task<List<Parent>> GetByStudentIdAsync(int studentId);
        Task<List<ParentStudentLink>> GetChildrenByParentIdAsync(int parentId);
        Task<ParentStudentLink> GetParentStudentLinkAsync(int parentId, int studentId);
        Task<int> AddAsync(Parent parent);
        Task UpdateAsync(Parent parent);
        Task DeleteAsync(int id);
        Task AddParentStudentLinkAsync(ParentStudentLink link);
    }
}