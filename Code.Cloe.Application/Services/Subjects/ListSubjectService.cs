using Code.Cloe.Application.Interfaces;
using Code.Cloe.Application.Services.Subjects.DTO;
using Code.Cloe.Domain.Interfaces.Repository;
using Code.Cloe.Domain.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Cloe.Application.Services.Subjects
{
    public class ListSubjectService : IServiceList<SubjectDTO, Guid>
    {
        private readonly IRepositoryBase<Subject, Guid> SubjectRepository;

        public ListSubjectService(IRepositoryBase<Subject, Guid> subjectRepository)
        {
            this.SubjectRepository = subjectRepository;
        }

        public SubjectDTO? Get(Guid id)
        {
            var model = this.SubjectRepository.Get(id);
            if (model != null)
            {
                //----- El registro existe
                return new SubjectDTO
                {
                    ID = model.ID,
                    Name = model.Name,
                    Address = model.Address,
                    PostalCode = model.PostalCode,
                    Location = model.Location,
                    Province = model.Province,
                    Contacts = null
                };
            }
            return null;
        }

        public async Task<SubjectDTO?> GetAsync(Guid id)
        {
            var model = await this.SubjectRepository.GetAsync(id);
            if (model != null)
            {
                //----- El registro existe
                return new SubjectDTO
                {
                    ID = model.ID,
                    Name = model.Name,
                    Address = model.Address,
                    PostalCode = model.PostalCode,
                    Location = model.Location,
                    Province = model.Province,
                    Contacts = null
                };
            }
            return null;
        }

        public List<SubjectDTO> List()
        {
            var models = this.SubjectRepository.List();
            var listDto = new List<SubjectDTO>(models.Count);
            foreach (var model in models)
            {
                listDto.Add(new SubjectDTO
                {
                    ID = model.ID,
                    Name = model.Name,
                    Address = model.Address,
                    PostalCode = model.PostalCode,
                    Location = model.Location,
                    Province = model.Province,
                    Contacts = null
                });
            }
            return listDto;
        }

        public async Task<List<SubjectDTO>> ListAsync()
        {
            var models = await this.SubjectRepository.ListAsync();
            var listDto = new List<SubjectDTO>(models.Count);
            foreach (var model in models)
            {
                listDto.Add(new SubjectDTO
                {
                    ID = model.ID,
                    Name = model.Name,
                    Address = model.Address,
                    PostalCode = model.PostalCode,
                    Location = model.Location,
                    Province = model.Province,
                    Contacts = null
                });
            }
            return listDto;
        }
    }
}
