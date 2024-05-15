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
    public class CreateSubjectService : IServiceCreate<SubjectDTO>
    {
        private readonly IRepositoryBase<Subject, Guid> SubjectRepository;

        public CreateSubjectService(IRepositoryBase<Subject, Guid> subjectRepository)
        {
            this.SubjectRepository = subjectRepository;
        }

        public SubjectDTO Add(SubjectDTO item)
        {
            if (item == null) throw new ArgumentNullException("SubjectDTO can't be null");
            throw new NotImplementedException();
        }

        public Task<SubjectDTO> AddAsync(SubjectDTO item)
        {
            throw new NotImplementedException();
        }
    }
}
