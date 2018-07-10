using System;
using System.Data;
using System.Data.SqlClient;

public class BrideData
{

    public static DataTable SelectAll()
    {
        SqlConnection connection = MarriageData.GetConnection();
        string selectStatement
            = "SELECT "  
            + "     [Bride I D] = [Bride].[Bride_ID] "
            + "    ,[Bride First Name] = [Bride].[Bride_First_Name] "
            + "    ,[Bride Middle Int] = [Bride].[Bride_Middle_Int] "
            + "    ,[Bride Last Name] = [Bride].[Bride_Last_Name] "
            + "FROM " 
            + "     [Bride] " 
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
            + "     [Bride].[Bride_ID] "
            + "    ,[Bride].[Bride_First_Name] "
            + "    ,[Bride].[Bride_Middle_Int] "
            + "    ,[Bride].[Bride_Last_Name] "
            + "FROM " 
            + "     [Bride] " 
                + "WHERE " 
                + "     (@Bride_ID IS NULL OR @Bride_ID = '' OR [Bride].[Bride_ID] LIKE '%' + LTRIM(RTRIM(@Bride_ID)) + '%') " 
                + "AND   (@Bride_First_Name IS NULL OR @Bride_First_Name = '' OR [Bride].[Bride_First_Name] LIKE '%' + LTRIM(RTRIM(@Bride_First_Name)) + '%') " 
                + "AND   (@Bride_Middle_Int IS NULL OR @Bride_Middle_Int = '' OR [Bride].[Bride_Middle_Int] LIKE '%' + LTRIM(RTRIM(@Bride_Middle_Int)) + '%') " 
                + "AND   (@Bride_Last_Name IS NULL OR @Bride_Last_Name = '' OR [Bride].[Bride_Last_Name] LIKE '%' + LTRIM(RTRIM(@Bride_Last_Name)) + '%') " 
                + "";
        } else if (sCondition == "Equals") {
            selectStatement
                = "SELECT "
            + "     [Bride].[Bride_ID] "
            + "    ,[Bride].[Bride_First_Name] "
            + "    ,[Bride].[Bride_Middle_Int] "
            + "    ,[Bride].[Bride_Last_Name] "
            + "FROM " 
            + "     [Bride] " 
                + "WHERE " 
                + "     (@Bride_ID IS NULL OR @Bride_ID = '' OR [Bride].[Bride_ID] = LTRIM(RTRIM(@Bride_ID))) " 
                + "AND   (@Bride_First_Name IS NULL OR @Bride_First_Name = '' OR [Bride].[Bride_First_Name] = LTRIM(RTRIM(@Bride_First_Name))) " 
                + "AND   (@Bride_Middle_Int IS NULL OR @Bride_Middle_Int = '' OR [Bride].[Bride_Middle_Int] = LTRIM(RTRIM(@Bride_Middle_Int))) " 
                + "AND   (@Bride_Last_Name IS NULL OR @Bride_Last_Name = '' OR [Bride].[Bride_Last_Name] = LTRIM(RTRIM(@Bride_Last_Name))) " 
                + "";
        } else if  (sCondition == "Starts with...") {
            selectStatement
                = "SELECT "
            + "     [Bride].[Bride_ID] "
            + "    ,[Bride].[Bride_First_Name] "
            + "    ,[Bride].[Bride_Middle_Int] "
            + "    ,[Bride].[Bride_Last_Name] "
            + "FROM " 
            + "     [Bride] " 
                + "WHERE " 
                + "     (@Bride_ID IS NULL OR @Bride_ID = '' OR [Bride].[Bride_ID] LIKE LTRIM(RTRIM(@Bride_ID)) + '%') " 
                + "AND   (@Bride_First_Name IS NULL OR @Bride_First_Name = '' OR [Bride].[Bride_First_Name] LIKE LTRIM(RTRIM(@Bride_First_Name)) + '%') " 
                + "AND   (@Bride_Middle_Int IS NULL OR @Bride_Middle_Int = '' OR [Bride].[Bride_Middle_Int] LIKE LTRIM(RTRIM(@Bride_Middle_Int)) + '%') " 
                + "AND   (@Bride_Last_Name IS NULL OR @Bride_Last_Name = '' OR [Bride].[Bride_Last_Name] LIKE LTRIM(RTRIM(@Bride_Last_Name)) + '%') " 
                + "";
        } else if  (sCondition == "More than...") {
            selectStatement
                = "SELECT "
            + "     [Bride].[Bride_ID] "
            + "    ,[Bride].[Bride_First_Name] "
            + "    ,[Bride].[Bride_Middle_Int] "
            + "    ,[Bride].[Bride_Last_Name] "
            + "FROM " 
            + "     [Bride] " 
                + "WHERE " 
                + "     (@Bride_ID IS NULL OR @Bride_ID = '' OR [Bride].[Bride_ID] > LTRIM(RTRIM(@Bride_ID))) " 
                + "AND   (@Bride_First_Name IS NULL OR @Bride_First_Name = '' OR [Bride].[Bride_First_Name] > LTRIM(RTRIM(@Bride_First_Name))) " 
                + "AND   (@Bride_Middle_Int IS NULL OR @Bride_Middle_Int = '' OR [Bride].[Bride_Middle_Int] > LTRIM(RTRIM(@Bride_Middle_Int))) " 
                + "AND   (@Bride_Last_Name IS NULL OR @Bride_Last_Name = '' OR [Bride].[Bride_Last_Name] > LTRIM(RTRIM(@Bride_Last_Name))) " 
                + "";
        } else if  (sCondition == "Less than...") {
            selectStatement
                = "SELECT " 
            + "     [Bride].[Bride_ID] "
            + "    ,[Bride].[Bride_First_Name] "
            + "    ,[Bride].[Bride_Middle_Int] "
            + "    ,[Bride].[Bride_Last_Name] "
            + "FROM " 
            + "     [Bride] " 
                + "WHERE " 
                + "     (@Bride_ID IS NULL OR @Bride_ID = '' OR [Bride].[Bride_ID] < LTRIM(RTRIM(@Bride_ID))) " 
                + "AND   (@Bride_First_Name IS NULL OR @Bride_First_Name = '' OR [Bride].[Bride_First_Name] < LTRIM(RTRIM(@Bride_First_Name))) " 
                + "AND   (@Bride_Middle_Int IS NULL OR @Bride_Middle_Int = '' OR [Bride].[Bride_Middle_Int] < LTRIM(RTRIM(@Bride_Middle_Int))) " 
                + "AND   (@Bride_Last_Name IS NULL OR @Bride_Last_Name = '' OR [Bride].[Bride_Last_Name] < LTRIM(RTRIM(@Bride_Last_Name))) " 
                + "";
        } else if  (sCondition == "Equal or more than...") {
            selectStatement
                = "SELECT "
            + "     [Bride].[Bride_ID] "
            + "    ,[Bride].[Bride_First_Name] "
            + "    ,[Bride].[Bride_Middle_Int] "
            + "    ,[Bride].[Bride_Last_Name] "
            + "FROM " 
            + "     [Bride] " 
                + "WHERE " 
                + "     (@Bride_ID IS NULL OR @Bride_ID = '' OR [Bride].[Bride_ID] >= LTRIM(RTRIM(@Bride_ID))) " 
                + "AND   (@Bride_First_Name IS NULL OR @Bride_First_Name = '' OR [Bride].[Bride_First_Name] >= LTRIM(RTRIM(@Bride_First_Name))) " 
                + "AND   (@Bride_Middle_Int IS NULL OR @Bride_Middle_Int = '' OR [Bride].[Bride_Middle_Int] >= LTRIM(RTRIM(@Bride_Middle_Int))) " 
                + "AND   (@Bride_Last_Name IS NULL OR @Bride_Last_Name = '' OR [Bride].[Bride_Last_Name] >= LTRIM(RTRIM(@Bride_Last_Name))) " 
                + "";
        } else if (sCondition == "Equal or less than...") {
            selectStatement 
                = "SELECT "
            + "     [Bride].[Bride_ID] "
            + "    ,[Bride].[Bride_First_Name] "
            + "    ,[Bride].[Bride_Middle_Int] "
            + "    ,[Bride].[Bride_Last_Name] "
            + "FROM " 
            + "     [Bride] " 
                + "WHERE " 
                + "     (@Bride_ID IS NULL OR @Bride_ID = '' OR [Bride].[Bride_ID] <= LTRIM(RTRIM(@Bride_ID))) " 
                + "AND   (@Bride_First_Name IS NULL OR @Bride_First_Name = '' OR [Bride].[Bride_First_Name] <= LTRIM(RTRIM(@Bride_First_Name))) " 
                + "AND   (@Bride_Middle_Int IS NULL OR @Bride_Middle_Int = '' OR [Bride].[Bride_Middle_Int] <= LTRIM(RTRIM(@Bride_Middle_Int))) " 
                + "AND   (@Bride_Last_Name IS NULL OR @Bride_Last_Name = '' OR [Bride].[Bride_Last_Name] <= LTRIM(RTRIM(@Bride_Last_Name))) " 
                + "";
        }
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        if (sField == "Bride I D") {
            selectCommand.Parameters.AddWithValue("@Bride_ID", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@Bride_ID", DBNull.Value); }
        if (sField == "Bride First Name") {
            selectCommand.Parameters.AddWithValue("@Bride_First_Name", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@Bride_First_Name", DBNull.Value); }
        if (sField == "Bride Middle Int") {
            selectCommand.Parameters.AddWithValue("@Bride_Middle_Int", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@Bride_Middle_Int", DBNull.Value); }
        if (sField == "Bride Last Name") {
            selectCommand.Parameters.AddWithValue("@Bride_Last_Name", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@Bride_Last_Name", DBNull.Value); }
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

    public static Bride Select_Record(Bride clsBridePara)
    {
        Bride clsBride = new Bride();
        SqlConnection connection = MarriageData.GetConnection();
        string selectStatement
            = "SELECT " 
            + "     [Bride_ID] "
            + "    ,[Bride_First_Name] "
            + "    ,[Bride_Middle_Int] "
            + "    ,[Bride_Last_Name] "
            + "FROM "
            + "     [Bride] "
            + "WHERE "
            + "     [Bride_ID] = @Bride_ID "
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        selectCommand.Parameters.AddWithValue("@Bride_ID", clsBridePara.Bride_ID);
        try
        {
            connection.Open();
            SqlDataReader reader
                = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                clsBride.Bride_ID = System.Convert.ToInt32(reader["Bride_ID"]);
                clsBride.Bride_First_Name = System.Convert.ToString(reader["Bride_First_Name"]);
                clsBride.Bride_Middle_Int = System.Convert.ToString(reader["Bride_Middle_Int"]);
                clsBride.Bride_Last_Name = System.Convert.ToString(reader["Bride_Last_Name"]);
            }
            else
            {
                clsBride = null;
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
        return clsBride;
    }

    public static bool Add(Bride clsBride)
    {
        SqlConnection connection = MarriageData.GetConnection();
        string insertStatement
            = "INSERT " 
            + "     [Bride] "
            + "     ( "
            + "     [Bride_First_Name] "
            + "    ,[Bride_Middle_Int] "
            + "    ,[Bride_Last_Name] "
            + "     ) "
            + "VALUES " 
            + "     ( "
            + "     @Bride_First_Name "
            + "    ,@Bride_Middle_Int "
            + "    ,@Bride_Last_Name "
            + "     ) "
            + "";
        SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
        insertCommand.CommandType = CommandType.Text;
        insertCommand.Parameters.AddWithValue("@Bride_First_Name", clsBride.Bride_First_Name);
        insertCommand.Parameters.AddWithValue("@Bride_Middle_Int", clsBride.Bride_Middle_Int);
        insertCommand.Parameters.AddWithValue("@Bride_Last_Name", clsBride.Bride_Last_Name);
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

    public static bool Update(Bride oldBride, 
           Bride newBride)
    {
        SqlConnection connection = MarriageData.GetConnection();
        string updateStatement
            = "UPDATE "  
            + "     [Bride] "
            + "SET "
            + "     [Bride_First_Name] = @NewBride_First_Name "
            + "    ,[Bride_Middle_Int] = @NewBride_Middle_Int "
            + "    ,[Bride_Last_Name] = @NewBride_Last_Name "
            + "WHERE "
            + "     [Bride_ID] = @OldBride_ID " 
            + " AND [Bride_First_Name] = @OldBride_First_Name " 
            + " AND [Bride_Middle_Int] = @OldBride_Middle_Int " 
            + " AND [Bride_Last_Name] = @OldBride_Last_Name " 
            + "";
        SqlCommand updateCommand = new SqlCommand(updateStatement, connection);
        updateCommand.CommandType = CommandType.Text;
        updateCommand.Parameters.AddWithValue("@NewBride_First_Name", newBride.Bride_First_Name);
        updateCommand.Parameters.AddWithValue("@NewBride_Middle_Int", newBride.Bride_Middle_Int);
        updateCommand.Parameters.AddWithValue("@NewBride_Last_Name", newBride.Bride_Last_Name);
        updateCommand.Parameters.AddWithValue("@OldBride_ID", oldBride.Bride_ID);
        updateCommand.Parameters.AddWithValue("@OldBride_First_Name", oldBride.Bride_First_Name);
        updateCommand.Parameters.AddWithValue("@OldBride_Middle_Int", oldBride.Bride_Middle_Int);
        updateCommand.Parameters.AddWithValue("@OldBride_Last_Name", oldBride.Bride_Last_Name);
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

    public static bool Delete(Bride clsBride)
    {
        SqlConnection connection = MarriageData.GetConnection();
        string deleteStatement
            = "DELETE FROM "  
            + "     [Bride] "
            + "WHERE " 
            + "     [Bride_ID] = @OldBride_ID " 
            + " AND [Bride_First_Name] = @OldBride_First_Name " 
            + " AND [Bride_Middle_Int] = @OldBride_Middle_Int " 
            + " AND [Bride_Last_Name] = @OldBride_Last_Name " 
            + "";
        SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection);
        deleteCommand.CommandType = CommandType.Text;
        deleteCommand.Parameters.AddWithValue("@OldBride_ID", clsBride.Bride_ID);
        deleteCommand.Parameters.AddWithValue("@OldBride_First_Name", clsBride.Bride_First_Name);
        deleteCommand.Parameters.AddWithValue("@OldBride_Middle_Int", clsBride.Bride_Middle_Int);
        deleteCommand.Parameters.AddWithValue("@OldBride_Last_Name", clsBride.Bride_Last_Name);
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

 
