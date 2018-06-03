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

function remove_user($u, $p){
	DEFINE("LOCALHOST", "localhost");
	DEFINE("USERNAME", "root");
 	DEFINE("PASSWORD", "");
 	DEFINE("DBNAME", "marriage_database");
 	
    $conn = new mysqli(LOCALHOST, USERNAME, PASSWORD, DBNAME);
    //if ($conn->connection_error){
      //  $conn->close();
        //return "ConnectionFailed";
    //}
    
    $sql = "select User_Name from login;";
    $result = $conn->query($sql);
    
    echo'
	 <html>
	 <head>
		<link rel="stylesheet" href="Master_Style_Sheet_V2.css">
		<link rel="stylesheet" href="JQuery_Attributes/bootstrap.min.css">
		<script src="JQuery_Attributes/jquery.min.js"></script>
		<script src="JQuery_Attributes/bootstrap.min.js"></script>
		<script src="JQuery_Attributes/search.engine.js"></script>
	 </head>
	 <body>
		<div class="MD_Main_CSS">
		<text_mod><span class="center_admin">Pick a User to Remove</span></text_mod>
			<div class="form-group pull-left">
			    <input type="text" class="search form-control" placeholder=" Search">
			</div>
			<div class="DU_Submit">
			    <Move_Submit><input type="submit" value="Submit"></Move_Submit>
			</div>

		<table class="table table-striped" id="userTbl">
		    <thead>
		    <tr>
		      <th>Select User</th>
	    	  <th>Username</th>
	    	</tr>
	    </thead>
	    <tbody>
	     ';
    
    
    
    while($row = $result->fetch_assoc())
    {
    	echo '
    	<tr>
    	    <td> 
    	    <input type="radio" name="select" value="'.  $row["User_Name"].'"> Select '.  $row["User_Name"].'
    	    </td>
        	<td style="width:10%;" align= "center">'.  $row["User_Name"].'</td>
        </tr>';
    }
    
	echo'
	 
		 </tbody>
	</table>
	</div>
	</body>
	</html>';
    $conn->close();
    return;         
}







?>