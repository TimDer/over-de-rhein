<?php

/* ============================== with html ============================== */

session_start();

if (isset($_SESSION["user_id"])) {
    require __DIR__ . "/template/header.php"; ?>
    
    

    <?php require __DIR__ . "/template/footer.php";
}
else {
    // not logged in
    header("Location: login.php");
}



?>

<?php /* ============================== without html ============================== */ ?>

<?php

session_start();

if (isset($_SESSION["user_id"])) {
    
}
else {
    // not logged in
    header("Location: login.php");
}