namespace who.application.Common
{
    public interface IConnectionSetting
    {

        string DefaultConnection { get; set; }

    }
    public class ConnectionSetting : IConnectionSetting
    {


        public string DefaultConnection { get; set; }


    }
}
