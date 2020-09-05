namespace EmailComponent.App_Data
{
    public class DataContext
    {
        public EmailDao _emailDao;
        private DataContext()
        {
            _emailDao = new EmailDao();
        }

        private static DataContext _instance;

        public static DataContext GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DataContext();
            }

            return _instance;
        }
    }
}