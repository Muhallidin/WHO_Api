using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using who.application.Common;
using who.application.Queries.Dapper;
using who.application.ViewModel;
using who.domain.Entities;

namespace who.infrastructure.Services
{
    public class CourseEnrollDal
    {
        private readonly IConnectionString con;
        public CourseEnrollDal(IApplicationSettings appSetting, IConnectionSetting con)
        {
            this.con = new ConnectionString(appSetting, con);
        }
        public async Task<string> Create(CourseEnroll courseEnroll)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(con.DatabaseConnection))
                {
                    conn.Open();
                    var result = await conn.ExecuteScalarAsync<int>(CourseEnroll_query.Create, new
                    {
                        pCourse_ID = courseEnroll.Course_Id,
                        pStudent_ID = courseEnroll.Student_Id,
                        pStartDate = courseEnroll.StartDate,
                        pEndDate = courseEnroll.EndDate,
                        pUserId = courseEnroll.UserID
                    }, commandTimeout: 0);
                    return result.ToString();
                };
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<string> Update(int Id,CourseEnroll courseEnroll)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(con.DatabaseConnection))
                {
                    conn.Open();
                    var result = await conn.ExecuteScalarAsync<int>(CourseEnroll_query.Update, new
                    {
                        pCourse_ID = courseEnroll.Course_Id,
                        pStudent_ID = courseEnroll.Student_Id,
                        pStartDate = courseEnroll.StartDate,
                        pEndDate = courseEnroll.EndDate,
                        pUserId = courseEnroll.UserID,
                        pId = Id
                    }, commandTimeout: 0);
                    return result.ToString();
                };

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IList<CourseEnrollVm>> Select()
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(con.DatabaseConnection))
                {
                    conn.Open();
                    var result = await conn.QueryAsync<CourseEnrollVm>(CourseEnroll_query.SelectAll, commandTimeout: 30);
                    return (IList<CourseEnrollVm>)result;
                };

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> DelateById(int Id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(con.DatabaseConnection))
                {
                    conn.Open();
                    return await conn.ExecuteScalarAsync<int>(CourseEnroll_query.Delete,
                        new { pId = Id }, commandTimeout: 30 );
                };
            }
            catch(Exception ex) {
                throw ex;
            }
        }

    }
}
