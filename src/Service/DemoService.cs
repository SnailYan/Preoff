using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Preoff.Entity;

namespace Preoff.Service
{
    public class DemoService : IDemoService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DemoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Tuser> Meth()
        {
            var repo = _unitOfWork.GetRepository<Tuser>();
            var value = await repo.FindAsync();
            return value;
        }
    }
}
