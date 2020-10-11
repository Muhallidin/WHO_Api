using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using who.application.Common;
using who.application.Queries.Dapper;
using who.application.ViewModel;

namespace who.infrastructure.Services
{
   public class CourseEnrollDal
    {
        private readonly IConnectionString con;
        public CourseEnrollDal(IApplicationSettings appSetting, IConnectionSetting con)
        {
            this.con = new ConnectionString(appSetting, con);
        }
        public async Task<string> Create(CourseEnrollVm courseEnroll)
        {
            try
            {
                return await Task.Run(() =>
                {
                    using (SqlConnection conn = new SqlConnection(con.DatabaseConnection))
                    {
                        conn.Open();
                        return conn.ExecuteScalar<int>(CourseEnroll_query.Create, new
                        {
                            pCourseAuthor_ID = courseEnroll.Course_Id,
                            pStudent_ID = courseEnroll.Students_Id,
                            pStartDate = courseEnroll.DateFrom,
                            pEndDate = courseEnroll.DateTo,
                            pUserId = courseEnroll.UserID
                        }, commandTimeout: 0).ToString();

                    };
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
