using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OglasnikIT
{
    public class UserInfo
    {
        private int userId;
        private int tip;
        private String username;
        private String password;
        private String name;
        private String eMail;

        public UserInfo()
        {

        }
        public UserInfo(int userId, int tip, String username, String password, String name, String eMail)
        {
            this.userId = userId;
            this.tip = tip;
            this.username = username;
            this.password = password;
            this.name = name;
            this.eMail = eMail;
        }

        public int UserId { get { return userId; } set { userId = value; } }
        public int Tip { get { return tip; } set { tip = value; } }
        public String Username { get { return username; } set { username = value; } }
        public String Password { get { return password; } set { password = value; } }
        public String Name { get { return name; } set { name = value; } }
        public String EMail { get { return eMail; } set { eMail = value; } }

    }
}