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
    public class CourseDal
    {
        private readonly IConnectionString con;
        public CourseDal(IApplicationSettings appSetting, IConnectionSetting con)
        {
            this.con = new ConnectionString(appSetting, con);
        }

        public async Task<IList<CoursesVm>> GetAllCourse()
        {
            try
            {
                return await Task.Run(() =>
                {
                    using SqlConnection conn = new SqlConnection(con.DatabaseConnection);
                    conn.Open();
                    return conn.Query<CoursesVm>(Courses_Query.GetAllCourse).ToList();
                });
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<CoursesVm> GetCourse(int id)
        {
            try
            {
                return await Task.Run(() =>
                {
                    using var conn = new SqlConnection(con.DatabaseConnection);
                    conn.Open();
                    return conn.QueryFirstOrDefault<CoursesVm>(Courses_Query.GetCourseId, new { pID = id });
                });
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<string> Create(Courses course)
        {
            try
            {
                return await Task.Run(() =>
                {
                    using (SqlConnection conn = new SqlConnection(con.DatabaseConnection))
                    {
                        conn.Open();
                        return conn.ExecuteScalar<int>(Courses_Query.Create, new
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

        public async Task<string> Update(int id, Courses course)
        {
            try
            {
                return await Task.Run(() =>
                {
                    using (SqlConnection conn = new SqlConnection(con.DatabaseConnection))
                    {
                        conn.Open();
                        return conn.ExecuteScalar<int>(Courses_Query.Update, new
                        {
                            pCourseCode = course.CourseCode,
                            pCourse = course.Course,
                            pUserId = course.UserID,
                            pId = id
                        }, commandTimeout: 0).ToString();

                    };
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<string> Delete(int Id)
        {
            try
            {
                return await Task.Run(() =>
                {
                    using (SqlConnection conn = new SqlConnection(con.DatabaseConnection))
                    {
                        conn.Open();
                        return conn.ExecuteScalar<int>(Courses_Query.Delete, new
                        { pId = Id}, commandTimeout: 0).ToString();

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
