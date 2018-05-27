<?php 
	include "LoginUtil.php";
	include "DisplayUtil.php";
	include "Add_User_Util.php";

	$authenticate = $_POST['Login'];
	$name = $_POST['Username'];
    $password = $_POST['Password'];
    echo $authenticate;
	switch($authenticate){
	case "Submit": 
	case "Return to Menu":
       $result =  user_login($name,$password);            
       switch ($result){ 
   		    case "Admin":
   			    ShowLoginPageAdmin($name, $password);
   		    break;
		    default:
        		ShowLoginFail();
	   		break;
	   }
	 break;
	 case "Add User":
   		ShowAddUser($name, $password);
	 break;
	 case "Add New User":
   		$NewUser = $_POST['NewUsername'];
		$NewPW = $_POST['NewPassword'];
    	$NewPWC = $_POST['NewPasswordCheck'];
    	if($NewPW == $NewPWC){
	    	add_user($name, $password, $NewUser, $NewPW);
    	}
    	else{
    		ShowAddUserFail($name, $password);
    	}
	 break;
	 default:
   		ShowLoginFail();
	 break;
	}	
?>
 
