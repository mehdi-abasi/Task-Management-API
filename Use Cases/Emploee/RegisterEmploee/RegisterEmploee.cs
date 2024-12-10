using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace UseCases
{
    public class RegisterEmploee : IRegisterEmploee
    {
        private readonly IEmploeeRepository emploeeRepository;
        public RegisterEmploee(IEmploeeRepository _emploeeRepository)
        {
            emploeeRepository = _emploeeRepository;
        }

        public async Task<OperationResult> AddEmploeeAsync(EmploeeModel model)
        {
            try
            {
                var emploee = new TblEmploee(model.Name, model.Description, model.IsActive);
                int newId = await emploeeRepository.CreateAsync(emploee);
                if (newId > 0)
                {
                    return OperationResult.SuccessResult(newId);
                }
                return OperationResult.ErrorResult(OperationStatus.Failure,"Unknown Error");
            }
            catch (Exception ex)
            {
                return OperationResult.ErrorResult(OperationStatus.Exception, ex.Message);
            }
           

        }
    }
}
