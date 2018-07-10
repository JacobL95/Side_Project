using System;
public class Parish
{
    private Int16 m_Parish_ID;
    private String m_ParishName;
    private Boolean m_KCSJDiocese;

    public Parish() { }

    public Int16 Parish_ID
    {
        get
        {
            return m_Parish_ID;
        }
        set
        {
            m_Parish_ID = value;
        }
    }
    public String ParishName
    {
        get
        {
            return m_ParishName;
        }
        set
        {
            m_ParishName = value;
        }
    }
    public Boolean KCSJDiocese
    {
        get
        {
            return m_KCSJDiocese;
        }
        set
        {
            m_KCSJDiocese = value;
        }
    }
}

 
