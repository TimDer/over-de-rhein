<?php

session_start();

if (isset($_SESSION["admin_id"])) {
    require __DIR__ . "/../template/header.php"; ?>
    
    <a href="/admin" class="btn btn-primary coverPages">Terug naar overzigt</a>

    <h1>Oeps er is iets fout gegaan</h1>

    <?php require __DIR__ . "/../template/footer.php";
}
else {
    // not logged in
    header("Location: ../login.php");
}