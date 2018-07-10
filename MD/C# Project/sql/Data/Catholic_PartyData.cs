using System;
using System.Data;
using System.Data.SqlClient;

public class Catholic_PartyData
{

    public static DataTable SelectAll()
    {
        SqlConnection connection = MarriageData.GetConnection();
        string selectStatement
            = "SELECT "  
            + "     [Catholic Party I D] = [Catholic_Party].[Catholic_Party_ID] "
            + "    ,[Catholic Party Category] = [Catholic_Party].[Catholic_Party_Category] "
            + "FROM " 
            + "     [Catholic_Party] " 
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
            + "     [Catholic_Party].[Catholic_Party_ID] "
            + "    ,[Catholic_Party].[Catholic_Party_Category] "
            + "FROM " 
            + "     [Catholic_Party] " 
                + "WHERE " 
                + "     (@Catholic_Party_ID IS NULL OR @Catholic_Party_ID = '' OR [Catholic_Party].[Catholic_Party_ID] LIKE '%' + LTRIM(RTRIM(@Catholic_Party_ID)) + '%') " 
                + "AND   (@Catholic_Party_Category IS NULL OR @Catholic_Party_Category = '' OR [Catholic_Party].[Catholic_Party_Category] LIKE '%' + LTRIM(RTRIM(@Catholic_Party_Category)) + '%') " 
                + "";
        } else if (sCondition == "Equals") {
            selectStatement
                = "SELECT "
            + "     [Catholic_Party].[Catholic_Party_ID] "
            + "    ,[Catholic_Party].[Catholic_Party_Category] "
            + "FROM " 
            + "     [Catholic_Party] " 
                + "WHERE " 
                + "     (@Catholic_Party_ID IS NULL OR @Catholic_Party_ID = '' OR [Catholic_Party].[Catholic_Party_ID] = LTRIM(RTRIM(@Catholic_Party_ID))) " 
                + "AND   (@Catholic_Party_Category IS NULL OR @Catholic_Party_Category = '' OR [Catholic_Party].[Catholic_Party_Category] = LTRIM(RTRIM(@Catholic_Party_Category))) " 
                + "";
        } else if  (sCondition == "Starts with...") {
            selectStatement
                = "SELECT "
            + "     [Catholic_Party].[Catholic_Party_ID] "
            + "    ,[Catholic_Party].[Catholic_Party_Category] "
            + "FROM " 
            + "     [Catholic_Party] " 
                + "WHERE " 
                + "     (@Catholic_Party_ID IS NULL OR @Catholic_Party_ID = '' OR [Catholic_Party].[Catholic_Party_ID] LIKE LTRIM(RTRIM(@Catholic_Party_ID)) + '%') " 
                + "AND   (@Catholic_Party_Category IS NULL OR @Catholic_Party_Category = '' OR [Catholic_Party].[Catholic_Party_Category] LIKE LTRIM(RTRIM(@Catholic_Party_Category)) + '%') " 
                + "";
        } else if  (sCondition == "More than...") {
            selectStatement
                = "SELECT "
            + "     [Catholic_Party].[Catholic_Party_ID] "
            + "    ,[Catholic_Party].[Catholic_Party_Category] "
            + "FROM " 
            + "     [Catholic_Party] " 
                + "WHERE " 
                + "     (@Catholic_Party_ID IS NULL OR @Catholic_Party_ID = '' OR [Catholic_Party].[Catholic_Party_ID] > LTRIM(RTRIM(@Catholic_Party_ID))) " 
                + "AND   (@Catholic_Party_Category IS NULL OR @Catholic_Party_Category = '' OR [Catholic_Party].[Catholic_Party_Category] > LTRIM(RTRIM(@Catholic_Party_Category))) " 
                + "";
        } else if  (sCondition == "Less than...") {
            selectStatement
                = "SELECT " 
            + "     [Catholic_Party].[Catholic_Party_ID] "
            + "    ,[Catholic_Party].[Catholic_Party_Category] "
            + "FROM " 
            + "     [Catholic_Party] " 
                + "WHERE " 
                + "     (@Catholic_Party_ID IS NULL OR @Catholic_Party_ID = '' OR [Catholic_Party].[Catholic_Party_ID] < LTRIM(RTRIM(@Catholic_Party_ID))) " 
                + "AND   (@Catholic_Party_Category IS NULL OR @Catholic_Party_Category = '' OR [Catholic_Party].[Catholic_Party_Category] < LTRIM(RTRIM(@Catholic_Party_Category))) " 
                + "";
        } else if  (sCondition == "Equal or more than...") {
            selectStatement
                = "SELECT "
            + "     [Catholic_Party].[Catholic_Party_ID] "
            + "    ,[Catholic_Party].[Catholic_Party_Category] "
            + "FROM " 
            + "     [Catholic_Party] " 
                + "WHERE " 
                + "     (@Catholic_Party_ID IS NULL OR @Catholic_Party_ID = '' OR [Catholic_Party].[Catholic_Party_ID] >= LTRIM(RTRIM(@Catholic_Party_ID))) " 
                + "AND   (@Catholic_Party_Category IS NULL OR @Catholic_Party_Category = '' OR [Catholic_Party].[Catholic_Party_Category] >= LTRIM(RTRIM(@Catholic_Party_Category))) " 
                + "";
        } else if (sCondition == "Equal or less than...") {
            selectStatement 
                = "SELECT "
            + "     [Catholic_Party].[Catholic_Party_ID] "
            + "    ,[Catholic_Party].[Catholic_Party_Category] "
            + "FROM " 
            + "     [Catholic_Party] " 
                + "WHERE " 
                + "     (@Catholic_Party_ID IS NULL OR @Catholic_Party_ID = '' OR [Catholic_Party].[Catholic_Party_ID] <= LTRIM(RTRIM(@Catholic_Party_ID))) " 
                + "AND   (@Catholic_Party_Category IS NULL OR @Catholic_Party_Category = '' OR [Catholic_Party].[Catholic_Party_Category] <= LTRIM(RTRIM(@Catholic_Party_Category))) " 
                + "";
        }
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        if (sField == "Catholic Party I D") {
            selectCommand.Parameters.AddWithValue("@Catholic_Party_ID", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@Catholic_Party_ID", DBNull.Value); }
        if (sField == "Catholic Party Category") {
            selectCommand.Parameters.AddWithValue("@Catholic_Party_Category", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@Catholic_Party_Category", DBNull.Value); }
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

    public static Catholic_Party Select_Record(Catholic_Party clsCatholic_PartyPara)
    {
        Catholic_Party clsCatholic_Party = new Catholic_Party();
        SqlConnection connection = MarriageData.GetConnection();
        string selectStatement
            = "SELECT " 
            + "     [Catholic_Party_ID] "
            + "    ,[Catholic_Party_Category] "
            + "FROM "
            + "     [Catholic_Party] "
            + "WHERE "
            + "     [Catholic_Party_ID] = @Catholic_Party_ID "
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        selectCommand.Parameters.AddWithValue("@Catholic_Party_ID", clsCatholic_PartyPara.Catholic_Party_ID);
        try
        {
            connection.Open();
            SqlDataReader reader
                = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                clsCatholic_Party.Catholic_Party_ID = System.Convert.ToInt16(reader["Catholic_Party_ID"]);
                clsCatholic_Party.Catholic_Party_Category = System.Convert.ToString(reader["Catholic_Party_Category"]);
            }
            else
            {
                clsCatholic_Party = null;
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
        return clsCatholic_Party;
    }

    public static bool Add(Catholic_Party clsCatholic_Party)
    {
        SqlConnection connection = MarriageData.GetConnection();
        string insertStatement
            = "INSERT " 
            + "     [Catholic_Party] "
            + "     ( "
            + "     [Catholic_Party_Category] "
            + "     ) "
            + "VALUES " 
            + "     ( "
            + "     @Catholic_Party_Category "
            + "     ) "
            + "";
        SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
        insertCommand.CommandType = CommandType.Text;
        insertCommand.Parameters.AddWithValue("@Catholic_Party_Category", clsCatholic_Party.Catholic_Party_Category);
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

    public static bool Update(Catholic_Party oldCatholic_Party, 
           Catholic_Party newCatholic_Party)
    {
        SqlConnection connection = MarriageData.GetConnection();
        string updateStatement
            = "UPDATE "  
            + "     [Catholic_Party] "
            + "SET "
            + "     [Catholic_Party_Category] = @NewCatholic_Party_Category "
            + "WHERE "
            + "     [Catholic_Party_ID] = @OldCatholic_Party_ID " 
            + " AND [Catholic_Party_Category] = @OldCatholic_Party_Category " 
            + "";
        SqlCommand updateCommand = new SqlCommand(updateStatement, connection);
        updateCommand.CommandType = CommandType.Text;
        updateCommand.Parameters.AddWithValue("@NewCatholic_Party_Category", newCatholic_Party.Catholic_Party_Category);
        updateCommand.Parameters.AddWithValue("@OldCatholic_Party_ID", oldCatholic_Party.Catholic_Party_ID);
        updateCommand.Parameters.AddWithValue("@OldCatholic_Party_Category", oldCatholic_Party.Catholic_Party_Category);
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

    public static bool Delete(Catholic_Party clsCatholic_Party)
    {
        SqlConnection connection = MarriageData.GetConnection();
        string deleteStatement
            = "DELETE FROM "  
            + "     [Catholic_Party] "
            + "WHERE " 
            + "     [Catholic_Party_ID] = @OldCatholic_Party_ID " 
            + " AND [Catholic_Party_Category] = @OldCatholic_Party_Category " 
            + "";
        SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection);
        deleteCommand.CommandType = CommandType.Text;
        deleteCommand.Parameters.AddWithValue("@OldCatholic_Party_ID", clsCatholic_Party.Catholic_Party_ID);
        deleteCommand.Parameters.AddWithValue("@OldCatholic_Party_Category", clsCatholic_Party.Catholic_Party_Category);
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

 
