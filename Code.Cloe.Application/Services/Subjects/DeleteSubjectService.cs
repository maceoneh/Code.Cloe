using Code.Cloe.Application.Interfaces;
using Code.Cloe.Application.Services.Subjects.DTO;
using Code.Cloe.Domain.Interfaces.Repository;
using Code.Cloe.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Cloe.Application.Services.Subjects
{
    public class DeleteSubjectService : IServiceDelete<SubjectDTO>
    {
        private readonly IRepositoryBase<Subject, Guid> SubjectRepository;

        public DeleteSubjectService(IRepositoryBase<Subject, Guid> subjectRepository)
        {
            SubjectRepository = subjectRepository;
        }

        public void Delete(SubjectDTO dto)
        {
            this.SubjectRepository.Delete(dto.ID);
            this.SubjectRepository.Commit();
        }

        public async Task DeleteAsync(SubjectDTO dto)
        {
            await this.SubjectRepository.DeleteAsync(dto.ID);
            await this.SubjectRepository.CommitAsync();
        }
    }
}
