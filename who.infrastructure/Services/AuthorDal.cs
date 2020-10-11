using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using who.application.Common;
using who.application.Queries.Dapper;
using who.domain.Entities;
using Dapper;
using System.Linq;
using who.application.ViewModel;

namespace who.infrastructure.Services
{
    public class AuthorDal
    {

        private readonly IConnectionString con;
        public AuthorDal(IApplicationSettings appSetting, IConnectionSetting con)
        {
            this.con = new ConnectionString(appSetting, con);
        }

        public async Task<IList<AuthorVm>> GetAllAuthor()
        {
            try
            {
                return await Task.Run(() =>
                {
                    using (SqlConnection conn = new SqlConnection(con.DatabaseConnection))
                    {
                        conn.Open();
                        return conn.Query<AuthorVm>(Author_query.GetAllAuthor).ToList();
                    }
                });
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<AuthorVm> GetAuthor(int id)
        {
            try
            {
                return await Task.Run(() =>
                {
                    using (var conn = new SqlConnection(con.DatabaseConnection))
                    {
                        conn.Open();
                        return conn.QueryFirstOrDefault<AuthorVm>(Author_query.GetauthorId, new { pID = id });
                    }
                });
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<string> Create(AuthorVm course)
        {
            try
            {
                return await Task.Run(() =>
                {
                    using (SqlConnection conn = new SqlConnection(con.DatabaseConnection))
                    {
                        conn.Open();
                        return conn.ExecuteScalar<int>(Author_query.Create, new
                        {
                            pFirstName = course.FirstName,
                            pMiddleName = course.MiddleName,
                            pLastName = course.LastName,
                            pUser = course.UserID
                        }, commandTimeout: 0).ToString();

                    };
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> Update(int Id, AuthorVm author)
        {
            try
            {
                return await Task.Run(() =>
                {
                    using (SqlConnection conn = new SqlConnection(con.DatabaseConnection))
                    {
                        conn.Open();
                        return conn.ExecuteScalar<int>(Author_query.Update, new
                        {
                            pFirstName = author.FirstName,
                            pMiddleName = author.MiddleName,
                            pLastName = author.LastName,
                            pUserId = author.UserID,
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
    }
}
