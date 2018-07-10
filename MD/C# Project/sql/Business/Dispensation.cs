using System;
public class Dispensation
{
    private Int32 m_Dispensation_ID;
    private String m_Dispensation_Category;

    public Dispensation() { }

    public Int32 Dispensation_ID
    {
        get
        {
            return m_Dispensation_ID;
        }
        set
        {
            m_Dispensation_ID = value;
        }
    }
    public String Dispensation_Category
    {
        get
        {
            return m_Dispensation_Category;
        }
        set
        {
            m_Dispensation_Category = value;
        }
    }
}

 
