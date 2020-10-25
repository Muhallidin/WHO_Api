namespace who.application.Queries.Dapper
{
    public class CourseEnroll_query
    {
        #region Insert Course Enroll  
        const string CreateCourseEnroll = @"
                         INSERT INTO [dbo].[EnrollCourse]
                               ([Course_ID]
                               ,[Student_ID]
                               ,[StartDate]
                               ,[EndDate]
                               ,[CreatedBy])
                         VALUES
                               (@pCourse_ID 
                               ,@pStudent_ID 
                               ,@pStartDate 
                               ,@pEndDate 
                               ,@pUserId)
                        Select @@Identity

                        ";
        public static string Create { get { return CreateCourseEnroll; } }

        #endregion Update Course Enroll  

        #region Insert Course Enroll  
        const string UpdateCourseEnroll = @"

                         Upate [dbo].[EnrollCourse]
                         set [Course_ID] = @pCourseId
                             [Student_ID]      = @pStudent_ID 
                             [StartDate]       = @pStartDate 
                             [EndDate]         = @pEndDate 
                             [ModifiedDate]    = Getdate()
                             [ModifiedBy])      = @pUserId)
                          where [Id] = pId     
                               

                        ";
        public static string Update { get { return UpdateCourseEnroll; } }

        #endregion Insert Course Enroll  

        #region Select  Course Enroll  
        const string SelectCourseEnroll = @"
                         
                SELECT EC.[Id] ,[Course_ID]  ,C.CourseCode ,C.Course ,[Student_ID]
	                    ,S.FirstName ,S.MiddleName ,S.LastName ,[StartDate] ,[EndDate]
                FROM [dbo].[EnrollCourse] EC
	                join [dbo].[Student] S on EC.Student_ID = S.Id
	                join [dbo].[Course] C on EC.Course_ID = C.Id
                where  (isnull(EC.Student_ID,0) = 0 or (isnull(EC.Student_ID,0) = @pStudentId ))
		                and (isnull(EC.[Course_ID],0) = 0 or (isnull(EC.[Course_ID],0) = @pCourseId ))

                        ";
        public static string Select { get { return SelectCourseEnroll; } }

        #endregion Insert Course Enroll  


        #region Select  Course Enroll  
        const string SelectAllCourseEnroll = @"
                         
                SELECT  [Id] ,[Course_ID]  ,[Student_ID] ,[StartDate] ,[EndDate]
                       , CreatedBy as UserId
                FROM [dbo].[EnrollCourse]  
 
                        ";
        public static string SelectAll { get { return SelectAllCourseEnroll; } }

        #endregion Select all Course Enroll  

        #region Delete  Course Enroll  
        const string DeleteCourseEnroll = @"
                         
                    Delete [dbo].[EnrollCourse] EC
	                   where Id = @pId
                        ";
        public static string Delete { get { return DeleteCourseEnroll; } }

        #endregion Delete Course Enroll  


    }
}
