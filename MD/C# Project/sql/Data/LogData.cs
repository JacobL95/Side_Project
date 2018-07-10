using System;
using System.Data;
using System.Data.SqlClient;

public class LogData
{

    public static DataTable SelectAll()
    {
        SqlConnection connection = MarriageData.GetConnection();
        string selectStatement
            = "SELECT "  
            + "     [Log I D] = [Log].[Log_ID] "
            + "    ,[User Name] = [Log].[User_Name] "
            + "    ,[Note] = [Log].[Note] "
            + "FROM " 
            + "     [Log] " 
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
            + "     [Log].[Log_ID] "
            + "    ,[Log].[User_Name] "
            + "    ,[Log].[Note] "
            + "FROM " 
            + "     [Log] " 
                + "WHERE " 
                + "     (@Log_ID IS NULL OR @Log_ID = '' OR [Log].[Log_ID] LIKE '%' + LTRIM(RTRIM(@Log_ID)) + '%') " 
                + "AND   (@User_Name IS NULL OR @User_Name = '' OR [Log].[User_Name] LIKE '%' + LTRIM(RTRIM(@User_Name)) + '%') " 
                + "AND   (@Note IS NULL OR @Note = '' OR [Log].[Note] LIKE '%' + LTRIM(RTRIM(@Note)) + '%') " 
                + "";
        } else if (sCondition == "Equals") {
            selectStatement
                = "SELECT "
            + "     [Log].[Log_ID] "
            + "    ,[Log].[User_Name] "
            + "    ,[Log].[Note] "
            + "FROM " 
            + "     [Log] " 
                + "WHERE " 
                + "     (@Log_ID IS NULL OR @Log_ID = '' OR [Log].[Log_ID] = LTRIM(RTRIM(@Log_ID))) " 
                + "AND   (@User_Name IS NULL OR @User_Name = '' OR [Log].[User_Name] = LTRIM(RTRIM(@User_Name))) " 
                + "AND   (@Note IS NULL OR @Note = '' OR [Log].[Note] = LTRIM(RTRIM(@Note))) " 
                + "";
        } else if  (sCondition == "Starts with...") {
            selectStatement
                = "SELECT "
            + "     [Log].[Log_ID] "
            + "    ,[Log].[User_Name] "
            + "    ,[Log].[Note] "
            + "FROM " 
            + "     [Log] " 
                + "WHERE " 
                + "     (@Log_ID IS NULL OR @Log_ID = '' OR [Log].[Log_ID] LIKE LTRIM(RTRIM(@Log_ID)) + '%') " 
                + "AND   (@User_Name IS NULL OR @User_Name = '' OR [Log].[User_Name] LIKE LTRIM(RTRIM(@User_Name)) + '%') " 
                + "AND   (@Note IS NULL OR @Note = '' OR [Log].[Note] LIKE LTRIM(RTRIM(@Note)) + '%') " 
                + "";
        } else if  (sCondition == "More than...") {
            selectStatement
                = "SELECT "
            + "     [Log].[Log_ID] "
            + "    ,[Log].[User_Name] "
            + "    ,[Log].[Note] "
            + "FROM " 
            + "     [Log] " 
                + "WHERE " 
                + "     (@Log_ID IS NULL OR @Log_ID = '' OR [Log].[Log_ID] > LTRIM(RTRIM(@Log_ID))) " 
                + "AND   (@User_Name IS NULL OR @User_Name = '' OR [Log].[User_Name] > LTRIM(RTRIM(@User_Name))) " 
                + "AND   (@Note IS NULL OR @Note = '' OR [Log].[Note] > LTRIM(RTRIM(@Note))) " 
                + "";
        } else if  (sCondition == "Less than...") {
            selectStatement
                = "SELECT " 
            + "     [Log].[Log_ID] "
            + "    ,[Log].[User_Name] "
            + "    ,[Log].[Note] "
            + "FROM " 
            + "     [Log] " 
                + "WHERE " 
                + "     (@Log_ID IS NULL OR @Log_ID = '' OR [Log].[Log_ID] < LTRIM(RTRIM(@Log_ID))) " 
                + "AND   (@User_Name IS NULL OR @User_Name = '' OR [Log].[User_Name] < LTRIM(RTRIM(@User_Name))) " 
                + "AND   (@Note IS NULL OR @Note = '' OR [Log].[Note] < LTRIM(RTRIM(@Note))) " 
                + "";
        } else if  (sCondition == "Equal or more than...") {
            selectStatement
                = "SELECT "
            + "     [Log].[Log_ID] "
            + "    ,[Log].[User_Name] "
            + "    ,[Log].[Note] "
            + "FROM " 
            + "     [Log] " 
                + "WHERE " 
                + "     (@Log_ID IS NULL OR @Log_ID = '' OR [Log].[Log_ID] >= LTRIM(RTRIM(@Log_ID))) " 
                + "AND   (@User_Name IS NULL OR @User_Name = '' OR [Log].[User_Name] >= LTRIM(RTRIM(@User_Name))) " 
                + "AND   (@Note IS NULL OR @Note = '' OR [Log].[Note] >= LTRIM(RTRIM(@Note))) " 
                + "";
        } else if (sCondition == "Equal or less than...") {
            selectStatement 
                = "SELECT "
            + "     [Log].[Log_ID] "
            + "    ,[Log].[User_Name] "
            + "    ,[Log].[Note] "
            + "FROM " 
            + "     [Log] " 
                + "WHERE " 
                + "     (@Log_ID IS NULL OR @Log_ID = '' OR [Log].[Log_ID] <= LTRIM(RTRIM(@Log_ID))) " 
                + "AND   (@User_Name IS NULL OR @User_Name = '' OR [Log].[User_Name] <= LTRIM(RTRIM(@User_Name))) " 
                + "AND   (@Note IS NULL OR @Note = '' OR [Log].[Note] <= LTRIM(RTRIM(@Note))) " 
                + "";
        }
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        if (sField == "Log I D") {
            selectCommand.Parameters.AddWithValue("@Log_ID", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@Log_ID", DBNull.Value); }
        if (sField == "User Name") {
            selectCommand.Parameters.AddWithValue("@User_Name", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@User_Name", DBNull.Value); }
        if (sField == "Note") {
            selectCommand.Parameters.AddWithValue("@Note", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@Note", DBNull.Value); }
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

    public static Log Select_Record(Log clsLogPara)
    {
        Log clsLog = new Log();
        SqlConnection connection = MarriageData.GetConnection();
        string selectStatement
            = "SELECT " 
            + "     [Log_ID] "
            + "    ,[User_Name] "
            + "    ,[Note] "
            + "FROM "
            + "     [Log] "
            + "WHERE "
            + "     [Log_ID] = @Log_ID "
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        selectCommand.Parameters.AddWithValue("@Log_ID", clsLogPara.Log_ID);
        try
        {
            connection.Open();
            SqlDataReader reader
                = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                clsLog.Log_ID = System.Convert.ToInt32(reader["Log_ID"]);
                clsLog.User_Name = System.Convert.ToString(reader["User_Name"]);
                clsLog.Note = System.Convert.ToString(reader["Note"]);
            }
            else
            {
                clsLog = null;
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
        return clsLog;
    }

    public static bool Add(Log clsLog)
    {
        SqlConnection connection = MarriageData.GetConnection();
        string insertStatement
            = "INSERT " 
            + "     [Log] "
            + "     ( "
            + "     [User_Name] "
            + "    ,[Note] "
            + "     ) "
            + "VALUES " 
            + "     ( "
            + "     @User_Name "
            + "    ,@Note "
            + "     ) "
            + "";
        SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
        insertCommand.CommandType = CommandType.Text;
        insertCommand.Parameters.AddWithValue("@User_Name", clsLog.User_Name);
        insertCommand.Parameters.AddWithValue("@Note", clsLog.Note);
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

    public static bool Update(Log oldLog, 
           Log newLog)
    {
        SqlConnection connection = MarriageData.GetConnection();
        string updateStatement
            = "UPDATE "  
            + "     [Log] "
            + "SET "
            + "     [User_Name] = @NewUser_Name "
            + "    ,[Note] = @NewNote "
            + "WHERE "
            + "     [Log_ID] = @OldLog_ID " 
            + " AND [User_Name] = @OldUser_Name " 
            + " AND [Note] = @OldNote " 
            + "";
        SqlCommand updateCommand = new SqlCommand(updateStatement, connection);
        updateCommand.CommandType = CommandType.Text;
        updateCommand.Parameters.AddWithValue("@NewUser_Name", newLog.User_Name);
        updateCommand.Parameters.AddWithValue("@NewNote", newLog.Note);
        updateCommand.Parameters.AddWithValue("@OldLog_ID", oldLog.Log_ID);
        updateCommand.Parameters.AddWithValue("@OldUser_Name", oldLog.User_Name);
        updateCommand.Parameters.AddWithValue("@OldNote", oldLog.Note);
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

    public static bool Delete(Log clsLog)
    {
        SqlConnection connection = MarriageData.GetConnection();
        string deleteStatement
            = "DELETE FROM "  
            + "     [Log] "
            + "WHERE " 
            + "     [Log_ID] = @OldLog_ID " 
            + " AND [User_Name] = @OldUser_Name " 
            + " AND [Note] = @OldNote " 
            + "";
        SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection);
        deleteCommand.CommandType = CommandType.Text;
        deleteCommand.Parameters.AddWithValue("@OldLog_ID", clsLog.Log_ID);
        deleteCommand.Parameters.AddWithValue("@OldUser_Name", clsLog.User_Name);
        deleteCommand.Parameters.AddWithValue("@OldNote", clsLog.Note);
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

 
