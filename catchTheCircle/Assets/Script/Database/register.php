<?php

    $con = mysqli_connect('localhost', 'sa', 'sa', 'ppe4');
/*
    //check connection
    if(mysqli_connect_errno()){
        echo "1: Connection failed";
        exit();
    }

    $firstname = $_POST["firstname"];
    $lastname = $_POST["lastname"];

    //check name exists
    $namecheckquery = "SELECT firstname_user, lastname_user FROM user WHERE firstname_user ='" . $firstname . "'";

    $namecheck = mysqli_query($con, $namecheckquery) or die("2: Name check query failed"); 

    if (mysqli_num_rows($namecheck) > 0){
        echo "3: Name already exists";
        $updateuserquery = "Update user";
        exit();
    }

    $intertuserquery = "INSERT INTO `user`( `firstname_user`, `lastname_user`, `id_manager`) VALUES ( '". $firstname ."', '". $lastname ."', '1');";
    mysqli_query($con, $intertuserquery) or die("4: Insert player query failed");
    
    echo("0");

*/

    $errors = array();

    $firstname = $_POST["firstname"];
    $lastname = $_POST["lastname"];

    if(count($errors) == 0){
        //$hashedPassword = password_hash($password1, PASSWORD_BCRYPT);
        if ($stmt = $con->prepare("INSERT INTO `user`( `firstname_user`, `lastname_user`, `id_manager`) VALUES( ?, ?, ?)")) {
            $id = 1;
            /* bind parameters for markers */
            $stmt->bind_param("ssi",$firstname, $lastname, $id);
                
            /* execute query */
            if($stmt->execute()){
                
                /* close statement */
                $stmt->close();
                
            }else{
                $errors[] = "Une erreur à eut lieu, veuillez réessayer.";
            }
        }else{
            $errors[] = "Une erreur à eut lieu, veuillez réessayer.";
        }
    }

?>