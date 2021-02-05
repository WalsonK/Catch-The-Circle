<?php
	$host = "http://localhost/127.0.0.1"; // Host name 
	$db_username = "sa"; // Mysql username 
	$db_password = "sa"; // Mysql password 
	$db_name = "ppe4"; // Database name 

	$mysqli_conection = mysqli_connect($host, $db_username, $db_password, $db_name)or die("cannot connect"); 
?>