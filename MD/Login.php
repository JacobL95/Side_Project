<?php 
		include "LoginUtil.php";
        $name = $_POST['Username'];
        $password = $_POST['Password'];
        $result =  user_login($name,$password); 
        if (($result['User_Name']) == "Admin"){ 
        echo '
        <html>
		<head>
		<meta content="text/html; charset=utf-8" http-equiv="Content-Type" />
		<title>Untitled 1</title>

		<style type="text/css">
		.center-p {
				text-align: center;
		}
		.center-div	{
     			margin: 0 auto;
     			width: 100px; 
		}
		</style>
		</head>
		<body>
		<p class="center-p"> Welcome ' . ($result['User_Name']) . '!</p>
			<form method="post">
				<div class="center-div" style="width: 237px">
				<input type="submit"name="Add User" value="Add User" style="width: 239px" />
				<br /><br />	
				<input type="submit" name="Delete User" value="Delete User" style="width: 239px" />
				</div>
			</form>
		</body>
		</html>';}
?>