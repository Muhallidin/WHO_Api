using Dapper;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using who.application.Common;
using who.application.Queries.Dapper;
using who.application.ViewModel;

namespace who.infrastructure.Services
{
    public class AuthorCourseDal
    {
        private readonly IConnectionString con;
        public AuthorCourseDal(IApplicationSettings appSetting, IConnectionSetting con)
        {
            this.con = new ConnectionString(appSetting, con);
        }

        public async Task<string> Create(AuthorCourseVm authorCourse)
        {
            try
            {
                return await Task.Run(() =>
                {
                    using (SqlConnection conn = new SqlConnection(con.DatabaseConnection))
                    {
                        conn.Open();
                        return conn.ExecuteScalar<int>(AuthorCourse_query.Create, new
                        {

                            pCourse_ID = authorCourse.Courses.Id,
                            pAuthort_ID = authorCourse.Author.Id,
                            pUserId = authorCourse.UserID

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
