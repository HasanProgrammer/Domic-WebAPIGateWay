using Domic.Core.Domain.Contracts.Interfaces;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Core.UseCase.Exceptions;
using Domic.UseCase.RoleUseCase.Queries.ReadAllPaginated;
using Domic.UseCase.UserUseCase.Queries.ReadOne;
using Domic.UseCase.UserUseCase.Commands.Create;
using Domic.UseCase.UserUseCase.Commands.OtpGeneration;
using Domic.UseCase.UserUseCase.Commands.OtpVerification;
using Domic.UseCase.UserUseCase.Commands.SignIn;
using Domic.UseCase.UserUseCase.Commands.Update;
using Domic.UseCase.UserUseCase.DTOs.GRPCs.SignIn;
using Microsoft.AspNetCore.Mvc;
using Domic.UseCase.UserUseCase.DTOs.GRPCs.OtpGeneration;
using Domic.UseCase.UserUseCase.DTOs.GRPCs.OtpVerification;
using Domic.WebAPI.Frameworks.Extensions;
using Microsoft.AspNetCore.Authorization;

using CreateResponse                  = Domic.UseCase.UserUseCase.DTOs.GRPCs.Create.CreateResponse;
using UpdateResponse                  = Domic.UseCase.UserUseCase.DTOs.GRPCs.Update.UpdateResponse;
using ReadAllPermissionPaginatedQuery = Domic.UseCase.PermissionUseCase.Queries.ReadAllPaginated.ReadAllPaginatedQuery;
using ReadOneResponse                 = Domic.UseCase.UserUseCase.DTOs.GRPCs.ReadOne.ReadOneResponse;
using Route                           = Domic.Common.ClassConsts.Route;

namespace Domic.WebAPI.EntryPoints.HTTPs.Home.V1;

[ApiExplorerSettings(GroupName = "Home/User")]
[ApiVersion("1.0")]
[Route(Route.BaseHomeUrl + Route.BaseUserUrl)]
public class UserController(IMediator mediator, [FromKeyedServices("Http1")] IIdentityUser identityUser) : ControllerBase
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPatch]
    [Route(Route.SignInUserUrl)]
    public async Task<IActionResult> SignIn([FromBody] SignInCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.DispatchAsync<SignInResponse>(command, cancellationToken);

        return HttpContext.OkResponse(result);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [Route(Route.OtpGenerationUserUrl)]
    public async Task<IActionResult> OtpGeneration([FromBody] OtpGenerationCommand command,
        CancellationToken cancellationToken
    )
    {
        var result = await mediator.DispatchAsync<OtpGenerationResponse>(command, cancellationToken);

        return HttpContext.OkResponse(result);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPatch]
    [Route(Route.OtpVerificationUserUrl)]
    public async Task<IActionResult> OtpVerification([FromBody] OtpVerificationCommand command,
        CancellationToken cancellationToken
    )
    {
        var result = await mediator.DispatchAsync<OtpVerificationResponse>(command, cancellationToken);

        return HttpContext.OkResponse(result);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [Route(Route.SignUpStudentUrl)]
    public async Task<IActionResult> SignUpStudent([FromBody] CreateCommand command, CancellationToken cancellationToken)
    {
        //load guest role & permission

        command.FirstName = "firstname";
        command.LastName = "lastname";
        command.EMail = "email@gmail.com";
        command.Password = "password";
        command.Description = "کاربر عادی عضو سامانه | این کاربران توانایی دسترسی به دوره های خریداری شده خود، تراکنش های بانکی و ویرایش پروفایل خود را دارند";

        var guestRole = await mediator.DispatchAsync(new ReadAllPaginatedQuery { SearchText = "Guest" }, cancellationToken);
        var guestPermission = await mediator.DispatchAsync(new ReadAllPermissionPaginatedQuery { SearchText = "Guest" }, cancellationToken);

        if (guestRole.Code == 200)
            command.Roles = new List<string> { guestRole.Body.Roles.Collection.FirstOrDefault().Id };
        
        if (guestPermission.Code == 200)
            command.Permissions = new List<string> { guestPermission.Body.Permissions.Collection.FirstOrDefault().Id };
        
        var result = await mediator.DispatchAsync<CreateResponse>(command, cancellationToken);

        result.Message += " . دانشجوی گرامی حتما بعد از ورود به پروفایل کاربری اقدام به ویرایش اطلاعات پایه ای خود نمایید . ";

        return HttpContext.OkResponse(result);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [Route(Route.SignUpTeacherUrl)]
    public async Task<IActionResult> SignUpTeacher([FromBody] CreateCommand command, CancellationToken cancellationToken)
    {
        //load teacher role & permission
        
        throw new UseCaseException("در حال حاظر امکان عضویت مدرسین در سامانه میسر نمی باشد . با تشکر");

        command.Description = "مدرس عضو سامانه | این کاربران توانایی ایجاد دوره، ارتباط با شرکت های ثبت کننده آگهی شغلی";

        var guestRole = await mediator.DispatchAsync(new ReadAllPaginatedQuery { SearchText = "Teacher" }, cancellationToken);
        var guestPermission = await mediator.DispatchAsync(new ReadAllPermissionPaginatedQuery { SearchText = "Teacher" }, cancellationToken);

        if (guestRole.Code == 200)
            command.Roles = new List<string> { guestRole.Body.Roles.Collection.FirstOrDefault().Id };
        
        if (guestPermission.Code == 200)
            command.Permissions = new List<string> { guestPermission.Body.Permissions.Collection.FirstOrDefault().Id };
        
        var result = await mediator.DispatchAsync<CreateResponse>(command, cancellationToken);

        return HttpContext.OkResponse(result);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [Route(Route.SignUpCompanyUrl)]
    public async Task<IActionResult> SignUpCompany([FromBody] CreateCommand command, CancellationToken cancellationToken)
    {
        //load company role & permission

        throw new UseCaseException("در حال حاظر امکان عضویت شرکت ها در سامانه میسر نمی باشد . با تشکر");

        command.Description = "شرکت عضو سامانه | این کاربران توانایی ساخت آگهی های شغلی و ارتباط با مدرسین برای ارسال درخواست معرفی نیروی متناسب با پوزیشن های شغلی آگهی خود را دارند";

        var guestRole = await mediator.DispatchAsync(new ReadAllPaginatedQuery { SearchText = "Company" }, cancellationToken);
        var guestPermission = await mediator.DispatchAsync(new ReadAllPermissionPaginatedQuery { SearchText = "Company" }, cancellationToken);

        if (guestRole.Code == 200)
            command.Roles = new List<string> { guestRole.Body.Roles.Collection.FirstOrDefault().Id };
        
        if (guestPermission.Code == 200)
            command.Permissions = new List<string> { guestPermission.Body.Permissions.Collection.FirstOrDefault().Id };
        
        var result = await mediator.DispatchAsync<CreateResponse>(command, cancellationToken);

        return HttpContext.OkResponse(result);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [Authorize]
    [HttpPatch]
    [Route(Route.ProfileUserUrl)]
    public async Task<IActionResult> Update([FromBody] UpdateCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.DispatchAsync<UpdateResponse>(command, cancellationToken);

        return HttpContext.OkResponse(result);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [Authorize]
    [HttpGet(Route.ProfileUserUrl)]
    public async Task<IActionResult> GetUserProfile(CancellationToken cancellationToken)
    {
        var query = new ReadOneQuery { Id = identityUser.GetIdentity() };
        
        var result = await mediator.DispatchAsync<ReadOneResponse>(query, cancellationToken);

        return HttpContext.OkResponse(result);
    }
}