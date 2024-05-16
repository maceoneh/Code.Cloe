using Code.Cloe.Application.Interfaces;
using Code.Cloe.Domain.Interfaces.Repository;
using Code.Cloe.Domain.Models;
using System.Linq.Expressions;

namespace Code.Cloe.Application.Services
{
    public class SubjectServiceOLD : IServiceBase<SubjectOLD, Guid>
    {
        private readonly IRepositoryBase<SubjectOLD, Guid> SubjectRepository;        

        public SubjectServiceOLD(IRepositoryBase<SubjectOLD, Guid> subjectRepository)
        { 
            this.SubjectRepository = subjectRepository;
        }

        public SubjectOLD Add(SubjectOLD item)
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

        public async Task<SubjectOLD> AddAsync(SubjectOLD item)
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
            this.SubjectRepository.Commit();
        }

        public async Task DeleteAsync(Guid id)
        {
            await this.SubjectRepository.DeleteAsync(id);
            await this.SubjectRepository.CommitAsync();
        }

        public SubjectOLD? Edit(SubjectOLD item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Subject object is required");
            }
            //-----
            var result = this.SubjectRepository.Edit(item);
            this.SubjectRepository.Commit();
            //-----
            return result;
        }

        public async Task<SubjectOLD?> EditAsync(SubjectOLD item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Subject object is required");
            }
            //-----
            var result = await this.SubjectRepository.EditAsync(item);
            await this.SubjectRepository.CommitAsync();
            //-----
            return result;
        }

        public SubjectOLD? Get(Guid id)
        {
            var result = this.SubjectRepository.Get(id);
            //-----
            return result;
        }

        public async Task<SubjectOLD?> GetAsync(Guid id)
        {
            var result = await this.SubjectRepository.GetAsync(id);
            //-----
            return result;
        }

        public List<SubjectOLD> List()
        {
            return this.SubjectRepository.List();
        }

        public async Task<List<SubjectOLD>> ListAsync()
        {
            return await this.SubjectRepository.ListAsync();
        }

        public IQueryable<SubjectOLD> Where(Expression<Func<SubjectOLD, bool>> predicate)
        {
            return this.SubjectRepository.Where(predicate);
        }
    }
}
