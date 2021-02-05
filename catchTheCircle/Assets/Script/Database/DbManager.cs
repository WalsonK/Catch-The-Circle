using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DbManager 
{
    public static string mail;
    public static string password;

    public static string firstname;
    public static string lastname;
    public static int score;
    
    public static bool LoggedIn { get { return mail != null;  } }

    public static void LogOut()
    {
        mail = null;
        password = null;
    }
}
