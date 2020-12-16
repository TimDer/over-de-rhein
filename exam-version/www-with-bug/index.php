<?php

session_start();

if (isset($_SESSION["user_id"])) {
    header("Location: coverPages.php");
}
else {
    // not logged in
    header("Location: login.php");
}