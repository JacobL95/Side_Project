using System;
public class Dispensation_Type
{
    private Int16 m_Dispensation_Type_ID;
    private String m_Dispensation_Type_Name;

    public Dispensation_Type() { }

    public Int16 Dispensation_Type_ID
    {
        get
        {
            return m_Dispensation_Type_ID;
        }
        set
        {
            m_Dispensation_Type_ID = value;
        }
    }
    public String Dispensation_Type_Name
    {
        get
        {
            return m_Dispensation_Type_Name;
        }
        set
        {
            m_Dispensation_Type_Name = value;
        }
    }
}

 
