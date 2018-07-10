using System;
public class Groom
{
    private Int32 m_Groom_ID;
    private String m_Groom_First_Name;
    private String m_Groom_Middle_Int;
    private String m_Groom_Last_Name;

    public Groom() { }

    public Int32 Groom_ID
    {
        get
        {
            return m_Groom_ID;
        }
        set
        {
            m_Groom_ID = value;
        }
    }
    public String Groom_First_Name
    {
        get
        {
            return m_Groom_First_Name;
        }
        set
        {
            m_Groom_First_Name = value;
        }
    }
    public String Groom_Middle_Int
    {
        get
        {
            return m_Groom_Middle_Int;
        }
        set
        {
            m_Groom_Middle_Int = value;
        }
    }
    public String Groom_Last_Name
    {
        get
        {
            return m_Groom_Last_Name;
        }
        set
        {
            m_Groom_Last_Name = value;
        }
    }
}

 
