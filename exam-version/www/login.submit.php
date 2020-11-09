<?php

require __DIR__ . "/db.php";

$username = mysqli_real_escape_string($conn, $_POST["username"]);
$password = mysqli_real_escape_string($conn, $_POST["password"]);

$query = "SELECT `users`.`userID`, `users`.`userName`, `users`.`password`, `users`.`passwordSalt`, `userType`.`type` FROM users INNER JOIN userType ON users.userTypeID=userType.userTypeID WHERE users.userName = '$username'";
$result = mysqli_query($conn, $query);

if (mysqli_num_rows($result) > 0) {
    while ($row = mysqli_fetch_assoc($result)) {
        $password_sult = hash("sha512", $password . $row["passwordSalt"]);
        
        if ($password_sult === $row["password"]) {
            session_start();
            $_SESSION["user_id"] = $row["userID"];
            header("Location: index.php");
        }
        else {
            header("Location: login.php");
            echo "2";
        }
    }
}
else {
    header("Location: login.php");
}