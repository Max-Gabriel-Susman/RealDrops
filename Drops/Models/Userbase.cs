using System;
using System.Collections.ObjectModel;


namespace Drops.Models
{
    public class Userbase
    {
        // Shared Instance (Mock Data)
        public static ObservableCollection<User> Users = new ObservableCollection<User>()
        {
            // new User("Admin", "Adminadmin", new ObservableCollection<Area>(){ new Area(0.0, 0.0, "ligma"), new Area(0.0, 0.0, "nutz"), new Area(0.0, 0.0, "bitch") }, new ObservableCollection<Area>()),

            new User("Admin", "Adminadminadmin", new ObservableCollection<Area>() {new Area(0.0, 0.0, "admin"), new Area(0.0, 0.0, "admin") }, new ObservableCollection<Area>()),

            new User("Two", "Twotwotwo", new ObservableCollection<Area>() {new Area(0.0, 0.0, "two"), new Area(0.0, 0.0, "two") }, new ObservableCollection<Area>()),

            new User("Three", "Threethreethree", new ObservableCollection<Area>() {new Area(0.0, 0.0, "three"), new Area(0.0, 0.0, "three") }, new ObservableCollection<Area>())
        };

        // Readonly Property that Returns a collection of all users excluding the ActiveUser
        public static ObservableCollection<User> OtherUsers 
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

        public static User ActiveUser { get; set; }

        public Userbase(){ }

        // Determines the validity of credential entry
        public static bool Authentication(string username, string password)
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

        // Attempts to create a new user while satisfying credential reqs
        public static string CreateUser(string username, string password)
        {
            // Checks for identical usernames
            foreach(User user in Users)
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
