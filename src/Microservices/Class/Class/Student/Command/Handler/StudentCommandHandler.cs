using Class.Repository.Student;
using ClassDomain.Model.Student.Command;
using Common.CQRS;
using Common.Email;
using Common.OperationResult;
using Microsoft.AspNetCore.Mvc;

namespace Class.Student.Command.Handler;

public class StudentCommandHandler:OperationResult,
    ICommandHandler<AddStudentCommand>,
    ICommandHandler<UpdateStudentCommand>,
    ICommandHandler<DeleteStudentCommand>


{
    private IStudentRepository studentRepository;
    private IMailService MailService;
    public StudentCommandHandler(IStudentRepository studentRepository,IMailService MailService)
    {

        this.studentRepository = studentRepository;

        this.MailService = MailService;
    }
    
    
    
    public  async Task<JsonResult> Handle(AddStudentCommand request, CancellationToken cancellationToken)
    {

        ClassDomain.Entities.Student.Student student = new ClassDomain.Entities.Student.Student()
        {

            Name = request.Name,
            Email = request.Email,
            Password = request.Password,
            ParentId=request.ParentId,
            Gender = request.Gender,
            Number = request.Number

        };
         await studentRepository.AddAsync(student);
         
         MailService.SendMail(request.Email, "Welcome to our school",
             $"Your password In School is your password {request.Password}");
        return Success("the student was added successfully");

    }

    public async Task<JsonResult> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
    {

        ClassDomain.Entities.Student.Student student = new ClassDomain.Entities.Student.Student()
        {

            Id = request.Id,
            Name = request.Name,
            Email = request.Email,
            ParentId = request.ParentId,
            Gender = request.Gender,
            Number = request.Number
        };
        
        await studentRepository.UpdateAsync(student);
        return Success("the student was updated successfully");
    }

    public async Task<JsonResult> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
    {
        studentRepository.Delete(request.Id);
        return Success("the student was deleted  successfully");
    }
}