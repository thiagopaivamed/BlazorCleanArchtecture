using BlazorServerCleanArchtecture.Application.Interfaces.Repositories;
using BlazorServerCleanArchtecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServerCleanArchtecture.Persistence.Repositories
{
    public class StadiumRepository : IStadiumRepository
    {
        private readonly IGenericRepository<Stadium> _genericRepository;
        public StadiumRepository(IGenericRepository<Stadium> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<List<Stadium>> GetStadiumByCityAsync(string city)
        {
            return await _genericRepository.Entities.Where(s => s.City == city).ToListAsync();
        }
    }
}
