using System;
using System.Collections.Generic;
using System.Text;

namespace who.application.Queries.Dapper
{
    public static class Author_query
    {
        #region select All author
        const string author = @"
                                SELECT [ID] ,[FirstName] ,[MiddleName]
                                  ,[LastName] ,[CreatedBy] as UserId
                                FROM [dbo].[Author] where IsActive = 1  
                             ";
        public static string GetAllAuthor { get { return author; } }

        #endregion select All author

        #region select author by ID
        const string authorId = @"

                          SELECT [ID] ,[FirstName] ,[MiddleName]
                              ,[LastName] ,[CreatedBy] as UserId
                          FROM [dbo].[Author] where IsActive = 1 and  [ID] = @pID 
                        
                        ";
        public static string GetauthorId { get { return authorId; } }

        #endregion select All author

        #region Insert author  
        const string Createauthor = @"
                         INSERT INTO [dbo].[Author] 
                                ([FirstName], [MiddleName]
                                 ,[LastName], [CreatedBy])
                         VALUES
                                (@pFirstName, @pMiddleName 
                                ,@pLastName, @pUserId)
                        Select @@Identity
                        ";
        public static string Create { get { return Createauthor; } }
        #endregion select All author
        
        #region Update author  
        const string Updateauthor = @"
                        UPDATE [dbo].[Author]
                           SET [FirstName] = @pFirstName 
                              ,[MiddleName] = @pMiddleName 
                              ,[LastName] = @pLastName 
                              ,[IsActive] = 1
                              ,[ModifiedDate] = getdate()
                              ,[ModifiedBy] = @UserId
                         WHERE ID = @Id
                        ";
        public static string Update { get { return Updateauthor; } }

        #endregion select All author
    }
}
