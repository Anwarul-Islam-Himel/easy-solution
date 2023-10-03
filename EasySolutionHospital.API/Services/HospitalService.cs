using AutoMapper;
using EasySolutionHospital.API.Infrastructures;
using EasySolutionHospital.Models;
using Microsoft.EntityFrameworkCore;

namespace EasySolutionHospital.API.Services
{
    public interface IHospitalService
    {
        Task<List<TestParameterVM>> GetAllTestParameterAsync();
        Task<List<TestParameterVM>> GetTestParametersByIdAsync(int id);
    }
    public class HospitalService : IHospitalService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public HospitalService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<TestParameterVM>> GetAllTestParameterAsync()
        {
            try
            {
                var parameters = await _context.TestParameters.ToListAsync();
                return _mapper.Map<List<TestParameterVM>>(parameters); 
            }
            catch
            {
                return new List<TestParameterVM>();
            }
        }

        public async Task<List<TestParameterVM>> GetTestParametersByIdAsync(int id)
        {
            try
            {
                var parameters = await _context.PackageParameters
                    .Where(p=>p.PackageId == id)
                    .Include(x=>x.TestParameter)
                    .ToListAsync();
                return _mapper.Map<List<TestParameterVM>>(parameters);
            }
            catch
            {
                return new List<TestParameterVM>();
            }
        }
    }
}
