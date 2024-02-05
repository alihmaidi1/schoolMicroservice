using ClassDomain.AppMetaData;
using ClassDomain.Model.Bill.Command;
using Common.Api;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controller;

public class BillController:ApiController
{
    
    [HttpPost(BillRouter.prefix)]
    // [AppAuthorize(AuthenticationSchemes = nameof(JwtSchema.JwtAdmin))]
    public async Task<IActionResult> AddBill([FromBody] AddBillToClassYearCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;
    }
    
    
    [HttpPut(BillRouter.prefix)]
    // [AppAuthorize(AuthenticationSchemes = nameof(JwtSchema.JwtAdmin))]
    public async Task<IActionResult> updateBill([FromBody] UpdatebillCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;
    }
    
    
    [HttpDelete(BillRouter.prefix)]
    // [AppAuthorize(AuthenticationSchemes = nameof(JwtSchema.JwtAdmin))]
    public async Task<IActionResult> Deletebill([FromQuery] DeleteBillCommand command,CancellationToken Token)
    {
        var response = await this.Mediator.Send(command,Token);
        return response;
    }
}