using System;
using System.Collections.Generic;
using System.Text;

namespace who.application.Queries.Dapper
{
    public class CourseEnroll_query
    {
        #region Insert Course Enroll  
        const string CreateCourseEnroll = @"
                         INSERT INTO [dbo].[EnrollCourse]
                               ([CourseAuthor_ID]
                               ,[Student_ID]
                               ,[StartDate]
                               ,[EndDate]
                               ,[CreatedBy])
                         VALUES
                               (@pCourseAuthor_ID 
                               ,@pStudent_ID 
                               ,@pStartDate 
                               ,@pEndDate 
                               ,@pUserId)
                        Select @@Identity

                        ";
        public static string Create { get { return CreateCourseEnroll; } }

        #endregion Insert Course Enroll  
    }
}
