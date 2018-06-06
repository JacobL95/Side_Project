<?php 
	include "LoginUtil.php";
	include "DisplayUtil.php";
	include "Add_User_Util.php";
	include "Format_Check_Util.php";
	
	$authenticate = $_POST['Login'];
	$name = $_POST['Username'];
    $password = $_POST['Password'];
    echo $authenticate;
	echo $name;
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
	 
	 
	 
	 
	 //Adding User
	 case "Add User":
   		ShowAddUser($name, $password);
	 break;
	 case "Add New User":
	 
   		$NewUser = $_POST['NewUsername'];
		$NewPW = $_POST['NewPassword'];
    	$NewPWC = $_POST['NewPasswordCheck'];
    	
    	$AUCheckNU = Credentials_CheckUN($NewUser);  	
    	$AUCheckPW = Credentials_CheckPW($NewPW);
    	
    	if($NewPW == $NewPWC){
	    	add_user($name, $password, $NewUser, $NewPW);
    	}
    	else if($AUCheckNU == false || $AUCheckPW == false){
    	     ShowAddUserError($name, $password);
    	} 
       	else{
    		ShowAddUserFail($name, $password);
    	}
	 break;
	 
	 
	 
	 
	 
	//Removing user 
	 
	 case "Remove User":
   		remove_user($name, $password);
	 break;
	 
	 case "Remove":
    	$User_To_Be_Removed = $_POST['selectRMU'];
    	echo $User_To_Be_Removed;
    	
    	
    	if($User_To_Be_Removed == ""){
      		remove_user_fail($name, $password);
    	}
    	else{
    		Show_Remove_User_Check($name, $password, $User_To_Be_Removed);
    	}
				
   		
	 break;

	 default:
   		ShowLoginFail();
	 break;
	}	
?>
 
