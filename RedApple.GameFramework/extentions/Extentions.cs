using Newtonsoft.Json;
using RedApple.DomainNet35.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedApple.GameFramework.extentions
{
    public static class DomainExtentions
    {
        public static string ToJsonString(this IDtoNet35 dto)
        {
            return JsonConvert.SerializeObject(dto);
        }
    }
}
