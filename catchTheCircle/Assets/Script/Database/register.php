<?php

    $con = mysqli_connect('localhost', 'sa', 'sa', 'ppe4');

    //check connection
    if(mysqli_connect_errno()){
        echo "1: Connection failed";
        exit();
    }

    $firstname = $_POST["fistname"];
    $lastname = $_POST["lastname"];

    //check name exists
    $namecheckquery = "SELECT firstname_user, lastname_user FROM user WHERE firstname_user ='" . $firsname . "'";

    $namecheck = mysqli_query($con, $namecheckquery) or die("2: Name check query failed"); 

    if (mysqli_num_rows($namecheck) > 0){
        echo "3: Name already exists";
        $updateuserquery = "Update user";
        exit();
    }

    $intertuserquery = "INSERT INTO `user`( `firstname_user`, `lastname_user`, `id_manager`) VALUES ( '". $firstname ."', '". $lastname ."', '1');";
    mysqli_query($con, $intertuserquery) or die("4: Insert player query failed");
    
    echo("0");
?>