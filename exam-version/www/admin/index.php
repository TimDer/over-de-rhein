<?php

session_start();

if (isset($_SESSION["admin_id"])) {
    

    require __DIR__ . "/../template/header.php"; ?>

    <a href="user_add_edit.php" class="btn btn-primary coverPages">Een gebruiker toevoegen</a>
    
    <div class="content-container">
        <table class="table">
            <thead>
                <tr>
                    <th>Gebruiker nummer</th>
                    <th>Gebruikersnaam</th>
                    <th>Actie</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>1</td>
                    <td>User_1</td>
                    <td><a href="user_add_edit.php?id=1" class="btn btn-primary">Bewerken</a> <a href="#" class="btn btn-primary">Verwijderen</a></td>
                </tr>
            </tbody>
        </table>
    </div>

    <?php require __DIR__ . "/../template/footer.php";
}
else {
    // not logged in
    header("Location: ../login.php");
}