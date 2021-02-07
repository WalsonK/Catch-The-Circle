<?php

    $con = mysqli_connect('localhost', 'sa', 'sa', 'ppe4');

    //check connection
    if(mysqli_connect_errno()){
        echo "1: Connection failed";
        exit();
    }

    $errors = array();
    $mail = $_POST["mail"];
    $password = $_POST["password"];

    //check name exists
    $acccheckquery = "SELECT id_manager FROM manager WHERE mail_manager =' ? ' AND ' ? '";
    

    if ($stmt = $con->prepare($acccheckquery)){
        /* bind parameters for markers */
        $stmt->bind_param("ss", $mail, $password);
            
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


    if (mysqli_num_rows($acccheck) == 0){
        $errors[] = "5 : Aucun utilisateur trouvé";
        exit();
    }
    else if(mysqli_num_rows($acccheck) > 1){
        $errors[] = "6 : Plusieurs utilisateur avec ces identifiants";
        exit();
    }
    else{
        //get login info from query
        $existingInfo = mysqli_fetch_assoc($acccheck);
        
    }
    
    echo("0");


    

?>