using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public enum UserStatus
{
    LOGGEDIN,
    LOGGEDOUT
}
namespace ConsoleApp.Domain
{
    public class User:Entity<int>
    {
        private String email;
        private String password;
        private String name;
        private UserStatus status = UserStatus.LOGGEDOUT;

        public User(String email, String password, String name, UserStatus status)
        {
            this.email = email;
            this.password = password;
            this.name = name;
            this.status = status;
        }

        public String getEmail()
        {
            return email;
        }

        public void setEmail(String email)
        {
            this.email = email;
        }

        public String getPassword()
        {
            return password;
        }

        public void setPassword(String password)
        {
            this.password = password;
        }

        public String getName()
        {
            return name;
        }

        public void setName(String name)
        {
            this.name = name;
        }

        public UserStatus getStatus()
        {
            return status;
        }

        public void setStatus(UserStatus status)
        {
            this.status = status;
        }

    }
}
