using LeafFilter.HelpDesk.Data;
using LeafFilter.HelpDesk.Model;
using LeafFilter.HelpDesk.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeafFilter.HelpDesk.Service
{
    public interface IProcessService : IProcessRepository, IServiceAsync<Process> { }

    public class ProcessService : ProcessRepository, IProcessService
    {
        private IProcessRepository _processRepo;
        private HelpDeskContext _context; 

        public ProcessService(IProcessRepository processRepo, HelpDeskContext context) : base(context)
        {
            _processRepo = processRepo;
            _context = context;
        }

        public async Task<List<Process>> LoadAllAsync()
        {            
            return await _processRepo.GetAllAsync();
        }

        public async Task<Process> LoadSingleAsync(Guid id)
        {
            return await _processRepo.GetSingleIdAsync(id);
        }
    }
}
