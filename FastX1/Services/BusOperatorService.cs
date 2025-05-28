using FastX1.Data;
using FastX1.Models;
using FastX1.Repositories.Interfaces;
using FastX1.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FastX1.Services
{
        public class BusOperatorService : IBusOperatorService
        {
            private readonly IBusOperatorRepository _operatorRepository;

            public BusOperatorService(IBusOperatorRepository operatorRepository)
            {
                _operatorRepository = operatorRepository;
            }

            public async Task<BusOperator> RegisterOperatorAsync(BusOperator operatorData)
            {
                var exists = await _operatorRepository.GetByEmailAsync(operatorData.Email);
                if (exists != null)
                    throw new Exception("Email is already registered as a bus operator.");

                operatorData.CreatedAt = DateTime.Now;
                return await _operatorRepository.AddAsync(operatorData);
            }

            public async Task<List<BusOperator>> GetAllOperatorsAsync()
            {
                var operators = await _operatorRepository.GetAllAsync();
                return operators.ToList();
            }

            public async Task<BusOperator> GetOperatorByIdAsync(int operatorId)
            {
                return await _operatorRepository.GetByIdAsync(operatorId);
            }
        }
    }
