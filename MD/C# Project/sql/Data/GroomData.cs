using System;
using System.Data;
using System.Data.SqlClient;

public class GroomData
{

    public static DataTable SelectAll()
    {
        SqlConnection connection = MarriageData.GetConnection();
        string selectStatement
            = "SELECT "  
            + "     [Groom I D] = [Groom].[Groom_ID] "
            + "    ,[Groom First Name] = [Groom].[Groom_First_Name] "
            + "    ,[Groom Middle Int] = [Groom].[Groom_Middle_Int] "
            + "    ,[Groom Last Name] = [Groom].[Groom_Last_Name] "
            + "FROM " 
            + "     [Groom] " 
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
            + "     [Groom].[Groom_ID] "
            + "    ,[Groom].[Groom_First_Name] "
            + "    ,[Groom].[Groom_Middle_Int] "
            + "    ,[Groom].[Groom_Last_Name] "
            + "FROM " 
            + "     [Groom] " 
                + "WHERE " 
                + "     (@Groom_ID IS NULL OR @Groom_ID = '' OR [Groom].[Groom_ID] LIKE '%' + LTRIM(RTRIM(@Groom_ID)) + '%') " 
                + "AND   (@Groom_First_Name IS NULL OR @Groom_First_Name = '' OR [Groom].[Groom_First_Name] LIKE '%' + LTRIM(RTRIM(@Groom_First_Name)) + '%') " 
                + "AND   (@Groom_Middle_Int IS NULL OR @Groom_Middle_Int = '' OR [Groom].[Groom_Middle_Int] LIKE '%' + LTRIM(RTRIM(@Groom_Middle_Int)) + '%') " 
                + "AND   (@Groom_Last_Name IS NULL OR @Groom_Last_Name = '' OR [Groom].[Groom_Last_Name] LIKE '%' + LTRIM(RTRIM(@Groom_Last_Name)) + '%') " 
                + "";
        } else if (sCondition == "Equals") {
            selectStatement
                = "SELECT "
            + "     [Groom].[Groom_ID] "
            + "    ,[Groom].[Groom_First_Name] "
            + "    ,[Groom].[Groom_Middle_Int] "
            + "    ,[Groom].[Groom_Last_Name] "
            + "FROM " 
            + "     [Groom] " 
                + "WHERE " 
                + "     (@Groom_ID IS NULL OR @Groom_ID = '' OR [Groom].[Groom_ID] = LTRIM(RTRIM(@Groom_ID))) " 
                + "AND   (@Groom_First_Name IS NULL OR @Groom_First_Name = '' OR [Groom].[Groom_First_Name] = LTRIM(RTRIM(@Groom_First_Name))) " 
                + "AND   (@Groom_Middle_Int IS NULL OR @Groom_Middle_Int = '' OR [Groom].[Groom_Middle_Int] = LTRIM(RTRIM(@Groom_Middle_Int))) " 
                + "AND   (@Groom_Last_Name IS NULL OR @Groom_Last_Name = '' OR [Groom].[Groom_Last_Name] = LTRIM(RTRIM(@Groom_Last_Name))) " 
                + "";
        } else if  (sCondition == "Starts with...") {
            selectStatement
                = "SELECT "
            + "     [Groom].[Groom_ID] "
            + "    ,[Groom].[Groom_First_Name] "
            + "    ,[Groom].[Groom_Middle_Int] "
            + "    ,[Groom].[Groom_Last_Name] "
            + "FROM " 
            + "     [Groom] " 
                + "WHERE " 
                + "     (@Groom_ID IS NULL OR @Groom_ID = '' OR [Groom].[Groom_ID] LIKE LTRIM(RTRIM(@Groom_ID)) + '%') " 
                + "AND   (@Groom_First_Name IS NULL OR @Groom_First_Name = '' OR [Groom].[Groom_First_Name] LIKE LTRIM(RTRIM(@Groom_First_Name)) + '%') " 
                + "AND   (@Groom_Middle_Int IS NULL OR @Groom_Middle_Int = '' OR [Groom].[Groom_Middle_Int] LIKE LTRIM(RTRIM(@Groom_Middle_Int)) + '%') " 
                + "AND   (@Groom_Last_Name IS NULL OR @Groom_Last_Name = '' OR [Groom].[Groom_Last_Name] LIKE LTRIM(RTRIM(@Groom_Last_Name)) + '%') " 
                + "";
        } else if  (sCondition == "More than...") {
            selectStatement
                = "SELECT "
            + "     [Groom].[Groom_ID] "
            + "    ,[Groom].[Groom_First_Name] "
            + "    ,[Groom].[Groom_Middle_Int] "
            + "    ,[Groom].[Groom_Last_Name] "
            + "FROM " 
            + "     [Groom] " 
                + "WHERE " 
                + "     (@Groom_ID IS NULL OR @Groom_ID = '' OR [Groom].[Groom_ID] > LTRIM(RTRIM(@Groom_ID))) " 
                + "AND   (@Groom_First_Name IS NULL OR @Groom_First_Name = '' OR [Groom].[Groom_First_Name] > LTRIM(RTRIM(@Groom_First_Name))) " 
                + "AND   (@Groom_Middle_Int IS NULL OR @Groom_Middle_Int = '' OR [Groom].[Groom_Middle_Int] > LTRIM(RTRIM(@Groom_Middle_Int))) " 
                + "AND   (@Groom_Last_Name IS NULL OR @Groom_Last_Name = '' OR [Groom].[Groom_Last_Name] > LTRIM(RTRIM(@Groom_Last_Name))) " 
                + "";
        } else if  (sCondition == "Less than...") {
            selectStatement
                = "SELECT " 
            + "     [Groom].[Groom_ID] "
            + "    ,[Groom].[Groom_First_Name] "
            + "    ,[Groom].[Groom_Middle_Int] "
            + "    ,[Groom].[Groom_Last_Name] "
            + "FROM " 
            + "     [Groom] " 
                + "WHERE " 
                + "     (@Groom_ID IS NULL OR @Groom_ID = '' OR [Groom].[Groom_ID] < LTRIM(RTRIM(@Groom_ID))) " 
                + "AND   (@Groom_First_Name IS NULL OR @Groom_First_Name = '' OR [Groom].[Groom_First_Name] < LTRIM(RTRIM(@Groom_First_Name))) " 
                + "AND   (@Groom_Middle_Int IS NULL OR @Groom_Middle_Int = '' OR [Groom].[Groom_Middle_Int] < LTRIM(RTRIM(@Groom_Middle_Int))) " 
                + "AND   (@Groom_Last_Name IS NULL OR @Groom_Last_Name = '' OR [Groom].[Groom_Last_Name] < LTRIM(RTRIM(@Groom_Last_Name))) " 
                + "";
        } else if  (sCondition == "Equal or more than...") {
            selectStatement
                = "SELECT "
            + "     [Groom].[Groom_ID] "
            + "    ,[Groom].[Groom_First_Name] "
            + "    ,[Groom].[Groom_Middle_Int] "
            + "    ,[Groom].[Groom_Last_Name] "
            + "FROM " 
            + "     [Groom] " 
                + "WHERE " 
                + "     (@Groom_ID IS NULL OR @Groom_ID = '' OR [Groom].[Groom_ID] >= LTRIM(RTRIM(@Groom_ID))) " 
                + "AND   (@Groom_First_Name IS NULL OR @Groom_First_Name = '' OR [Groom].[Groom_First_Name] >= LTRIM(RTRIM(@Groom_First_Name))) " 
                + "AND   (@Groom_Middle_Int IS NULL OR @Groom_Middle_Int = '' OR [Groom].[Groom_Middle_Int] >= LTRIM(RTRIM(@Groom_Middle_Int))) " 
                + "AND   (@Groom_Last_Name IS NULL OR @Groom_Last_Name = '' OR [Groom].[Groom_Last_Name] >= LTRIM(RTRIM(@Groom_Last_Name))) " 
                + "";
        } else if (sCondition == "Equal or less than...") {
            selectStatement 
                = "SELECT "
            + "     [Groom].[Groom_ID] "
            + "    ,[Groom].[Groom_First_Name] "
            + "    ,[Groom].[Groom_Middle_Int] "
            + "    ,[Groom].[Groom_Last_Name] "
            + "FROM " 
            + "     [Groom] " 
                + "WHERE " 
                + "     (@Groom_ID IS NULL OR @Groom_ID = '' OR [Groom].[Groom_ID] <= LTRIM(RTRIM(@Groom_ID))) " 
                + "AND   (@Groom_First_Name IS NULL OR @Groom_First_Name = '' OR [Groom].[Groom_First_Name] <= LTRIM(RTRIM(@Groom_First_Name))) " 
                + "AND   (@Groom_Middle_Int IS NULL OR @Groom_Middle_Int = '' OR [Groom].[Groom_Middle_Int] <= LTRIM(RTRIM(@Groom_Middle_Int))) " 
                + "AND   (@Groom_Last_Name IS NULL OR @Groom_Last_Name = '' OR [Groom].[Groom_Last_Name] <= LTRIM(RTRIM(@Groom_Last_Name))) " 
                + "";
        }
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        if (sField == "Groom I D") {
            selectCommand.Parameters.AddWithValue("@Groom_ID", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@Groom_ID", DBNull.Value); }
        if (sField == "Groom First Name") {
            selectCommand.Parameters.AddWithValue("@Groom_First_Name", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@Groom_First_Name", DBNull.Value); }
        if (sField == "Groom Middle Int") {
            selectCommand.Parameters.AddWithValue("@Groom_Middle_Int", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@Groom_Middle_Int", DBNull.Value); }
        if (sField == "Groom Last Name") {
            selectCommand.Parameters.AddWithValue("@Groom_Last_Name", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@Groom_Last_Name", DBNull.Value); }
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

    public static Groom Select_Record(Groom clsGroomPara)
    {
        Groom clsGroom = new Groom();
        SqlConnection connection = MarriageData.GetConnection();
        string selectStatement
            = "SELECT " 
            + "     [Groom_ID] "
            + "    ,[Groom_First_Name] "
            + "    ,[Groom_Middle_Int] "
            + "    ,[Groom_Last_Name] "
            + "FROM "
            + "     [Groom] "
            + "WHERE "
            + "     [Groom_ID] = @Groom_ID "
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        selectCommand.Parameters.AddWithValue("@Groom_ID", clsGroomPara.Groom_ID);
        try
        {
            connection.Open();
            SqlDataReader reader
                = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                clsGroom.Groom_ID = System.Convert.ToInt32(reader["Groom_ID"]);
                clsGroom.Groom_First_Name = System.Convert.ToString(reader["Groom_First_Name"]);
                clsGroom.Groom_Middle_Int = System.Convert.ToString(reader["Groom_Middle_Int"]);
                clsGroom.Groom_Last_Name = System.Convert.ToString(reader["Groom_Last_Name"]);
            }
            else
            {
                clsGroom = null;
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
        return clsGroom;
    }

    public static bool Add(Groom clsGroom)
    {
        SqlConnection connection = MarriageData.GetConnection();
        string insertStatement
            = "INSERT " 
            + "     [Groom] "
            + "     ( "
            + "     [Groom_First_Name] "
            + "    ,[Groom_Middle_Int] "
            + "    ,[Groom_Last_Name] "
            + "     ) "
            + "VALUES " 
            + "     ( "
            + "     @Groom_First_Name "
            + "    ,@Groom_Middle_Int "
            + "    ,@Groom_Last_Name "
            + "     ) "
            + "";
        SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
        insertCommand.CommandType = CommandType.Text;
        insertCommand.Parameters.AddWithValue("@Groom_First_Name", clsGroom.Groom_First_Name);
        insertCommand.Parameters.AddWithValue("@Groom_Middle_Int", clsGroom.Groom_Middle_Int);
        insertCommand.Parameters.AddWithValue("@Groom_Last_Name", clsGroom.Groom_Last_Name);
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

    public static bool Update(Groom oldGroom, 
           Groom newGroom)
    {
        SqlConnection connection = MarriageData.GetConnection();
        string updateStatement
            = "UPDATE "  
            + "     [Groom] "
            + "SET "
            + "     [Groom_First_Name] = @NewGroom_First_Name "
            + "    ,[Groom_Middle_Int] = @NewGroom_Middle_Int "
            + "    ,[Groom_Last_Name] = @NewGroom_Last_Name "
            + "WHERE "
            + "     [Groom_ID] = @OldGroom_ID " 
            + " AND [Groom_First_Name] = @OldGroom_First_Name " 
            + " AND [Groom_Middle_Int] = @OldGroom_Middle_Int " 
            + " AND [Groom_Last_Name] = @OldGroom_Last_Name " 
            + "";
        SqlCommand updateCommand = new SqlCommand(updateStatement, connection);
        updateCommand.CommandType = CommandType.Text;
        updateCommand.Parameters.AddWithValue("@NewGroom_First_Name", newGroom.Groom_First_Name);
        updateCommand.Parameters.AddWithValue("@NewGroom_Middle_Int", newGroom.Groom_Middle_Int);
        updateCommand.Parameters.AddWithValue("@NewGroom_Last_Name", newGroom.Groom_Last_Name);
        updateCommand.Parameters.AddWithValue("@OldGroom_ID", oldGroom.Groom_ID);
        updateCommand.Parameters.AddWithValue("@OldGroom_First_Name", oldGroom.Groom_First_Name);
        updateCommand.Parameters.AddWithValue("@OldGroom_Middle_Int", oldGroom.Groom_Middle_Int);
        updateCommand.Parameters.AddWithValue("@OldGroom_Last_Name", oldGroom.Groom_Last_Name);
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

    public static bool Delete(Groom clsGroom)
    {
        SqlConnection connection = MarriageData.GetConnection();
        string deleteStatement
            = "DELETE FROM "  
            + "     [Groom] "
            + "WHERE " 
            + "     [Groom_ID] = @OldGroom_ID " 
            + " AND [Groom_First_Name] = @OldGroom_First_Name " 
            + " AND [Groom_Middle_Int] = @OldGroom_Middle_Int " 
            + " AND [Groom_Last_Name] = @OldGroom_Last_Name " 
            + "";
        SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection);
        deleteCommand.CommandType = CommandType.Text;
        deleteCommand.Parameters.AddWithValue("@OldGroom_ID", clsGroom.Groom_ID);
        deleteCommand.Parameters.AddWithValue("@OldGroom_First_Name", clsGroom.Groom_First_Name);
        deleteCommand.Parameters.AddWithValue("@OldGroom_Middle_Int", clsGroom.Groom_Middle_Int);
        deleteCommand.Parameters.AddWithValue("@OldGroom_Last_Name", clsGroom.Groom_Last_Name);
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

 
