using System;
using System.Data;
using System.Data.SqlClient;

public class LoginData
{

    public static DataTable SelectAll()
    {
        SqlConnection connection = MarriageData.GetConnection();
        string selectStatement
            = "SELECT "  
            + "     [User Name] = [Login].[User_Name] "
            + "    ,[Password] = [Login].[Password] "
            + "FROM " 
            + "     [Login] " 
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
            + "     [Login].[User_Name] "
            + "    ,[Login].[Password] "
            + "FROM " 
            + "     [Login] " 
                + "WHERE " 
                + "     (@User_Name IS NULL OR @User_Name = '' OR [Login].[User_Name] LIKE '%' + LTRIM(RTRIM(@User_Name)) + '%') " 
                + "AND   (@Password IS NULL OR @Password = '' OR [Login].[Password] LIKE '%' + LTRIM(RTRIM(@Password)) + '%') " 
                + "";
        } else if (sCondition == "Equals") {
            selectStatement
                = "SELECT "
            + "     [Login].[User_Name] "
            + "    ,[Login].[Password] "
            + "FROM " 
            + "     [Login] " 
                + "WHERE " 
                + "     (@User_Name IS NULL OR @User_Name = '' OR [Login].[User_Name] = LTRIM(RTRIM(@User_Name))) " 
                + "AND   (@Password IS NULL OR @Password = '' OR [Login].[Password] = LTRIM(RTRIM(@Password))) " 
                + "";
        } else if  (sCondition == "Starts with...") {
            selectStatement
                = "SELECT "
            + "     [Login].[User_Name] "
            + "    ,[Login].[Password] "
            + "FROM " 
            + "     [Login] " 
                + "WHERE " 
                + "     (@User_Name IS NULL OR @User_Name = '' OR [Login].[User_Name] LIKE LTRIM(RTRIM(@User_Name)) + '%') " 
                + "AND   (@Password IS NULL OR @Password = '' OR [Login].[Password] LIKE LTRIM(RTRIM(@Password)) + '%') " 
                + "";
        } else if  (sCondition == "More than...") {
            selectStatement
                = "SELECT "
            + "     [Login].[User_Name] "
            + "    ,[Login].[Password] "
            + "FROM " 
            + "     [Login] " 
                + "WHERE " 
                + "     (@User_Name IS NULL OR @User_Name = '' OR [Login].[User_Name] > LTRIM(RTRIM(@User_Name))) " 
                + "AND   (@Password IS NULL OR @Password = '' OR [Login].[Password] > LTRIM(RTRIM(@Password))) " 
                + "";
        } else if  (sCondition == "Less than...") {
            selectStatement
                = "SELECT " 
            + "     [Login].[User_Name] "
            + "    ,[Login].[Password] "
            + "FROM " 
            + "     [Login] " 
                + "WHERE " 
                + "     (@User_Name IS NULL OR @User_Name = '' OR [Login].[User_Name] < LTRIM(RTRIM(@User_Name))) " 
                + "AND   (@Password IS NULL OR @Password = '' OR [Login].[Password] < LTRIM(RTRIM(@Password))) " 
                + "";
        } else if  (sCondition == "Equal or more than...") {
            selectStatement
                = "SELECT "
            + "     [Login].[User_Name] "
            + "    ,[Login].[Password] "
            + "FROM " 
            + "     [Login] " 
                + "WHERE " 
                + "     (@User_Name IS NULL OR @User_Name = '' OR [Login].[User_Name] >= LTRIM(RTRIM(@User_Name))) " 
                + "AND   (@Password IS NULL OR @Password = '' OR [Login].[Password] >= LTRIM(RTRIM(@Password))) " 
                + "";
        } else if (sCondition == "Equal or less than...") {
            selectStatement 
                = "SELECT "
            + "     [Login].[User_Name] "
            + "    ,[Login].[Password] "
            + "FROM " 
            + "     [Login] " 
                + "WHERE " 
                + "     (@User_Name IS NULL OR @User_Name = '' OR [Login].[User_Name] <= LTRIM(RTRIM(@User_Name))) " 
                + "AND   (@Password IS NULL OR @Password = '' OR [Login].[Password] <= LTRIM(RTRIM(@Password))) " 
                + "";
        }
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        if (sField == "User Name") {
            selectCommand.Parameters.AddWithValue("@User_Name", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@User_Name", DBNull.Value); }
        if (sField == "Password") {
            selectCommand.Parameters.AddWithValue("@Password", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@Password", DBNull.Value); }
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

    public static Login Select_Record(Login clsLoginPara)
    {
        Login clsLogin = new Login();
        SqlConnection connection = MarriageData.GetConnection();
        string selectStatement
            = "SELECT " 
            + "     [User_Name] "
            + "    ,[Password] "
            + "FROM "
            + "     [Login] "
            + "WHERE "
            + "     [User_Name] = @User_Name "
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        selectCommand.Parameters.AddWithValue("@User_Name", clsLoginPara.User_Name);
        try
        {
            connection.Open();
            SqlDataReader reader
                = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                clsLogin.User_Name = System.Convert.ToString(reader["User_Name"]);
                clsLogin.Password = System.Convert.ToString(reader["Password"]);
            }
            else
            {
                clsLogin = null;
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
        return clsLogin;
    }

    public static bool Add(Login clsLogin)
    {
        SqlConnection connection = MarriageData.GetConnection();
        string insertStatement
            = "INSERT " 
            + "     [Login] "
            + "     ( "
            + "     [User_Name] "
            + "    ,[Password] "
            + "     ) "
            + "VALUES " 
            + "     ( "
            + "     @User_Name "
            + "    ,@Password "
            + "     ) "
            + "";
        SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
        insertCommand.CommandType = CommandType.Text;
        insertCommand.Parameters.AddWithValue("@User_Name", clsLogin.User_Name);
        insertCommand.Parameters.AddWithValue("@Password", clsLogin.Password);
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

    public static bool Update(Login oldLogin, 
           Login newLogin)
    {
        SqlConnection connection = MarriageData.GetConnection();
        string updateStatement
            = "UPDATE "  
            + "     [Login] "
            + "SET "
            + "     [User_Name] = @NewUser_Name "
            + "    ,[Password] = @NewPassword "
            + "WHERE "
            + "     [User_Name] = @OldUser_Name " 
            + " AND [Password] = @OldPassword " 
            + "";
        SqlCommand updateCommand = new SqlCommand(updateStatement, connection);
        updateCommand.CommandType = CommandType.Text;
        updateCommand.Parameters.AddWithValue("@NewUser_Name", newLogin.User_Name);
        updateCommand.Parameters.AddWithValue("@NewPassword", newLogin.Password);
        updateCommand.Parameters.AddWithValue("@OldUser_Name", oldLogin.User_Name);
        updateCommand.Parameters.AddWithValue("@OldPassword", oldLogin.Password);
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

    public static bool Delete(Login clsLogin)
    {
        SqlConnection connection = MarriageData.GetConnection();
        string deleteStatement
            = "DELETE FROM "  
            + "     [Login] "
            + "WHERE " 
            + "     [User_Name] = @OldUser_Name " 
            + " AND [Password] = @OldPassword " 
            + "";
        SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection);
        deleteCommand.CommandType = CommandType.Text;
        deleteCommand.Parameters.AddWithValue("@OldUser_Name", clsLogin.User_Name);
        deleteCommand.Parameters.AddWithValue("@OldPassword", clsLogin.Password);
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

 
