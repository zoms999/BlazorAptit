using BlazorAptit.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAptit.Models.EfCore
{
    
    public interface IRepository
    {
        Task<List<AptitUser>> GetAllAptitUsers();

        Task<bool> EditAsync(Order moodel);
       
    }

    public class Repository : IRepository
    {
        private readonly SchoolContext _context;
        private readonly ILogger _logger;

        public Repository(SchoolContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger(nameof(Repository));
        }

        public async Task<List<AptitUser>> GetAllAptitUsers()
        {
            try
            {
               
                 return await _context.AptitUsers
                .Include(m => m.AptitAnswers)
                .AsNoTracking()
                .ToListAsync();
            }
            catch(Exception ex)
            {
                return null;
            }
           
        }

        public Task<bool> EditAsync(Order moodel)
        {
            throw new NotImplementedException();
        }
    }
}
