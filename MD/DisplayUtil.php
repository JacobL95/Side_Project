<?php 
	function ShowLoginPageAdmin($u, $p){
	
	echo'
		<html>
		<head>
		<title>Marriage Database</title>
		<link rel="stylesheet" href="Master_Style_Sheet.css">
		</head>
		<body>
		<div class="MD_Main_CSS">
		<form action="Master_Control.php" method="post">
		<text_mod><span class="center_admin">Welcome Administrator!</span></text_mod>
		
		<input type="submit" name="Login" value="Add User" />
		
		<input type="hidden" name="Username" value="' .$u. '"/>		
		<input type="hidden" name="Password" value="' .$p. '"/>
		
		<input type="submit" value="Remove User" />
		<input type="submit" value="Add Record" />
		<input type="submit" value="Remove Record" />
		<input type="submit" value="View Records" />
		<input type="submit" value="View Logs" />
		</form>
		</div>
		</body>
		</html>
		';
	}	
	function ShowLoginFail(){
	echo'
		<html>
		<head>
		<title>Marriage Database</title>
		<link rel="stylesheet" href="Master_Style_Sheet.css">
		</head>
		<body>
		<div class="MD_Main_CSS">
		<form action="Master_Control.php" method="post">
			<fieldset>
				<text_mod><span class="center">Welcome</span></text_mod>
				<text_mod><span class="number">Username</span></text_mod>
				<input name="Username" type="text" />
				<text_mod><span class="number">Password</span></text_mod>
				<input name="Password" type="password" />
			</fieldset>
		<input type="submit" value="Submit" />
		<Login_Fail>Invalid Username or Password!</Login_Fail>
		</form>
		</div>
		</body>
		</html>';
	}
	
	function ShowAddUser($u, $p){
	echo'
	<html>
	<head>
	<title>Marriage Database</title>
	<link rel="stylesheet" href="Master_Style_Sheet.css">
	</head>
	<body>
	<div class="MD_Main_CSS">
	<form action="Master_Control.php" method="post">
		<fieldset>
			<text_mod><span class="center">Add User</span></text_mod>
			<text_mod><span class="number">Enter New Username</span></text_mod>
			<input name="NewUsername" type="text" />
			<text_mod><span class="number">Enter Password</span></text_mod>
			<input name="NewPassword" type="text" />
			<text_mod><span class="number">Re-enter Password</span></text_mod>
			<input name="NewPasswordCheck" type="text" />
			<input type="hidden" name="Username" value="' .$u. '"/>		
     		<input type="hidden" name="Password" value="' .$p. '"/>
		</fieldset>
	<input type="submit" name="Login" value="Add New User" />
	<Login_Fail> </Login_Fail>
	</form>
	</div>
	</body>
	</html>';
	}	
	function ShowAddUserFail($u, $p){
	
	echo'
	<html>
	<head>
	<title>Marriage Database</title>
	<link rel="stylesheet" href="Master_Style_Sheet.css">
	</head>
	<body>
	<div class="MD_Main_CSS">
	<form action="Master_Control.php" method="post">
		<fieldset>
			<text_mod><span class="center">Add User</span></text_mod>
			<text_mod><span class="number">Enter New Username</span></text_mod>
			<input name="NewUsername" type="text" />
			<text_mod><span class="number">Enter Password</span></text_mod>
			<input name="NewPassword" type="text" />
			<text_mod><span class="number">Re-enter Password</span></text_mod>
			<input name="NewPasswordCheck" type="text" />
			<input type="hidden" name="Username" value="' .$u. '"/>		
     		<input type="hidden" name="Password" value="' .$p. '"/>
		</fieldset>
	<input type="submit" name="Login" value="Add New User" />
	<Login_Fail> Passwords Do Not Match </Login_Fail>
	</form>
	</div>
	</body>
	</html>';
	}
	function AddUserSuccess($u, $p, $NewUser){
	echo '
	<html>
	<head>
	<title>Marriage Database</title>
	<link rel="stylesheet" href="Master_Style_Sheet.css">
	</head>
	<body>
	<div class="MD_Main_CSS">
		<form action="Master_Control.php" method="post">
			<text_mod><span class="center_UA">You Succesfully Added User ' . $NewUser . '!</span></text_mod>
			<input type="submit" name="Login" value="Return to Menu" />
			<input type="hidden" name="Username" value="' .$u. '"/>		
			<input type="hidden" name="Password" value="' .$p. '"/>
		</form>
		<form action="LoginPage.html">
			<input type="submit" value="Logout" />
		</form>
	</div>
	</body>
	</html>
	';
    }	
	function ShowAddUserError($u, $p){
	echo'
	<html>
	<head>
	<title>Marriage Database</title>
	<link rel="stylesheet" href="Master_Style_Sheet.css">
	</head>
	<body>
	<div class="MD_Main_CSS">
	<form action="Master_Control.php" method="post">
		<fieldset>
			<text_mod><span class="center">Add User</span></text_mod>
			<text_mod><span class="number">Enter New Username</span></text_mod>
			<input name="NewUsername" type="text" />
			<text_mod><span class="number">Enter Password</span></text_mod>
			<input name="NewPassword" type="text" />
			<text_mod><span class="number">Re-enter Password</span></text_mod>
			<input name="NewPasswordCheck" type="text" />
			<input type="hidden" name="Username" value="' .$u. '"/>		
	     	<input type="hidden" name="Password" value="' .$p. '"/>
		</fieldset>
	<input type="submit" name="Login" value="Add New User" />
	<User_Add_Fail>An Error Occured</User_Add_Fail>
	</form>
	</div>
	</body>
	</html>
	';
	}
?>
 
