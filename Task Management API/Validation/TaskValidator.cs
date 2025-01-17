
using FluentValidation;
using UseCases;
namespace Task_Management_API.Validation
{

    public class AddTaskValidator:AbstractValidator<NewTaskModel>
    {
        public AddTaskValidator()
        {
            RuleFor(task => task.Name).NotEmpty().WithMessage("Name is required.").MaximumLength(50).WithMessage("Name is too long.");
            RuleFor(task => task.Description).NotEmpty().WithMessage("Description is required.");
            RuleFor(task => task.Title).NotEmpty().WithMessage("Title is required.").MaximumLength(50).WithMessage("Title is too long.");
            RuleFor(task => task.TblEmploeeID).GreaterThan(0).WithMessage("EmploeeId Must Be a Positive Number.");
            RuleFor(task => task.StartDate).NotEmpty().WithMessage("StartDate is required.").GreaterThanOrEqualTo(DateTime.Now).WithMessage("StartDate should not be in the past.");
            RuleFor(task => task.DueDate).NotEmpty().WithMessage("DueDate is required.").GreaterThanOrEqualTo(task => task.StartDate).WithMessage("DueDate should not be before StartDate.");
        }
    }
    public class UpdateTaskValidator : AbstractValidator<TaskModel>
    {
        public UpdateTaskValidator()
        {
            RuleFor(task => task.Id).GreaterThan(0).WithMessage("EmploeeId Must Be a Positive Number.");
            RuleFor(task => task.Name).NotEmpty().WithMessage("Name is required.").MaximumLength(50).WithMessage("Name is too long.");
            RuleFor(task => task.Description).NotEmpty().WithMessage("Description is required.");
            RuleFor(task => task.Title).NotEmpty().WithMessage("Title is required.").MaximumLength(50).WithMessage("Title is too long.");
            RuleFor(task => task.TblEmploeeID).GreaterThan(0).WithMessage("EmploeeId Must Be a Positive Number.");
            RuleFor(task => task.StartDate).NotEmpty().WithMessage("StartDate is required.").GreaterThanOrEqualTo(DateTime.Now).WithMessage("StartDate should not be in the past.");
            RuleFor(task => task.DueDate).NotEmpty().WithMessage("DueDate is required.").GreaterThanOrEqualTo(task => task.StartDate).WithMessage("DueDate should not be before StartDate.");
        }
    }
}
