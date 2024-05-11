using Code.Cloe.Application.Interfaces;
using Code.Cloe.Domain.Interfaces.Repository;
using Code.Cloe.Domain.Models;

namespace Code.Cloe.Application.Services
{
    public class SubjectService : IServiceBase<Subject, Guid>
    {
        private readonly IRepositoryBase<Subject, Guid> SubjectRepository;        

        public SubjectService(IRepositoryBase<Subject, Guid> subjectRepository)
        { 
            this.SubjectRepository = subjectRepository;
        }

        public Subject Add(Subject item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Subject object is required");
            }
            //-----
            var result = this.SubjectRepository.Add(item);            
            //-----
            this.SubjectRepository.Commit();
            //-----
            return result;
        }

        public async Task<Subject> AddAsync(Subject item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Subject object is required");
            }
            //-----
            var result = await this.SubjectRepository.AddAsync(item);
            //-----
            await this.SubjectRepository.CommitAsync();
            //-----
            return result;
        }

        public void Delete(Guid id)
        {
            this.SubjectRepository.Delete(id);
        }

        public async Task DeleteAsync(Guid id)
        {
            await this.SubjectRepository.DeleteAsync(id);
        }

        public Subject? Edit(Subject item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Subject object is required");
            }
            //-----
            var result = this.SubjectRepository.Edit(item);
            //-----
            return result;
        }

        public async Task<Subject?> EditAsync(Subject item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Subject object is required");
            }
            //-----
            var result = await this.SubjectRepository.EditAsync(item);
            //-----
            return result;
        }

        public Subject? Get(Guid id)
        {
            var result = this.SubjectRepository.Get(id);
            //-----
            return result;
        }

        public async Task<Subject?> GetAsync(Guid id)
        {
            var result = await this.SubjectRepository.GetAsync(id);
            //-----
            return result;
        }

        public List<Subject> List()
        {
            return this.SubjectRepository.List();
        }

        public async Task<List<Subject>> ListAsync()
        {
            return await this.SubjectRepository.ListAsync();
        }
    }
}
