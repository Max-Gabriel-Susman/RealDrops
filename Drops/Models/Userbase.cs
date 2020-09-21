using System;
using System.Collections.ObjectModel;


namespace Drops.Models
{
    public class Userbase
    {
        // PROPERTIES
        public static ObservableCollection<User> Users = new ObservableCollection<User>()
        {
            // new User("Admin", "Adminadmin", new ObservableCollection<Area>(){ new Area(0.0, 0.0, "ligma"), new Area(0.0, 0.0, "nutz"), new Area(0.0, 0.0, "bitch") }, new ObservableCollection<Area>()),

            new User("Admin", "Adminadmin", new ObservableCollection<Area>() {new Area(0.0, 0.0, "a", "Admin"), new Area(0.0, 0.0, "b", "Admin") }, new ObservableCollection<Area>()),

            new User("Two", "Twotwotwo", new ObservableCollection<Area>() {new Area(0.0, 0.0, "c", "Two"), new Area(0.0, 0.0, "d", "Two") }, new ObservableCollection<Area>()),

            new User("Three", "Threethreethree", new ObservableCollection<Area>() {new Area(0.0, 0.0, "e", "Three"), new Area(0.0, 0.0, "f", "Three") }, new ObservableCollection<Area>())
        };

        public static ObservableCollection<User> OtherUsers
        // Readonly Property that Returns a collection of all users excluding the ActiveUser
        {
            get
            {
                ObservableCollection<User> otherUsers = new ObservableCollection<User>();

                foreach(User user in Users)

                    if(user.Username != ActiveUser.Username)
                    {
                        otherUsers.Add(user);
                    }

                return otherUsers;

            }
        }
        
        public static Area DefaultArea = new Area(41.7377780, -111.8308330, "Default Area", "Admin"); // make sure this guy doesn't get deyeeted

        public static User ActiveUser { get; set; }

        public Userbase(){ }

        // METHODS
        public static bool Authentication(string username, string password)
        // Determines the validity of credential entry
        {

            foreach (User user in Users)
            {
                System.Diagnostics.Debug.WriteLine(Equals(user.Username, username) && Equals(user.Password, password));
                // I think this comparison operator may just be typechecking? Either way I'm going to need to look a little bit more into c# strings
                //if (Equals(user.Username, username) &&  Equals(user.Password, password)) // what the actual fuck
                if (user.Username == username && user.Password == password)
                {
                    ActiveUser = user;

                    return true;
                }
            }

            return false;
        }

        
        public static string CreateUser(string username, string password)
        // Attempts to create a new user while satisfying credential reqs
        {
            // Checks for identical usernames
            foreach (User user in Users)
            {
                if (user.Username == username)

                    return "USERNAME_TAKEN";
            }

            // Checks for a valid Password length
            if (password.Length >= 8)
            {
                // Instantiates and appends a new user to the 'Users' collection
                Users.Add(new User(username, password, new ObservableCollection<Area>(), new ObservableCollection<Area>()));

                return "SUCCESS";
            }   
            else

                return "PASSWORD_INVALID";
        }
    }
}
