using System;
using System.Collections.Generic;
using System.Text;

namespace who.application.Queries.Dapper
{
    public static class Student_query
    {
        #region select All student
        const string student = @"
                                SELECT [ID] ,[FirstName] ,[MiddleName]
                                  ,[LastName] ,[CreatedBy]  as UserId
                                FROM [dbo].[Student] where IsActive = 1  
                             ";
        public static string GetAllStudent { get { return student; } }

        #endregion select All student

        #region select student by ID
        const string studentId = @"

                          SELECT [Id] ,[FirstName] ,[MiddleName]
                              ,[LastName] ,[CreatedBy] as UserId
                          FROM [dbo].[Student] where IsActive = 1 and  [Id] = @pId 
                        
                        ";
        public static string GetStudentId { get { return studentId; } }

        #endregion select All student


        #region Insert student  
        const string Createstudent = @"
                         INSERT INTO [dbo].[Student] 
                                ([FirstName], [MiddleName]
                                 ,[LastName], [CreatedBy])
                         VALUES
                                (@pFirstName, @pMiddleName 
                                ,@pLastName, @pUserId)
                        Select @@Identity
                        ";
        public static string Create { get { return Createstudent; } }

        #endregion select Update


        #region Insert student  
        const string Updatestudent = @"
                         UPDATE [dbo].[Student]
                           SET [FirstName] = @pFirstName 
                              ,[MiddleName] = @pMiddleName 
                              ,[LastName] = @pLastName 
                              ,[IsActive] = 1
                              ,[ModifiedDate] = getdate()
                              ,[ModifiedBy] = @UserId
                         WHERE ID = @Id
                       ";
        public static string Update { get { return Updatestudent; } }

        #endregion select All student
    }
}
