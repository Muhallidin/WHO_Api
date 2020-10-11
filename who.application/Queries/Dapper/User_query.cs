using System;
using System.Collections.Generic;
using System.Text;

namespace who.application.Queries.Dapper
{
    public static class User_query
	{

        #region select_Login
        const string user = @"
                          SELECT s.*,UR.*
                          FROM [dbo].[Users] s
	                        left join dbo.UserRole UR on upper(s.UserName) = upper(UR.UserName) and UR.IsActive = 1
                          where s.UserName = @pUserName and [Password] = @pPassword
                        ";
        public static string Login { get { return user; } }

        #endregion select_Login

        #region Create User
        const string Create_user = @"
                          SELECT s.*,UR.*
                          FROM [dbo].[Users] s
	                        left join dbo.UserRole UR on upper(s.UserName) = upper(UR.UserName) and UR.IsActive = 1
                          where s.UserName = @pUserName and [Password] = @pPassword
                        ";
        public static string Create { get { return Create_user; } }

        #endregion select_Login


    }
}
