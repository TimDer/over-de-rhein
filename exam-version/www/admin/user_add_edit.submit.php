<?php

session_start();

if (isset($_SESSION["admin_id"])) {
    require_once __DIR__ . "/../classes/users.class.php";

    if ($_POST["password"] === $_POST["password-repeat"]) {
        $users = new users();
        $users->create_password_salt(1000, 10000);
    
        $userSubmitArray = array(
            "userTypeID"    => $_POST["userTypeID"],
            "userName"      => $_POST["userName"],
            "password"      => hash("sha512", $_POST["password"] . $users->salt),
            "passwordSalt"  => $users->salt
        );

        require_once __DIR__ . "/../classes/database.class.php";
    
        if ($_POST["userID"] === "new") {
            $query = database::insert($userSubmitArray, "users");
        }
        else {
            $query = database::update($userSubmitArray, "users", array("userID" => $_POST["userID"]));
        }
    
        $result = database::query($query);
        if ($result === true) {
            header("Location: index.php");
        }
        else {
            header("Location: error.php");
        }
    }
    else {
        header("Location: error.php");
    }
}
else {
    // not logged in
    header("Location: ../login.php");
}