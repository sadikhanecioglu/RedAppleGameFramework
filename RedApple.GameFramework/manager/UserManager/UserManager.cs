using RedApple.ConnectFramework.manager.UserManager;
using RedApple.ConnectFramework.www;
using RedApple.DomainNet35.Session;
using RedApple.DomainNet35.User;
using RedApple.GameFramework.config;
using RedApple.GameFramework.contanier;
using RedApple.GameFramework.extentions;
using RedApple.GameFramework.session;
using RedApple.GameFramework.thread;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RedApple.GameFramework.manager.UserManager
{
    public class UserManager : IUserManager
    {
        // private readonly RedWebRequest _webRequest;
        private readonly RedSessionManager _redSessionManager;
        private readonly RedAppleServerSetting _serverSetting;
        private readonly RedThreadManager _threadManager;
        public UserManager()
        {
            //_webRequest = RedContanierManager.Instance.Contanier.Resolve<RedWebRequest>();
            _redSessionManager = RedSessionManager.Instance;
            _serverSetting = RedConfigManager.Instance.GetConfig<RedAppleServerSetting>("RedAppleServerSetting");
            _threadManager = RedThreadManager.Instance;
        }
        public void LogoutUser(Action<LogoutUserResultModel> onComplate)
        {
            _threadManager.AddTherad<int, LogoutUserResultModel>("RedApple.GameFramework.manager.UserManager.LogoutUser", LogoutUser, 0, onComplate);

        }
        private void LogoutUser(object theradStarter)
        {
            var _theradStarter = (TheradStarter<int, LogoutUserResultModel>)theradStarter;
            try
            {

                if (!_redSessionManager.IsAuthenticated)
                    _theradStarter.Error.Invoke(new ThreadException(new Exception("Authorized Failed")));

                _redSessionManager.LogOut();
                if(_theradStarter.Complate != null)
                _theradStarter.Complate.Invoke(new LogoutUserResultModel(DomainNet35.status.ResultStatus.Ok, "Ok"));
            }
            catch (Exception ex)
            {

                if (_theradStarter.Complate != null)
                    _theradStarter.Complate.Invoke(new LogoutUserResultModel(DomainNet35.status.ResultStatus.Error, ex.Message));
                _theradStarter.Error.Invoke(new ThreadException(ex));
            }
          
        }

        public void OpenSession(OpenSessionDto openSessionDto, Action<SessionResultModel> onComplate)
        {
            _threadManager.AddTherad<OpenSessionDto, SessionResultModel>("RedApple.GameFramework.manager.UserManager.OpenSession", OpenSession, openSessionDto, onComplate);
        }
        private void OpenSession(object theradStarter)
        {
            var _theradStarter = (TheradStarter<OpenSessionDto, SessionResultModel>)theradStarter;
            try
            {
                var openSessionDto = _theradStarter.DATA;
                using (var _webRequest = new RedWebRequest())
                {
                    var _loginresult = _webRequest.PostContentJson<DomainNet35.Dto.request.LoginResultModel>($"{_serverSetting.Api}{_serverSetting.LogingUrl}", openSessionDto.ToJsonString());
                    if (_loginresult.result == DomainNet35.Dto.request.GeneralResultType.OK)
                    {
                        var user = _redSessionManager.OpenRedSession(_loginresult.UserInfo.Id, _loginresult.UserInfo.UserName, _loginresult.token, _loginresult.UserInfo.RealBlanced, _loginresult.expiredDate);
                        _theradStarter.Complate.Invoke(new SessionResultModel(user));
                        return;
                    }
                    if (_theradStarter.Complate != null)
                        _theradStarter.Complate.Invoke(new SessionResultModel(_loginresult.message));
                }

            }
            catch (Exception ex)
            {
                if (_theradStarter.Complate != null)
                    _theradStarter.Complate.Invoke(new SessionResultModel(ex.Message));
                _theradStarter.Error.Invoke(new ThreadException(ex));
            }
        }

        public void RegisterUserAsync(RegisterUserDto registerUserDto, Action<RegisterUserResultModel> onComplate)
        {
            _threadManager.AddTherad<RegisterUserDto, RegisterUserResultModel>("RedApple.GameFramework.manager.UserManager.RegisterUserAsync", RegisterUser, registerUserDto, onComplate);


            // Thread thread = new Thread(RegisterUser);
            //thread.Start(new TheradStarter<RegisterUserResultModel, RegisterUserDto>(onComplate, registerUserDto));


        }
        private void RegisterUser(object theradStarter)
        {

            var _theradStarter = (TheradStarter<RegisterUserDto, RegisterUserResultModel>)theradStarter;

            try
            {
                var registerUserDto = _theradStarter.DATA;


                using (var _webRequest = new RedWebRequest())
                {

                    var result = _webRequest.PostContentJson<DomainNet35.Dto.request.GeneralResultModel>($"{_serverSetting.Api}{_serverSetting.RegisterUrl}", registerUserDto.ToJsonString());
                    if (result.ResultType == DomainNet35.Dto.request.GeneralResultType.OK)
                    {
                        if (_theradStarter.Complate != null)
                            _theradStarter.Complate.Invoke(new RegisterUserResultModel(result.Message, "Ok"));
                        return;
                    }


                    if (_theradStarter.Complate != null)
                        _theradStarter.Complate.Invoke(new RegisterUserResultModel(DomainNet35.status.ResultStatus.Error, result.Message));
                }
            }
            catch (Exception ex)
            {

                _theradStarter.Complate.Invoke(new RegisterUserResultModel(DomainNet35.status.ResultStatus.Error, ex.Message));
            }


        }

        public void UpdateUser(UpdateUserDto updateUserDto, Action<UpdateResultModel> onComplate)
        {
            _threadManager.AddTherad<UpdateUserDto, UpdateResultModel>("RedApple.GameFramework.manager.UserManager.UpdateUser", UpdateUser, updateUserDto, onComplate);
        }
        private void UpdateUser(object theradStarter)
        {
            var _theradStarter = (TheradStarter<UpdateUserDto, UpdateResultModel>)theradStarter;
            try
            {

                if (!_redSessionManager.IsAuthenticated)
                    _theradStarter.Error.Invoke(new ThreadException(new Exception("Authorized Failed")));

                var updateUserDto = _theradStarter.DATA;

                using (var _webRequest = new RedWebRequest(_redSessionManager.SessionUser.RedToken))
                {
                    var result = _webRequest.PostContentJson<DomainNet35.Dto.request.GeneralResultModel>($"{_serverSetting.Api}{_serverSetting.UpdateUserUrl}", updateUserDto.ToJsonString());
                    if (result.ResultType == DomainNet35.Dto.request.GeneralResultType.OK)
                    {
                        if (_theradStarter.Complate != null)
                            _theradStarter.Complate.Invoke(new UpdateResultModel(DomainNet35.status.ResultStatus.Ok, "Ok"));


                        return;
                    }
                    if (_theradStarter.Complate != null)
                        _theradStarter.Complate.Invoke(new UpdateResultModel(DomainNet35.status.ResultStatus.Error, result.Message));
                }
            }
            catch (Exception ex)
            {
                if (_theradStarter.Complate != null)
                    _theradStarter.Complate.Invoke(new UpdateResultModel(DomainNet35.status.ResultStatus.Error, ex.Message));
                _theradStarter.Error.Invoke(new ThreadException(ex));
            }
        }


    }


}
