using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace who.application.Common
{

    public interface IConnectionString
    {
        string DatabaseConnection { get; }
    }
    public class ConnectionString : IConnectionString
    {
       
        public ConnectionString(IApplicationSettings appSetting, IConnectionSetting con)
        {
            try
            {
                string path = appSetting.FileLocation + appSetting.FileName;
                string[] lines = File.ReadAllLines(path, Encoding.UTF8);

                if (lines.Length > 0)
                {
                    string cridential = "";

                    foreach (string res in lines)
                    {
                        cridential = cridential + res.ToString();
                    }
                    cridential = "User " + cridential;

                    this.DatabaseConnection = con.DefaultConnection; // cridential + con.DefaultConnection;
                    
                }
            }
            catch  
            {
                this.DatabaseConnection  = con.DefaultConnection;
                //string error = ex.Message.ToString();
            }
        }

        public string DatabaseConnection { get; }
      
    }
}
