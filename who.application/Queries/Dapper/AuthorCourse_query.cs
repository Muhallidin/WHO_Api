namespace who.application.Queries.Dapper
{
    public class AuthorCourse_query
    {
        #region Insert AuthorCourse  
        const string CreateAuthorCourse = @"
                         IINSERT INTO [dbo].[CourseAuthor]
                               ([Course_ID]
                               ,[Authort_ID]
                               ,[CreatedBy])
                         VALUES
                               (@pCourse_ID 
                               ,@pAuthort_ID 
                               ,@pUserId)
                        Select @@Identity
                        ";
        public static string Create { get { return CreateAuthorCourse; } }

        #endregion select All AuthorCourse
    }
}
