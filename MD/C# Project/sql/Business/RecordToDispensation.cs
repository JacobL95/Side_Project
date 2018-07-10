using System;
public class RecordToDispensation
{
    private Int32 m_id;
    private Int64 m_Record_Id;
    private Int32 m_Dispensation_Id;

    public RecordToDispensation() { }

    public Int32 id
    {
        get
        {
            return m_id;
        }
        set
        {
            m_id = value;
        }
    }
    public Int64 Record_Id
    {
        get
        {
            return m_Record_Id;
        }
        set
        {
            m_Record_Id = value;
        }
    }
    public Int32 Dispensation_Id
    {
        get
        {
            return m_Dispensation_Id;
        }
        set
        {
            m_Dispensation_Id = value;
        }
    }
}

 
