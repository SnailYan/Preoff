using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Preoff.Entity;

namespace Preoff.Service
{
    public interface IDemoService
    {
        Task<Tuser> Meth();
    }
}
