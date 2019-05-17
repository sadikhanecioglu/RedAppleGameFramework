using RedApple.DomainNet35.Session;
using RedApple.DomainNet35.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedApple.ConnectFramework.manager.UserManager
{
    public partial interface IUserManager
    {

        void OpenSession(OpenSessionDto openSessionDto, Action<SessionResultModel> onComplate);
        //RegisterUserResultModel RegisterUser(RegisterUserDto registerUserDto);
        void RegisterUserAsync(RegisterUserDto registerUserDto, Action<RegisterUserResultModel> onComplate);
        //void RegisterUser(object theradStarter);
        //RegisterUserResultModel RegisterUserAsync(RegisterUserDto registerUserDto, Action<RegisterUserResultModel> onComplate);
        void LogoutUser(Action<LogoutUserResultModel> onComplate);
        void UpdateUser(UpdateUserDto updateUserDto,Action<UpdateResultModel> onComplate);

        void RefreshUserState(Action<RefreshStateResultModel> onComplate);
    }
}
