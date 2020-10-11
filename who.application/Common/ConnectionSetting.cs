using System;
using System.Collections.Generic;
using System.Text;

namespace who.application.Common
{
    public interface IConnectionSetting
    {

        string DefaultConnection { get; set; }
        
    }
    public class ConnectionSetting : IConnectionSetting
    {


        public string DefaultConnection { get; set; }
        

    }
}
