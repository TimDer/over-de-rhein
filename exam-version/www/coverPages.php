<?php

session_start();

if (isset($_SESSION["user_id"])) {
    require __DIR__ . "/template/header.php"; ?>
    
    <a href="/coverPages_add.php" class="btn btn-primary coverPages">Een voorbald toevoegen</a>

    <div class="content-container">
        <table class="table">
            <thead>
                <tr>
                    <th>Voorbald Nummer</th>
                    <th>Hijs-testen</th>
                    <th>Kabel-check-lijst</th>
                    <th>Datum</th>
                    <th>Status</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td><a href="/coverPages_add.php?edit=47">47</a></td>
                    <td><a href="/liftingTests.php?edit=47" class="btn btn-primary">Bewerken</a></td>
                    <td><a href="/cableChecklists.php?edit=47" class="btn btn-primary">Bewerken</a></td>
                    <td>21-02-2020</td>
                    <td>Open</td>
                </tr>
            </tbody>
        </table>
    </div>

    <?php require __DIR__ . "/template/footer.php";
}
else {
    // not logged in
    header("Location: login.php");
}