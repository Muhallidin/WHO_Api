
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using who.application.Common;
using who.application.Queries.Dapper;
using who.application.ViewModel;
using Dapper;
using who.domain.Entities;

namespace who.infrastructure.Services
{
    public class StudentDal
    {

        private readonly IConnectionString con;
        public StudentDal(IApplicationSettings appSetting, IConnectionSetting con)
        {
            this.con = new ConnectionString(appSetting, con);
        }

        public async Task<IList<StudentVm>> GetAllStudent()
        {
            try
            {
                return await Task.Run(() =>
                {
                    using (SqlConnection conn = new SqlConnection(con.DatabaseConnection))
                    {
                        conn.Open();
                        return conn.Query<StudentVm>(Student_query.GetAllStudent).ToList();
                    }
                });
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<StudentVm> GetStudent(int id)
        {
            try
            {
                return await Task.Run(() =>
                {
                    using (var conn = new SqlConnection(con.DatabaseConnection))
                    {
                        conn.Open();
                        return conn.Query<StudentVm>(Student_query.GetStudentId, new { pId = id }).FirstOrDefault();
                    }
                });
            }


            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<string> Create(Student course)
        {
            try
            {
                return await Task.Run(() =>
                {
                    using (SqlConnection conn = new SqlConnection(con.DatabaseConnection))
                    {
                        conn.Open();
                        return conn.ExecuteScalar<int>(Student_query.Create, new
                        {
                            pFirstName = course.FirstName,
                            pMiddleName = course.MiddleName,
                            pLastName = course.LastName,
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


        public async Task<string> Update(int Id, Student course)
        {
            try
            {
                return await Task.Run(() =>
                {
                    using (SqlConnection conn = new SqlConnection(con.DatabaseConnection))
                    {
                        conn.Open();
                        return conn.ExecuteScalar<int>(Student_query.Update, new
                        {
                            pFirstName = course.FirstName,
                            pMiddleName = course.MiddleName,
                            pLastName = course.LastName,
                            pUserId = course.UserID,
                            pId = Id
                        }, commandTimeout: 0).ToString();

                    };
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<int> Delete(int Id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(con.DatabaseConnection))
                {
                    conn.Open();
                    return await conn.ExecuteScalarAsync<int>(Student_query.Delete, new
                    {
                        pId = Id
                    }, commandTimeout: 30);

                };
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
