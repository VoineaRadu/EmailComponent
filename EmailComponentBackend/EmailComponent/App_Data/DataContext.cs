namespace EmailComponent.App_Data
{
    public class DataContext
    {
        public EmailDao _emailDao;
        public UserDao _userDao;
        private DataContext()
        {
            _emailDao = new EmailDao();
            _userDao = new UserDao();
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