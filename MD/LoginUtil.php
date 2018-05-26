<?php
 DEFINE("LOCALHOST", "localhost");
 DEFINE("USERNAME", "root");
 DEFINE("PASSWORD", "");
 DEFINE("DBNAME", "marriage_database");

function user_login($UN, $PASS)
{
    $conn = new mysqli(LOCALHOST, USERNAME, PASSWORD, DBNAME);
    //if ($conn->connection_error){
      //  $conn->close();
        //return "ConnectionFailed";
    //}
    
    $sql = "SELECT User_Name FROM Login WHERE '" . $UN . "' = User_Name AND '" . $PASS."' = Password";
    $result = $conn->query($sql);
    
    if($result->num_rows == 1){
        $row = $result->fetch_assoc();
        $conn->close();
        return $row['User_Name'];
    }
    $conn->close();
    return "LoginFailed";         
}
?>