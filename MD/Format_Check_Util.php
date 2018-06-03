<?php 
function Credentials_CheckUN($Creds){
if(strlen($Creds) < 6)
	{
		return false;
	}
	else
	{
		return true;
	}
}
function Credentials_CheckPW($Creds){
if(strlen($Creds) < 8)
	{
		return false;
	}
	else
	{
		return true;
	}
}





?>
 
