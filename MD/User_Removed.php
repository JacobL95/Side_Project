<?php
	include "DisplayUtil.php";
	include "Add_User_Util.php";


	DEFINE("LOCALHOST", "localhost");
	DEFINE("USERNAME", "root");
 	DEFINE("PASSWORD", "");
 	DEFINE("DBNAME", "marriage_database");
 	
	$User_To_Be_Removed = $_POST['Removed_User'];
	$u = $_POST['Username'];
    $p = $_POST['Password'];
 	
    $conn = new mysqli(LOCALHOST, USERNAME, PASSWORD, DBNAME);
        //if ($conn->connection_error){
      //  $conn->close();
        //return "ConnectionFailed";
    //}
    
   $sql = "delete from login where User_Name = '" . $User_To_Be_Removed . "';";
   echo $sql;
   $result = $conn->query($sql);
    
    if($result == 1){
    	$conn->close();
		RemoveUserSuccess($u, $p, $User_To_Be_Removed);	
	}
	else{
		$conn->close();
		remove_user_fail($u, $p);	
	}
?>