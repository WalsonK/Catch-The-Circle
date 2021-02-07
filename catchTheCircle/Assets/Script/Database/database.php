 <?php
$mysqli = new mysqli("localhost","sa","sa","ppe4");

// Check connection
if ($mysqli -> connect_errno) {
  echo "Failed to connect to MySQL: " . $mysqli -> connect_error;
  exit();
}
?>