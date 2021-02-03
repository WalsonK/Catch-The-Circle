<?php
	if(isset($_POST["email"]) && isset($_POST["password1"]) && isset($_POST["password2"])){
		$errors = array();
		
		$emailMaxLength = 254;
		$passwordMaxLength = 19;
		$passwordMinLength = 5;
		
		$email = strtolower($_POST["email"]);
		$password1 = $_POST["password1"];
		$password2 = $_POST["password2"];
		
		//Validate email
		if(preg_match('/\s/', $email)){
			$errors[] = "Les email ne peuvent contenir d'espace";
		}else{
			if(!validate_email_address($email)){
				$errors[] = "Email invalide";
			}else{
				if(strlen($email) > $emailMaxLength){
					$errors[] = "l'email est trop long, il doit être égal ou en dessous de  " . strval($emailMaxLength) . " lettres";
				}
			}
		}
		
		//Validate password
		if($password1 != $password2){
			$errors[] = "Les mots de passe ne correspondent pas";
		}else{
			if(preg_match('/\s/', $password1)){
				$errors[] = "Les mots de passe ne doivent pas contenir d'espace";
			}else{
				if(strlen($password1) > $passwordMaxLength || strlen($password1) < $passwordMinLength){
					$errors[] = "Mot de passe trop long, il doit être entre " . strval($passwordMinLength) . " et " . strval($passwordMaxLength) . " caractères";
				}else{
					if(!preg_match('/[A-Za-z]/', $password1) || !preg_match('/[0-9]/', $password1)){
						$errors[] = "Le mot de passe doit contenir au moins 1 chiffre ";
					}
				}
			}
		}
		
		//Check if there is user already registered with the same email or username
		if(count($errors) == 0){
			//Connect to database
			require dirname(__FILE__) . '/database.php';
			
			if ($stmt = $mysqli_conection->prepare("SELECT mail_manager FROM manager WHERE mail_manager = ? LIMIT 1")) {
				
				/* bind parameters for markers */
				$stmt->bind_param('ss', $email);
					
				/* execute query */
				if($stmt->execute()){
					
					/* store result */
					$stmt->store_result();

					if($stmt->num_rows > 0){
					
						/* bind result variables */
						$stmt->bind_result($email_tmp);

						/* fetch value */
						$stmt->fetch();
						
						if($email_tmp == $email){
							$errors[] = "Cette email est déjà utilisé.";
						}
					}
					
					/* close statement */
					$stmt->close();
					
				}else{
					$errors[] = "Une erreur à eut lieu, veuillez réessayer.";
				}
			}else{
				$errors[] = "Une erreur à eut lieu, veuillez réessayer.";
			}
		}
		
		//Finalize registration
		if(count($errors) == 0){
			$hashedPassword = password_hash($password1, PASSWORD_BCRYPT);
			if ($stmt = $mysqli_conection->prepare("INSERT INTO manager (mail_manager, password_manager) VALUES( ?, ?)")) {
				
				/* bind parameters for markers */
				$stmt->bind_param('sss', $hashedPassword);
					
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
		
		if(count($errors) > 0){
			echo $errors[0];
		}else{
			echo "Success";
		}
	}else{
		echo "Missing data";
	}
	
	function validate_email_address($email) {
		return preg_match('/^([a-z0-9!#$%&\'*+-\/=?^_`{|}~.]+@[a-z0-9.-]+\.[a-z0-9]+)$/i', $email);
	}
?>