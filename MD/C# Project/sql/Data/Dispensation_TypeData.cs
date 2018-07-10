using System;
using System.Data;
using System.Data.SqlClient;

public class Dispensation_TypeData
{

    public static DataTable SelectAll()
    {
        SqlConnection connection = MarriageData.GetConnection();
        string selectStatement
            = "SELECT "  
            + "     [Dispensation Type I D] = [Dispensation_Type].[Dispensation_Type_ID] "
            + "    ,[Dispensation Type Name] = [Dispensation_Type].[Dispensation_Type_Name] "
            + "FROM " 
            + "     [Dispensation_Type] " 
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        DataTable dt = new DataTable();
        try
        {
            connection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            if (reader.HasRows) {
                dt.Load(reader); }
            reader.Close();
        }
        catch (SqlException)
        {
            return dt;
        }
        finally
        {
            connection.Close();
        }
        return dt;
    }

    public static DataTable Search(string sField, string sCondition, string sValue)
    {
        SqlConnection connection = MarriageData.GetConnection();
        string selectStatement = "";
        if (sCondition == "Contains") {
            selectStatement
                = "SELECT "
            + "     [Dispensation_Type].[Dispensation_Type_ID] "
            + "    ,[Dispensation_Type].[Dispensation_Type_Name] "
            + "FROM " 
            + "     [Dispensation_Type] " 
                + "WHERE " 
                + "     (@Dispensation_Type_ID IS NULL OR @Dispensation_Type_ID = '' OR [Dispensation_Type].[Dispensation_Type_ID] LIKE '%' + LTRIM(RTRIM(@Dispensation_Type_ID)) + '%') " 
                + "AND   (@Dispensation_Type_Name IS NULL OR @Dispensation_Type_Name = '' OR [Dispensation_Type].[Dispensation_Type_Name] LIKE '%' + LTRIM(RTRIM(@Dispensation_Type_Name)) + '%') " 
                + "";
        } else if (sCondition == "Equals") {
            selectStatement
                = "SELECT "
            + "     [Dispensation_Type].[Dispensation_Type_ID] "
            + "    ,[Dispensation_Type].[Dispensation_Type_Name] "
            + "FROM " 
            + "     [Dispensation_Type] " 
                + "WHERE " 
                + "     (@Dispensation_Type_ID IS NULL OR @Dispensation_Type_ID = '' OR [Dispensation_Type].[Dispensation_Type_ID] = LTRIM(RTRIM(@Dispensation_Type_ID))) " 
                + "AND   (@Dispensation_Type_Name IS NULL OR @Dispensation_Type_Name = '' OR [Dispensation_Type].[Dispensation_Type_Name] = LTRIM(RTRIM(@Dispensation_Type_Name))) " 
                + "";
        } else if  (sCondition == "Starts with...") {
            selectStatement
                = "SELECT "
            + "     [Dispensation_Type].[Dispensation_Type_ID] "
            + "    ,[Dispensation_Type].[Dispensation_Type_Name] "
            + "FROM " 
            + "     [Dispensation_Type] " 
                + "WHERE " 
                + "     (@Dispensation_Type_ID IS NULL OR @Dispensation_Type_ID = '' OR [Dispensation_Type].[Dispensation_Type_ID] LIKE LTRIM(RTRIM(@Dispensation_Type_ID)) + '%') " 
                + "AND   (@Dispensation_Type_Name IS NULL OR @Dispensation_Type_Name = '' OR [Dispensation_Type].[Dispensation_Type_Name] LIKE LTRIM(RTRIM(@Dispensation_Type_Name)) + '%') " 
                + "";
        } else if  (sCondition == "More than...") {
            selectStatement
                = "SELECT "
            + "     [Dispensation_Type].[Dispensation_Type_ID] "
            + "    ,[Dispensation_Type].[Dispensation_Type_Name] "
            + "FROM " 
            + "     [Dispensation_Type] " 
                + "WHERE " 
                + "     (@Dispensation_Type_ID IS NULL OR @Dispensation_Type_ID = '' OR [Dispensation_Type].[Dispensation_Type_ID] > LTRIM(RTRIM(@Dispensation_Type_ID))) " 
                + "AND   (@Dispensation_Type_Name IS NULL OR @Dispensation_Type_Name = '' OR [Dispensation_Type].[Dispensation_Type_Name] > LTRIM(RTRIM(@Dispensation_Type_Name))) " 
                + "";
        } else if  (sCondition == "Less than...") {
            selectStatement
                = "SELECT " 
            + "     [Dispensation_Type].[Dispensation_Type_ID] "
            + "    ,[Dispensation_Type].[Dispensation_Type_Name] "
            + "FROM " 
            + "     [Dispensation_Type] " 
                + "WHERE " 
                + "     (@Dispensation_Type_ID IS NULL OR @Dispensation_Type_ID = '' OR [Dispensation_Type].[Dispensation_Type_ID] < LTRIM(RTRIM(@Dispensation_Type_ID))) " 
                + "AND   (@Dispensation_Type_Name IS NULL OR @Dispensation_Type_Name = '' OR [Dispensation_Type].[Dispensation_Type_Name] < LTRIM(RTRIM(@Dispensation_Type_Name))) " 
                + "";
        } else if  (sCondition == "Equal or more than...") {
            selectStatement
                = "SELECT "
            + "     [Dispensation_Type].[Dispensation_Type_ID] "
            + "    ,[Dispensation_Type].[Dispensation_Type_Name] "
            + "FROM " 
            + "     [Dispensation_Type] " 
                + "WHERE " 
                + "     (@Dispensation_Type_ID IS NULL OR @Dispensation_Type_ID = '' OR [Dispensation_Type].[Dispensation_Type_ID] >= LTRIM(RTRIM(@Dispensation_Type_ID))) " 
                + "AND   (@Dispensation_Type_Name IS NULL OR @Dispensation_Type_Name = '' OR [Dispensation_Type].[Dispensation_Type_Name] >= LTRIM(RTRIM(@Dispensation_Type_Name))) " 
                + "";
        } else if (sCondition == "Equal or less than...") {
            selectStatement 
                = "SELECT "
            + "     [Dispensation_Type].[Dispensation_Type_ID] "
            + "    ,[Dispensation_Type].[Dispensation_Type_Name] "
            + "FROM " 
            + "     [Dispensation_Type] " 
                + "WHERE " 
                + "     (@Dispensation_Type_ID IS NULL OR @Dispensation_Type_ID = '' OR [Dispensation_Type].[Dispensation_Type_ID] <= LTRIM(RTRIM(@Dispensation_Type_ID))) " 
                + "AND   (@Dispensation_Type_Name IS NULL OR @Dispensation_Type_Name = '' OR [Dispensation_Type].[Dispensation_Type_Name] <= LTRIM(RTRIM(@Dispensation_Type_Name))) " 
                + "";
        }
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        if (sField == "Dispensation Type I D") {
            selectCommand.Parameters.AddWithValue("@Dispensation_Type_ID", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@Dispensation_Type_ID", DBNull.Value); }
        if (sField == "Dispensation Type Name") {
            selectCommand.Parameters.AddWithValue("@Dispensation_Type_Name", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@Dispensation_Type_Name", DBNull.Value); }
        DataTable dt = new DataTable();
        try
        {
            connection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            if (reader.HasRows) {
                dt.Load(reader); }
            reader.Close();
        }
        catch (SqlException)
        {
            return dt;
        }
        finally
        {
            connection.Close();
        }
        return dt;
    }

    public static Dispensation_Type Select_Record(Dispensation_Type clsDispensation_TypePara)
    {
        Dispensation_Type clsDispensation_Type = new Dispensation_Type();
        SqlConnection connection = MarriageData.GetConnection();
        string selectStatement
            = "SELECT " 
            + "     [Dispensation_Type_ID] "
            + "    ,[Dispensation_Type_Name] "
            + "FROM "
            + "     [Dispensation_Type] "
            + "WHERE "
            + "     [Dispensation_Type_ID] = @Dispensation_Type_ID "
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        selectCommand.Parameters.AddWithValue("@Dispensation_Type_ID", clsDispensation_TypePara.Dispensation_Type_ID);
        try
        {
            connection.Open();
            SqlDataReader reader
                = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                clsDispensation_Type.Dispensation_Type_ID = System.Convert.ToInt16(reader["Dispensation_Type_ID"]);
                clsDispensation_Type.Dispensation_Type_Name = System.Convert.ToString(reader["Dispensation_Type_Name"]);
            }
            else
            {
                clsDispensation_Type = null;
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
        return clsDispensation_Type;
    }

    public static bool Add(Dispensation_Type clsDispensation_Type)
    {
        SqlConnection connection = MarriageData.GetConnection();
        string insertStatement
            = "INSERT " 
            + "     [Dispensation_Type] "
            + "     ( "
            + "     [Dispensation_Type_Name] "
            + "     ) "
            + "VALUES " 
            + "     ( "
            + "     @Dispensation_Type_Name "
            + "     ) "
            + "";
        SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
        insertCommand.CommandType = CommandType.Text;
        insertCommand.Parameters.AddWithValue("@Dispensation_Type_Name", clsDispensation_Type.Dispensation_Type_Name);
        try
        {
            connection.Open();
            int count = insertCommand.ExecuteNonQuery();
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        finally
        {
            connection.Close();
        }
    }

    public static bool Update(Dispensation_Type oldDispensation_Type, 
           Dispensation_Type newDispensation_Type)
    {
        SqlConnection connection = MarriageData.GetConnection();
        string updateStatement
            = "UPDATE "  
            + "     [Dispensation_Type] "
            + "SET "
            + "     [Dispensation_Type_Name] = @NewDispensation_Type_Name "
            + "WHERE "
            + "     [Dispensation_Type_ID] = @OldDispensation_Type_ID " 
            + " AND [Dispensation_Type_Name] = @OldDispensation_Type_Name " 
            + "";
        SqlCommand updateCommand = new SqlCommand(updateStatement, connection);
        updateCommand.CommandType = CommandType.Text;
        updateCommand.Parameters.AddWithValue("@NewDispensation_Type_Name", newDispensation_Type.Dispensation_Type_Name);
        updateCommand.Parameters.AddWithValue("@OldDispensation_Type_ID", oldDispensation_Type.Dispensation_Type_ID);
        updateCommand.Parameters.AddWithValue("@OldDispensation_Type_Name", oldDispensation_Type.Dispensation_Type_Name);
        try
        {
            connection.Open();
            int count = updateCommand.ExecuteNonQuery();
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        finally
        {
            connection.Close();
        }
    }

    public static bool Delete(Dispensation_Type clsDispensation_Type)
    {
        SqlConnection connection = MarriageData.GetConnection();
        string deleteStatement
            = "DELETE FROM "  
            + "     [Dispensation_Type] "
            + "WHERE " 
            + "     [Dispensation_Type_ID] = @OldDispensation_Type_ID " 
            + " AND [Dispensation_Type_Name] = @OldDispensation_Type_Name " 
            + "";
        SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection);
        deleteCommand.CommandType = CommandType.Text;
        deleteCommand.Parameters.AddWithValue("@OldDispensation_Type_ID", clsDispensation_Type.Dispensation_Type_ID);
        deleteCommand.Parameters.AddWithValue("@OldDispensation_Type_Name", clsDispensation_Type.Dispensation_Type_Name);
        try
        {
            connection.Open();
            int count = deleteCommand.ExecuteNonQuery();
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        finally
        {
            connection.Close();
        }
    }

}

 
