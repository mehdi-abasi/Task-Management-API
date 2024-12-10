using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UseCases
{
    public class UpdateEmploee : IUpdateEmploee
    {
        private readonly IEmploeeRepository emploeeRepository;
        public UpdateEmploee(IEmploeeRepository _emploeeRepository)
        {
            emploeeRepository = _emploeeRepository;
        }

        public async Task<OperationResult> UpdateEmploeeAsync(EmploeeModel model)
        {
            try
            {
                var emploee = await emploeeRepository.GetByIDAsync(model.Id);
                if (emploee == null)
                {
                    return OperationResult.ErrorResult(OperationStatus.NotFound);
                }
                emploee.Update(model.Name, model.Description, model.IsActive);
                await emploeeRepository.SaveAsync();
                return OperationResult.SuccessResult();
            }
            catch (Exception ex)
            {

                return OperationResult.ErrorResult(OperationStatus.Exception, ex.Message);
            }
          
        }
    }
}
