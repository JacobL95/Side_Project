using System;
using System.Data;
using System.Data.SqlClient;

public class DispensationData
{

    public static DataTable SelectAll()
    {
        SqlConnection connection = MarriageData.GetConnection();
        string selectStatement
            = "SELECT "  
            + "     [Dispensation I D] = [Dispensation].[Dispensation_ID] "
            + "    ,[Dispensation Category] = [Dispensation].[Dispensation_Category] "
            + "FROM " 
            + "     [Dispensation] " 
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
            + "     [Dispensation].[Dispensation_ID] "
            + "    ,[Dispensation].[Dispensation_Category] "
            + "FROM " 
            + "     [Dispensation] " 
                + "WHERE " 
                + "     (@Dispensation_ID IS NULL OR @Dispensation_ID = '' OR [Dispensation].[Dispensation_ID] LIKE '%' + LTRIM(RTRIM(@Dispensation_ID)) + '%') " 
                + "AND   (@Dispensation_Category IS NULL OR @Dispensation_Category = '' OR [Dispensation].[Dispensation_Category] LIKE '%' + LTRIM(RTRIM(@Dispensation_Category)) + '%') " 
                + "";
        } else if (sCondition == "Equals") {
            selectStatement
                = "SELECT "
            + "     [Dispensation].[Dispensation_ID] "
            + "    ,[Dispensation].[Dispensation_Category] "
            + "FROM " 
            + "     [Dispensation] " 
                + "WHERE " 
                + "     (@Dispensation_ID IS NULL OR @Dispensation_ID = '' OR [Dispensation].[Dispensation_ID] = LTRIM(RTRIM(@Dispensation_ID))) " 
                + "AND   (@Dispensation_Category IS NULL OR @Dispensation_Category = '' OR [Dispensation].[Dispensation_Category] = LTRIM(RTRIM(@Dispensation_Category))) " 
                + "";
        } else if  (sCondition == "Starts with...") {
            selectStatement
                = "SELECT "
            + "     [Dispensation].[Dispensation_ID] "
            + "    ,[Dispensation].[Dispensation_Category] "
            + "FROM " 
            + "     [Dispensation] " 
                + "WHERE " 
                + "     (@Dispensation_ID IS NULL OR @Dispensation_ID = '' OR [Dispensation].[Dispensation_ID] LIKE LTRIM(RTRIM(@Dispensation_ID)) + '%') " 
                + "AND   (@Dispensation_Category IS NULL OR @Dispensation_Category = '' OR [Dispensation].[Dispensation_Category] LIKE LTRIM(RTRIM(@Dispensation_Category)) + '%') " 
                + "";
        } else if  (sCondition == "More than...") {
            selectStatement
                = "SELECT "
            + "     [Dispensation].[Dispensation_ID] "
            + "    ,[Dispensation].[Dispensation_Category] "
            + "FROM " 
            + "     [Dispensation] " 
                + "WHERE " 
                + "     (@Dispensation_ID IS NULL OR @Dispensation_ID = '' OR [Dispensation].[Dispensation_ID] > LTRIM(RTRIM(@Dispensation_ID))) " 
                + "AND   (@Dispensation_Category IS NULL OR @Dispensation_Category = '' OR [Dispensation].[Dispensation_Category] > LTRIM(RTRIM(@Dispensation_Category))) " 
                + "";
        } else if  (sCondition == "Less than...") {
            selectStatement
                = "SELECT " 
            + "     [Dispensation].[Dispensation_ID] "
            + "    ,[Dispensation].[Dispensation_Category] "
            + "FROM " 
            + "     [Dispensation] " 
                + "WHERE " 
                + "     (@Dispensation_ID IS NULL OR @Dispensation_ID = '' OR [Dispensation].[Dispensation_ID] < LTRIM(RTRIM(@Dispensation_ID))) " 
                + "AND   (@Dispensation_Category IS NULL OR @Dispensation_Category = '' OR [Dispensation].[Dispensation_Category] < LTRIM(RTRIM(@Dispensation_Category))) " 
                + "";
        } else if  (sCondition == "Equal or more than...") {
            selectStatement
                = "SELECT "
            + "     [Dispensation].[Dispensation_ID] "
            + "    ,[Dispensation].[Dispensation_Category] "
            + "FROM " 
            + "     [Dispensation] " 
                + "WHERE " 
                + "     (@Dispensation_ID IS NULL OR @Dispensation_ID = '' OR [Dispensation].[Dispensation_ID] >= LTRIM(RTRIM(@Dispensation_ID))) " 
                + "AND   (@Dispensation_Category IS NULL OR @Dispensation_Category = '' OR [Dispensation].[Dispensation_Category] >= LTRIM(RTRIM(@Dispensation_Category))) " 
                + "";
        } else if (sCondition == "Equal or less than...") {
            selectStatement 
                = "SELECT "
            + "     [Dispensation].[Dispensation_ID] "
            + "    ,[Dispensation].[Dispensation_Category] "
            + "FROM " 
            + "     [Dispensation] " 
                + "WHERE " 
                + "     (@Dispensation_ID IS NULL OR @Dispensation_ID = '' OR [Dispensation].[Dispensation_ID] <= LTRIM(RTRIM(@Dispensation_ID))) " 
                + "AND   (@Dispensation_Category IS NULL OR @Dispensation_Category = '' OR [Dispensation].[Dispensation_Category] <= LTRIM(RTRIM(@Dispensation_Category))) " 
                + "";
        }
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        if (sField == "Dispensation I D") {
            selectCommand.Parameters.AddWithValue("@Dispensation_ID", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@Dispensation_ID", DBNull.Value); }
        if (sField == "Dispensation Category") {
            selectCommand.Parameters.AddWithValue("@Dispensation_Category", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@Dispensation_Category", DBNull.Value); }
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

    public static Dispensation Select_Record(Dispensation clsDispensationPara)
    {
        Dispensation clsDispensation = new Dispensation();
        SqlConnection connection = MarriageData.GetConnection();
        string selectStatement
            = "SELECT " 
            + "     [Dispensation_ID] "
            + "    ,[Dispensation_Category] "
            + "FROM "
            + "     [Dispensation] "
            + "WHERE "
            + "     [Dispensation_ID] = @Dispensation_ID "
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        selectCommand.Parameters.AddWithValue("@Dispensation_ID", clsDispensationPara.Dispensation_ID);
        try
        {
            connection.Open();
            SqlDataReader reader
                = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                clsDispensation.Dispensation_ID = System.Convert.ToInt32(reader["Dispensation_ID"]);
                clsDispensation.Dispensation_Category = System.Convert.ToString(reader["Dispensation_Category"]);
            }
            else
            {
                clsDispensation = null;
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
        return clsDispensation;
    }

    public static bool Add(Dispensation clsDispensation)
    {
        SqlConnection connection = MarriageData.GetConnection();
        string insertStatement
            = "INSERT " 
            + "     [Dispensation] "
            + "     ( "
            + "     [Dispensation_Category] "
            + "     ) "
            + "VALUES " 
            + "     ( "
            + "     @Dispensation_Category "
            + "     ) "
            + "";
        SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
        insertCommand.CommandType = CommandType.Text;
        insertCommand.Parameters.AddWithValue("@Dispensation_Category", clsDispensation.Dispensation_Category);
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

    public static bool Update(Dispensation oldDispensation, 
           Dispensation newDispensation)
    {
        SqlConnection connection = MarriageData.GetConnection();
        string updateStatement
            = "UPDATE "  
            + "     [Dispensation] "
            + "SET "
            + "     [Dispensation_Category] = @NewDispensation_Category "
            + "WHERE "
            + "     [Dispensation_ID] = @OldDispensation_ID " 
            + " AND [Dispensation_Category] = @OldDispensation_Category " 
            + "";
        SqlCommand updateCommand = new SqlCommand(updateStatement, connection);
        updateCommand.CommandType = CommandType.Text;
        updateCommand.Parameters.AddWithValue("@NewDispensation_Category", newDispensation.Dispensation_Category);
        updateCommand.Parameters.AddWithValue("@OldDispensation_ID", oldDispensation.Dispensation_ID);
        updateCommand.Parameters.AddWithValue("@OldDispensation_Category", oldDispensation.Dispensation_Category);
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

    public static bool Delete(Dispensation clsDispensation)
    {
        SqlConnection connection = MarriageData.GetConnection();
        string deleteStatement
            = "DELETE FROM "  
            + "     [Dispensation] "
            + "WHERE " 
            + "     [Dispensation_ID] = @OldDispensation_ID " 
            + " AND [Dispensation_Category] = @OldDispensation_Category " 
            + "";
        SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection);
        deleteCommand.CommandType = CommandType.Text;
        deleteCommand.Parameters.AddWithValue("@OldDispensation_ID", clsDispensation.Dispensation_ID);
        deleteCommand.Parameters.AddWithValue("@OldDispensation_Category", clsDispensation.Dispensation_Category);
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

 
