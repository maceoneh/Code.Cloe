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
    internal class DeleteSubjectService : IServiceDelete<SubjectDTO>
    {
        private readonly IRepositoryBase<Subject, Guid> SubjectRepository;

        public DeleteSubjectService(IRepositoryBase<Subject, Guid> subjectRepository)
        {
            SubjectRepository = subjectRepository;
        }

        public void Delete(SubjectDTO id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(SubjectDTO id)
        {
            throw new NotImplementedException();
        }
    }
}
