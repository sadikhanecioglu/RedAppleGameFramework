using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedApple.DomainNet35.Dto.request
{
    public class RegisterResultModel:GeneralResultModel
    {

        public LoginResultModel LoginResult { get; set; }

        public RegisterResultModel(LoginResultModel LoginResult,string Message)
        {
            this.LoginResult = LoginResult;
            this.ResultType = GeneralResultType.OK;
            this.Message = Message;
            
        }

    }
}
