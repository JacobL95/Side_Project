using System;
public class Log
{
    private Int32 m_Log_ID;
    private String m_User_Name;
    private String m_Note;

    public Log() { }

    public Int32 Log_ID
    {
        get
        {
            return m_Log_ID;
        }
        set
        {
            m_Log_ID = value;
        }
    }
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
    public String Note
    {
        get
        {
            return m_Note;
        }
        set
        {
            m_Note = value;
        }
    }
}

 
