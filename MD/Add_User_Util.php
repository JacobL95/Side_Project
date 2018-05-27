<?php
	//include "DisplayUtil.php";
function add_user($u, $p, $NewUser, $NewPassword){
	DEFINE("LOCALHOST", "localhost");
	DEFINE("USERNAME", "root");
 	DEFINE("PASSWORD", "");
 	DEFINE("DBNAME", "marriage_database");
 	
    $conn = new mysqli(LOCALHOST, USERNAME, PASSWORD, DBNAME);
    //if ($conn->connection_error){
      //  $conn->close();
        //return "ConnectionFailed";
    //}
    
    $sql = "insert into `Login`(`User_Name`,`Password`) values ('" . $NewUser . "', '" . $NewPassword ."');";
    $result = $conn->query($sql);
    
	if($result == 1){
		AddUserSuccess($u, $p, $NewUser);	
	}
	else{
		ShowAddUserError($u, $p);	
	}
    $conn->close();
    return;         
}
?>