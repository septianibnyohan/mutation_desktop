using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MutationChecker.Model.DTO.API
{
    public class UserInfoResp
    {
        public bool status { get; set; }
        public UserInfoData data { get; set; }
        public string msg { get; set; }
    }
}
