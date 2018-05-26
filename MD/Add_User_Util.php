<?php
 DEFINE("LOCALHOST", "localhost");
 DEFINE("USERNAME", "root");
 DEFINE("PASSWORD", "");
 DEFINE("DBNAME", "marriage_database");

function add_user($UN, $PASS)
{
    $conn = new mysqli(LOCALHOST, USERNAME, PASSWORD, DBNAME);
    //if ($conn->connection_error){
      //  $conn->close();
        //return "ConnectionFailed";
    //}
    
    $sql = "insert into `Login`(`User_Name`,`Password`) values ('" . $UN . "', '" . $PASS ."');";
    $result = $conn->query($sql);
    
	if($result == 1){
	echo '
<html>
<head>
<title>Marriage Database</title>
<style type="text/css">
.MD_Main_CSS
{
    background: #f4f7f8;
    background: #D8D8D8;
    border-radius: 8px;
    font-family: Georgia, "Times New Roman", Times, serif;
    margin: 130px auto;
    max-width: 500px;
    padding: 10px 20px;
    padding: 20px;
}
.MD_Main_CSS fieldset
{
    border: none;
}
.MD_Main_CSS .center
{
    display: block;
    padding: 7px 39px 7px 31px;
    position: relative;
}
.MD_Main_CSS text_mod 
{
    font-size: 1.4em;
    margin-bottom: 1px;
}
.MD_Main_CSS Login_Fail 
{
    color: #D8D8D8;
    font-size: 1.4em;
    margin-bottom: 1px;
    padding: 7px 39px 7px 100px;
}
.MD_Main_CSS input[type=text], .MD_Main_CSS input[type=password], .MD_Main_CSS textarea
{
    background: rgba(255,255,255,.1);
    background-color: #e8eeef;
    border: none;
    border-radius: 4px;
    color:#1a1a1a;
    font-family: Georgia, "Times New Roman", Times, serif;
    font-size: 16px;
    height: 30px;
    margin: 0;
    margin-bottom: 3px;
    outline: 0;
    padding: 0px;
    width: 100%;
}
.MD_Main_CSS .number 
{ 
    border-radius: 5px;
    font-size: 1em;
    height: 30px;
    line-height: 30px;
    margin-right: 4px;
    text-align: center;
    width: 100px;
}
.MD_Main_CSS input[type=submit], .MD_Main_CSS input[type=button]
{
    background: #1a75ff;
    border: 1px solid #1a75ff;
    border-radius: 8px;
    border-width: 1px 1px 1px;
    color: #FFF;
    display: block;
    font-size: 18px;
    font-style: normal;
    margin: 0 auto;
    margin-bottom: 5px;
    padding: 18px 39px 18px 39px;
    position: relative;
    text-align: center;
    width: 477px;
}
.MD_Main_CSS input[type=submit]:hover, .MD_Main_CSS input[type=button]:hover
{
    background: #0047b3;
}
</style>
</head>
<body>
<div class="MD_Main_CSS">
<form action="Login.php">
<text_mod><span class="center">You Succesfully Added User ' . $UN . '!</span></text_mod>
<input id="admin-submit" type="submit" name="Return to Menu" value="Return to Menu" />
</form>
<form action="LoginPage.html">
<input type="submit" value="Logout" />
</form>
</div>
</body>
</html>
	';
	}
	else{
	echo'
<html>
<head>
<title>Marriage Database</title>
<style type="text/css">
.MD_Main_CSS
{
    background: #f4f7f8;
    background: #D8D8D8;
    border-radius: 8px;
    font-family: Georgia, "Times New Roman", Times, serif;
    margin: 130px auto;
    max-width: 500px;
    padding: 10px 20px;
    padding: 20px;
}
.MD_Main_CSS fieldset
{
    border: none;
}
.MD_Main_CSS .center
{
    display: block;
    padding: 7px 39px 7px 180px;
    position: relative;
}
.MD_Main_CSS text_mod 
{
    font-size: 1.4em;
    margin-bottom: 1px;
}
.MD_Main_CSS Login_Fail 
{
    color: red;
    font-size: 1.4em;
    margin-bottom: 1px;
    padding: 7px 39px 7px 125px;
}
.MD_Main_CSS input[type=text], .MD_Main_CSS input[type=password], .MD_Main_CSS textarea
{
    background: rgba(255,255,255,.1);
    background-color: #e8eeef;
    border: none;
    border-radius: 4px;
    color:#1a1a1a;
    font-family: Georgia, "Times New Roman", Times, serif;
    font-size: 16px;
    height: 30px;
    margin: 0;
    margin-bottom: 3px;
    outline: 0;
    padding: 0px;
    width: 100%;
}
.MD_Main_CSS .number 
{ 
    border-radius: 5px;
    font-size: 1em;
    height: 30px;
    line-height: 30px;
    margin-right: 4px;
    text-align: center;
    width: 100px;
}
.MD_Main_CSS input[type=submit], .MD_Main_CSS input[type=button]
{
    background: #1a75ff;
    border: 1px solid #1a75ff;
    border-radius: 8px;
    border-width: 1px 1px 1px;
    color: #FFF;
    display: block;
    font-size: 18px;
    font-style: normal;
    margin: 0 auto;
    margin-bottom: 5px;
    padding: 18px 39px 18px 39px;
    position: relative;
    text-align: center;
    width: 477px;
}
.MD_Main_CSS input[type=submit]:hover, .MD_Main_CSS input[type=button]:hover
{
    background: #0047b3;
}
</style>
</head>
<body>
<div class="MD_Main_CSS">
<form action="Admin_Handler.php" method="post">
<fieldset>
<text_mod><span class="center">Add User</span></text_mod>
<text_mod><span class="number">Enter New Username</span></text_mod>
<input name="Username" type="text" />
<text_mod><span class="number">Enter Password</span></text_mod>
<input name="Password1" type="text" />
<text_mod><span class="number">Re-enter Password</span></text_mod>
<input name="Password2" type="text" />
</fieldset>
<input type="submit" value="Submit" />
<Login_Fail>An Error Occurred!</Login_Fail>
</form>
</div>
</body>
</html>
';
}
    $conn->close();
    return "LoginFailed";         
}
?>