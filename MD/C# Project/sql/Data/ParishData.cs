using System;
using System.Data;
using System.Data.SqlClient;

public class ParishData
{

    public static DataTable SelectAll()
    {
        SqlConnection connection = MarriageData.GetConnection();
        string selectStatement
            = "SELECT "  
            + "     [Parish I D] = [Parish].[Parish_ID] "
            + "    ,[Parish Name] = [Parish].[ParishName] "
            + "    ,[K C S J Diocese] = [Parish].[KCSJDiocese] "
            + "FROM " 
            + "     [Parish] " 
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
            + "     [Parish].[Parish_ID] "
            + "    ,[Parish].[ParishName] "
            + "    ,[Parish].[KCSJDiocese] "
            + "FROM " 
            + "     [Parish] " 
                + "WHERE " 
                + "     (@Parish_ID IS NULL OR @Parish_ID = '' OR [Parish].[Parish_ID] LIKE '%' + LTRIM(RTRIM(@Parish_ID)) + '%') " 
                + "AND   (@ParishName IS NULL OR @ParishName = '' OR [Parish].[ParishName] LIKE '%' + LTRIM(RTRIM(@ParishName)) + '%') " 
                + "AND   (@KCSJDiocese IS NULL OR @KCSJDiocese = '' OR [Parish].[KCSJDiocese] LIKE '%' + LTRIM(RTRIM(@KCSJDiocese)) + '%') " 
                + "";
        } else if (sCondition == "Equals") {
            selectStatement
                = "SELECT "
            + "     [Parish].[Parish_ID] "
            + "    ,[Parish].[ParishName] "
            + "    ,[Parish].[KCSJDiocese] "
            + "FROM " 
            + "     [Parish] " 
                + "WHERE " 
                + "     (@Parish_ID IS NULL OR @Parish_ID = '' OR [Parish].[Parish_ID] = LTRIM(RTRIM(@Parish_ID))) " 
                + "AND   (@ParishName IS NULL OR @ParishName = '' OR [Parish].[ParishName] = LTRIM(RTRIM(@ParishName))) " 
                + "AND   (@KCSJDiocese IS NULL OR @KCSJDiocese = '' OR [Parish].[KCSJDiocese] = LTRIM(RTRIM(@KCSJDiocese))) " 
                + "";
        } else if  (sCondition == "Starts with...") {
            selectStatement
                = "SELECT "
            + "     [Parish].[Parish_ID] "
            + "    ,[Parish].[ParishName] "
            + "    ,[Parish].[KCSJDiocese] "
            + "FROM " 
            + "     [Parish] " 
                + "WHERE " 
                + "     (@Parish_ID IS NULL OR @Parish_ID = '' OR [Parish].[Parish_ID] LIKE LTRIM(RTRIM(@Parish_ID)) + '%') " 
                + "AND   (@ParishName IS NULL OR @ParishName = '' OR [Parish].[ParishName] LIKE LTRIM(RTRIM(@ParishName)) + '%') " 
                + "AND   (@KCSJDiocese IS NULL OR @KCSJDiocese = '' OR [Parish].[KCSJDiocese] LIKE LTRIM(RTRIM(@KCSJDiocese)) + '%') " 
                + "";
        } else if  (sCondition == "More than...") {
            selectStatement
                = "SELECT "
            + "     [Parish].[Parish_ID] "
            + "    ,[Parish].[ParishName] "
            + "    ,[Parish].[KCSJDiocese] "
            + "FROM " 
            + "     [Parish] " 
                + "WHERE " 
                + "     (@Parish_ID IS NULL OR @Parish_ID = '' OR [Parish].[Parish_ID] > LTRIM(RTRIM(@Parish_ID))) " 
                + "AND   (@ParishName IS NULL OR @ParishName = '' OR [Parish].[ParishName] > LTRIM(RTRIM(@ParishName))) " 
                + "AND   (@KCSJDiocese IS NULL OR @KCSJDiocese = '' OR [Parish].[KCSJDiocese] > LTRIM(RTRIM(@KCSJDiocese))) " 
                + "";
        } else if  (sCondition == "Less than...") {
            selectStatement
                = "SELECT " 
            + "     [Parish].[Parish_ID] "
            + "    ,[Parish].[ParishName] "
            + "    ,[Parish].[KCSJDiocese] "
            + "FROM " 
            + "     [Parish] " 
                + "WHERE " 
                + "     (@Parish_ID IS NULL OR @Parish_ID = '' OR [Parish].[Parish_ID] < LTRIM(RTRIM(@Parish_ID))) " 
                + "AND   (@ParishName IS NULL OR @ParishName = '' OR [Parish].[ParishName] < LTRIM(RTRIM(@ParishName))) " 
                + "AND   (@KCSJDiocese IS NULL OR @KCSJDiocese = '' OR [Parish].[KCSJDiocese] < LTRIM(RTRIM(@KCSJDiocese))) " 
                + "";
        } else if  (sCondition == "Equal or more than...") {
            selectStatement
                = "SELECT "
            + "     [Parish].[Parish_ID] "
            + "    ,[Parish].[ParishName] "
            + "    ,[Parish].[KCSJDiocese] "
            + "FROM " 
            + "     [Parish] " 
                + "WHERE " 
                + "     (@Parish_ID IS NULL OR @Parish_ID = '' OR [Parish].[Parish_ID] >= LTRIM(RTRIM(@Parish_ID))) " 
                + "AND   (@ParishName IS NULL OR @ParishName = '' OR [Parish].[ParishName] >= LTRIM(RTRIM(@ParishName))) " 
                + "AND   (@KCSJDiocese IS NULL OR @KCSJDiocese = '' OR [Parish].[KCSJDiocese] >= LTRIM(RTRIM(@KCSJDiocese))) " 
                + "";
        } else if (sCondition == "Equal or less than...") {
            selectStatement 
                = "SELECT "
            + "     [Parish].[Parish_ID] "
            + "    ,[Parish].[ParishName] "
            + "    ,[Parish].[KCSJDiocese] "
            + "FROM " 
            + "     [Parish] " 
                + "WHERE " 
                + "     (@Parish_ID IS NULL OR @Parish_ID = '' OR [Parish].[Parish_ID] <= LTRIM(RTRIM(@Parish_ID))) " 
                + "AND   (@ParishName IS NULL OR @ParishName = '' OR [Parish].[ParishName] <= LTRIM(RTRIM(@ParishName))) " 
                + "AND   (@KCSJDiocese IS NULL OR @KCSJDiocese = '' OR [Parish].[KCSJDiocese] <= LTRIM(RTRIM(@KCSJDiocese))) " 
                + "";
        }
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        if (sField == "Parish I D") {
            selectCommand.Parameters.AddWithValue("@Parish_ID", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@Parish_ID", DBNull.Value); }
        if (sField == "Parish Name") {
            selectCommand.Parameters.AddWithValue("@ParishName", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@ParishName", DBNull.Value); }
        if (sField == "K C S J Diocese") {
            selectCommand.Parameters.AddWithValue("@KCSJDiocese", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@KCSJDiocese", DBNull.Value); }
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

    public static Parish Select_Record(Parish clsParishPara)
    {
        Parish clsParish = new Parish();
        SqlConnection connection = MarriageData.GetConnection();
        string selectStatement
            = "SELECT " 
            + "     [Parish_ID] "
            + "    ,[ParishName] "
            + "    ,[KCSJDiocese] "
            + "FROM "
            + "     [Parish] "
            + "WHERE "
            + "     [Parish_ID] = @Parish_ID "
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        selectCommand.Parameters.AddWithValue("@Parish_ID", clsParishPara.Parish_ID);
        try
        {
            connection.Open();
            SqlDataReader reader
                = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                clsParish.Parish_ID = System.Convert.ToInt16(reader["Parish_ID"]);
                clsParish.ParishName = System.Convert.ToString(reader["ParishName"]);
                clsParish.KCSJDiocese = System.Convert.ToBoolean(reader["KCSJDiocese"]);
            }
            else
            {
                clsParish = null;
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
        return clsParish;
    }

    public static bool Add(Parish clsParish)
    {
        SqlConnection connection = MarriageData.GetConnection();
        string insertStatement
            = "INSERT " 
            + "     [Parish] "
            + "     ( "
            + "     [ParishName] "
            + "    ,[KCSJDiocese] "
            + "     ) "
            + "VALUES " 
            + "     ( "
            + "     @ParishName "
            + "    ,@KCSJDiocese "
            + "     ) "
            + "";
        SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
        insertCommand.CommandType = CommandType.Text;
        insertCommand.Parameters.AddWithValue("@ParishName", clsParish.ParishName);
        insertCommand.Parameters.AddWithValue("@KCSJDiocese", clsParish.KCSJDiocese);
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

    public static bool Update(Parish oldParish, 
           Parish newParish)
    {
        SqlConnection connection = MarriageData.GetConnection();
        string updateStatement
            = "UPDATE "  
            + "     [Parish] "
            + "SET "
            + "     [ParishName] = @NewParishName "
            + "    ,[KCSJDiocese] = @NewKCSJDiocese "
            + "WHERE "
            + "     [Parish_ID] = @OldParish_ID " 
            + " AND [ParishName] = @OldParishName " 
            + " AND [KCSJDiocese] = @OldKCSJDiocese " 
            + "";
        SqlCommand updateCommand = new SqlCommand(updateStatement, connection);
        updateCommand.CommandType = CommandType.Text;
        updateCommand.Parameters.AddWithValue("@NewParishName", newParish.ParishName);
        updateCommand.Parameters.AddWithValue("@NewKCSJDiocese", newParish.KCSJDiocese);
        updateCommand.Parameters.AddWithValue("@OldParish_ID", oldParish.Parish_ID);
        updateCommand.Parameters.AddWithValue("@OldParishName", oldParish.ParishName);
        updateCommand.Parameters.AddWithValue("@OldKCSJDiocese", oldParish.KCSJDiocese);
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

    public static bool Delete(Parish clsParish)
    {
        SqlConnection connection = MarriageData.GetConnection();
        string deleteStatement
            = "DELETE FROM "  
            + "     [Parish] "
            + "WHERE " 
            + "     [Parish_ID] = @OldParish_ID " 
            + " AND [ParishName] = @OldParishName " 
            + " AND [KCSJDiocese] = @OldKCSJDiocese " 
            + "";
        SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection);
        deleteCommand.CommandType = CommandType.Text;
        deleteCommand.Parameters.AddWithValue("@OldParish_ID", clsParish.Parish_ID);
        deleteCommand.Parameters.AddWithValue("@OldParishName", clsParish.ParishName);
        deleteCommand.Parameters.AddWithValue("@OldKCSJDiocese", clsParish.KCSJDiocese);
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

 
