using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using who.application.Common;
using who.application.Queries.Dapper;
using who.application.ViewModel;
namespace who.infrastructure.Services
{
    public class CourseDal  
    {
        private readonly IConnectionString con;
        public CourseDal(IApplicationSettings appSetting, IConnectionSetting con)
        {
            this.con = new ConnectionString(appSetting, con);
        }

        public async Task<IList<CourseVm>> GetAllCourse()
        {
            try
            {
                return await Task.Run(() =>
                {
                    using (SqlConnection conn = new SqlConnection(con.DatabaseConnection))
                    {
                        conn.Open();
                        return conn.Query<CourseVm>(courses_Query.GetAllCourse).ToList();
                    }
                });
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<CourseVm> GetCourse(int id)
        {
            try
            {
                return await Task.Run(() =>
                {
                    using (var conn = new SqlConnection(con.DatabaseConnection))
                    {
                        conn.Open();
                        return conn.QueryFirstOrDefault<CourseVm>(courses_Query.GetCourseId, new { pID = id });
                    }
                });
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<string> Create(CourseVm course)
        {
            try
            {
                return await Task.Run(() =>
                {
                    using (SqlConnection conn = new SqlConnection(con.DatabaseConnection))
                    {
                        conn.Open();
                        return conn.ExecuteScalar<int>(courses_Query.Create, new
                        {
                            pCourseCode = course.CourseCode,
                            pCourse = course.Course,
                            pUserId = course.UserID
                        }, commandTimeout: 0).ToString();

                    };
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> Update(CourseVm course)
        {
            try
            {
                return await Task.Run(() =>
                {
                    using (SqlConnection conn = new SqlConnection(con.DatabaseConnection))
                    {
                        conn.Open();
                        return conn.ExecuteScalar<int>(courses_Query.Update, new
                        {
                            pCourseCode = course.CourseCode,
                            pCourse = course.Course,
                            pUserId = course.UserID
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
