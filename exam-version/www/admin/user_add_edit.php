<?php

session_start();

if (isset($_SESSION["admin_id"])) {


    require __DIR__ . "/../template/header.php"; ?>

    <a href="index.php" class="btn btn-primary coverPages">Een gebruiker toevoegen</a>
    
    <div class="content-container">
        <form action="#" method="post">
            <div class="row">
                <div class="col-lg">
                    <p>
                        <label for="">Gebruikersnaam:</label>
                        <input type="text" class="form-control">
                    </p>
                    <p>
                        <label for="">Gebruikersnaam:</label>
                        <select name="userType" class="form-control">
                            <option value="1">Directie</option>
                            <option value="5">Admin</option>
                        </select>
                    </p>
                </div>
                <div class="col-lg">
                    <p>
                        <label for="">Wachtwoord</label>
                        <input type="text" class="form-control">
                    </p>
                    <p>
                        <label for="">Herhaal het wachtwoord</label>
                        <input type="text" class="form-control">
                    </p>
                </div>
            </div>
            <input type="submit" value="Opslaan" class="btn btn-success btn-block">
        </form>
    </div>

    <?php require __DIR__ . "/../template/footer.php";
}
else {
    // not logged in
    header("Location: ../login.php");
}