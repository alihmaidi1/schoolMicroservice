using FluentValidation;
using Infrutructure;
using Microsoft.EntityFrameworkCore;
using Model.Auth.Command;

namespace Admin.Auth.Command.Validation;

public class RefreshAdminTokenValidation:AbstractValidator<RefreshAdminTokenCommand>
{
    
    public RefreshAdminTokenValidation(ApplicationDbContext DbContext)
    {
        
        
        RuleFor(x => x.RefreshToken)
            .NotEmpty()
            .WithMessage("refresh token can not be empty")
            .NotNull()
            .WithMessage("refresh token can not be null")
            .Must(RefreshToken=>DbContext.AdminRefreshTokens.Any(x=>x.Token.Equals(RefreshToken)))
            .WithMessage("this refresh token is not valid");

        
    }

}