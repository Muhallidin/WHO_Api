namespace who.application.Queries.Dapper
{
    public class Courses_Query
    {
        #region select All Course
        const string course = @"
                          SELECT [Id] ,[CourseCode] ,[Course]  , [CreatedBy] as UserID
                          FROM [WHO].[dbo].[Course] where IsActive = 1  
                        ";
        public static string GetAllCourse { get { return course; } }

        #endregion select All Course

        #region select Course by ID
        const string courseId = @"
                          SELECT Id, [CourseCode] ,[Course]   , [CreatedBy] as UserID
                          FROM [dbo].[Course] where IsActive = 1 and  [ID] = @pID 
                        ";
        public static string GetCourseId { get { return courseId; } }

        #endregion select All Course


        #region Insert Course  
        const string Createcourse = @"
                         INSERT INTO [dbo].[Course]
                               ([CourseCode]
                               ,[Course]
                               ,[CreatedBy])
                         VALUES
                               (@pCourseCode 
                               ,@pCourse 
                               ,@pUserId)  
                        Select @@Identity as RowAffected
                        ";
        public static string Create { get { return Createcourse; } }

        #endregion select All Course

        #region Insert Course  
        const string Updatecourse = @"
                                UPDATE [dbo].[Course]
                                   SET [CourseCode] = @pCourseCode 
                                      ,[Course] = @pCourse 
                                      ,[IsActive] = 1
                                      ,[ModifiedDate] = Getdate()
                                      ,[ModifiedBy] = @pUserId
                                 WHERE ID = @pId
                                Select @@Identity as RowAffected
                                ";
        public static string Update { get { return Updatecourse; } }

        #endregion select All Course


        #region Delete Course  
        const string Deletecourse = @"
                                    Delete from [dbo].[Course]  WHERE ID = @pId
                                    select @@ROWCOUNT as [RowCount]
                                ";
        public static string Delete { get { return Deletecourse; } }

        #endregion select All Course





    }
}
