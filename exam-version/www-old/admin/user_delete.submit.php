<?php

session_start();

if (isset($_SESSION["admin_id"])) {
    require_once __DIR__ . "/../classes/database.class.php";

    $user_id = mysqli_real_escape_string($conn, $_GET["id"]);
    $deleteQuery = "DELETE FROM `users` WHERE `userID`='$user_id'";

    $result = database::query($deleteQuery);

    if ($result === true) {
        header("Location: index.php");
    }
    else {
        header("Location: error.php");
    }
}
else {
    // not logged in
    header("Location: ../login.php");
}