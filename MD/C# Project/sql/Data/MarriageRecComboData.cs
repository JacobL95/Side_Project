using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class MarriageRec_GroomData21
{
    public static List<MarriageRec_Groom21> List()
    {
        List<MarriageRec_Groom21> MarriageRec_GroomList = new List<MarriageRec_Groom21>();
        SqlConnection connection = MarriageData.GetConnection();
        string selectStatement 
            = "SELECT "  
            + "     [Groom_ID] " 
            + "FROM " 
            + "     [Groom] " 
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        try
        {
            connection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            MarriageRec_Groom21 clsMarriageRec_Groom = new MarriageRec_Groom21();
            while (reader.Read())
            {
                clsMarriageRec_Groom = new MarriageRec_Groom21();
                clsMarriageRec_Groom.Groom_ID = System.Convert.ToInt32(reader["Groom_ID"]);
                MarriageRec_GroomList.Add(clsMarriageRec_Groom);
            }
            reader.Close();
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        finally
        {
            connection.Close();
        }
        return MarriageRec_GroomList;
    }

}

public class MarriageRec_BrideData22
{
    public static List<MarriageRec_Bride22> List()
    {
        List<MarriageRec_Bride22> MarriageRec_BrideList = new List<MarriageRec_Bride22>();
        SqlConnection connection = MarriageData.GetConnection();
        string selectStatement 
            = "SELECT "  
            + "     [Bride_ID] " 
            + "FROM " 
            + "     [Bride] " 
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        try
        {
            connection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            MarriageRec_Bride22 clsMarriageRec_Bride = new MarriageRec_Bride22();
            while (reader.Read())
            {
                clsMarriageRec_Bride = new MarriageRec_Bride22();
                clsMarriageRec_Bride.Bride_ID = System.Convert.ToInt32(reader["Bride_ID"]);
                MarriageRec_BrideList.Add(clsMarriageRec_Bride);
            }
            reader.Close();
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        finally
        {
            connection.Close();
        }
        return MarriageRec_BrideList;
    }

}

public class MarriageRec_Dispensation_TypeData26
{
    public static List<MarriageRec_Dispensation_Type26> List()
    {
        List<MarriageRec_Dispensation_Type26> MarriageRec_Dispensation_TypeList = new List<MarriageRec_Dispensation_Type26>();
        SqlConnection connection = MarriageData.GetConnection();
        string selectStatement 
            = "SELECT "  
            + "     [Dispensation_Type_ID] " 
            + "FROM " 
            + "     [Dispensation_Type] " 
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        try
        {
            connection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            MarriageRec_Dispensation_Type26 clsMarriageRec_Dispensation_Type = new MarriageRec_Dispensation_Type26();
            while (reader.Read())
            {
                clsMarriageRec_Dispensation_Type = new MarriageRec_Dispensation_Type26();
                clsMarriageRec_Dispensation_Type.Dispensation_Type_ID = System.Convert.ToInt16(reader["Dispensation_Type_ID"]);
                MarriageRec_Dispensation_TypeList.Add(clsMarriageRec_Dispensation_Type);
            }
            reader.Close();
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        finally
        {
            connection.Close();
        }
        return MarriageRec_Dispensation_TypeList;
    }

}

public class MarriageRec_DispensationData28
{
    public static List<MarriageRec_Dispensation28> List()
    {
        List<MarriageRec_Dispensation28> MarriageRec_DispensationList = new List<MarriageRec_Dispensation28>();
        SqlConnection connection = MarriageData.GetConnection();
        string selectStatement 
            = "SELECT "  
            + "     [Dispensation_ID] " 
            + "FROM " 
            + "     [Dispensation] " 
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        try
        {
            connection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            MarriageRec_Dispensation28 clsMarriageRec_Dispensation = new MarriageRec_Dispensation28();
            while (reader.Read())
            {
                clsMarriageRec_Dispensation = new MarriageRec_Dispensation28();
                clsMarriageRec_Dispensation.Dispensation_ID = System.Convert.ToInt32(reader["Dispensation_ID"]);
                MarriageRec_DispensationList.Add(clsMarriageRec_Dispensation);
            }
            reader.Close();
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        finally
        {
            connection.Close();
        }
        return MarriageRec_DispensationList;
    }

}

public class MarriageRec_Catholic_PartyData29
{
    public static List<MarriageRec_Catholic_Party29> List()
    {
        List<MarriageRec_Catholic_Party29> MarriageRec_Catholic_PartyList = new List<MarriageRec_Catholic_Party29>();
        SqlConnection connection = MarriageData.GetConnection();
        string selectStatement 
            = "SELECT "  
            + "     [Catholic_Party_ID] " 
            + "FROM " 
            + "     [Catholic_Party] " 
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        try
        {
            connection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            MarriageRec_Catholic_Party29 clsMarriageRec_Catholic_Party = new MarriageRec_Catholic_Party29();
            while (reader.Read())
            {
                clsMarriageRec_Catholic_Party = new MarriageRec_Catholic_Party29();
                clsMarriageRec_Catholic_Party.Catholic_Party_ID = System.Convert.ToInt16(reader["Catholic_Party_ID"]);
                MarriageRec_Catholic_PartyList.Add(clsMarriageRec_Catholic_Party);
            }
            reader.Close();
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        finally
        {
            connection.Close();
        }
        return MarriageRec_Catholic_PartyList;
    }

}

public class MarriageRec_ParishData32
{
    public static List<MarriageRec_Parish32> List()
    {
        List<MarriageRec_Parish32> MarriageRec_ParishList = new List<MarriageRec_Parish32>();
        SqlConnection connection = MarriageData.GetConnection();
        string selectStatement 
            = "SELECT "  
            + "     [Parish_ID] " 
            + "FROM " 
            + "     [Parish] " 
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        try
        {
            connection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            MarriageRec_Parish32 clsMarriageRec_Parish = new MarriageRec_Parish32();
            while (reader.Read())
            {
                clsMarriageRec_Parish = new MarriageRec_Parish32();
                clsMarriageRec_Parish.Parish_ID = System.Convert.ToInt16(reader["Parish_ID"]);
                MarriageRec_ParishList.Add(clsMarriageRec_Parish);
            }
            reader.Close();
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        finally
        {
            connection.Close();
        }
        return MarriageRec_ParishList;
    }

}

public class MarriageRec_ParishData33
{
    public static List<MarriageRec_Parish33> List()
    {
        List<MarriageRec_Parish33> MarriageRec_ParishList = new List<MarriageRec_Parish33>();
        SqlConnection connection = MarriageData.GetConnection();
        string selectStatement 
            = "SELECT "  
            + "     [Parish_ID] " 
            + "FROM " 
            + "     [Parish] " 
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        try
        {
            connection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            MarriageRec_Parish33 clsMarriageRec_Parish = new MarriageRec_Parish33();
            while (reader.Read())
            {
                clsMarriageRec_Parish = new MarriageRec_Parish33();
                clsMarriageRec_Parish.Parish_ID = System.Convert.ToInt16(reader["Parish_ID"]);
                MarriageRec_ParishList.Add(clsMarriageRec_Parish);
            }
            reader.Close();
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        finally
        {
            connection.Close();
        }
        return MarriageRec_ParishList;
    }

}


 
