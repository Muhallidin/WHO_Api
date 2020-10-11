using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using who.application.Common;
using who.application.Queries.Dapper;
using who.domain.Common;
using Dapper;

namespace who.infrastructure.Services
{
    public class UserDal  
    {
        private readonly IConnectionString con;
        public UserDal(IApplicationSettings appSetting, IConnectionSetting con)
        {
           this.con =   new ConnectionString(appSetting, con)  ;
        }

        public async Task<User> LogIn(LogIn user)
        {
            try
            {
                domain.Common.User u = new domain.Common.User();
                await Task.Run(() =>
                {
                    using (SqlConnection conn = new SqlConnection(con.DatabaseConnection))
                    {
                        conn.Open();
                        using (var multi = conn.QuerySingle(User_query.Login, 
                            new {
                                    pUserName = user.UserID,
                                    pPassword = EncryptionHelper.Encrypt(user.Password)
                                },commandTimeout: 0).Result)
                        {
                            user = multi.Read<domain.Common.User>();
                        }
                    }
                });

                return user;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<User> Create(LogIn user)
        {
            try
            {
                domain.Common.User u = new domain.Common.User();
                await Task.Run(() =>
                {
                    using (SqlConnection conn = new SqlConnection(con.DatabaseConnection))
                    {
                        conn.Open();
                        using (var multi = conn.QuerySingle(User_query.Create,
                            new
                            {
                                pUserName = user.UserID,
                                pPassword = EncryptionHelper.Encrypt(user.Password)
                            }, commandTimeout: 0).Result)
                        {
                            user = multi.Read<domain.Common.User>();
                        }
                    }
                });

                return user;
            }
            catch (Exception e)
            {
                throw e;
            }
        }



    }
}
