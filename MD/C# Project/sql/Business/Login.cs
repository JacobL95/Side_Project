using System;
public class Login
{
    private String m_User_Name;
    private String m_Password;

    public Login() { }

    public String User_Name
    {
        get
        {
            return m_User_Name;
        }
        set
        {
            m_User_Name = value;
        }
    }
    public String Password
    {
        get
        {
            return m_Password;
        }
        set
        {
            m_Password = value;
        }
    }
}

 
