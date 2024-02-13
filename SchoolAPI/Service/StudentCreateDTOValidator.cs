using FluentValidation;
using SchoolAPI.ModelDTO;

namespace SchoolAPI.Service
{
    public class StudentCreateDTOValidator : AbstractValidator<StudentCreateDTO>
    {
        public StudentCreateDTOValidator()
        {
            RuleFor(s => s.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email address format.");

            RuleFor(s => s.FirstName)
                .NotEmpty().WithMessage("First name is required.");

            RuleFor(s => s.LastName)
                .NotEmpty().WithMessage("Last name is required.");

            RuleFor(s => s.DateOfBirth)
                .NotEmpty().WithMessage("Date of birth is required.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Date of birth cannot be greater than current date.");


            RuleFor(s => s.RollNumber)
                .NotEmpty().WithMessage("Roll number is required.");

            RuleFor(s => s.Gender)
                .IsInEnum().WithMessage("Invalid input for gender");

        }
    }
}
