<?php

session_start();

if (isset($_SESSION["admin_id"])) {
    require_once __DIR__ . "/../db.php";

    $userName = "";
    $userTypeID = "";

    // set user vars
    if (isset($_GET["id"])) {
        $user_id = $_GET["id"];
        $userResult = mysqli_query($conn, "SELECT `userName`, `userTypeID` FROM `users` WHERE `userID`='$user_id'");
        if ($userResult->num_rows > 0) {
            while ($row = $userResult->fetch_assoc()) {
                foreach ($row AS $key => $value) {
                    $$key = $value;
                }
            }
        }
    }

    // setup user type array
    $userTypeArray = array();
    $userTypeResult = mysqli_query($conn, "SELECT * FROM `userType`");
    if ($userTypeResult->num_rows > 0) {
        while ($rows = $userTypeResult->fetch_assoc()) {
            $userTypeArray[] = $rows;
        }
    }

    require __DIR__ . "/../template/header.php"; ?>

    <a href="index.php" class="btn btn-primary coverPages">Een gebruiker toevoegen</a>
    
    <div class="content-container">
        <form action="user_add_edit.submit.php" method="post">
            <div class="row">
                <div class="col-lg">
                    <p>
                        <label for="">Gebruikersnaam:</label>
                        <input type="text" class="form-control" name="userName" value="<?php echo $userName; ?>">
                    </p>
                    <p>
                        <label for="">Gebruikerstype:</label>
                        <select class="form-control" name="userTypeID">
                            <?php foreach ($userTypeArray AS $key => $value) { ?>
                                <option value="<?php echo $value["userTypeID"]; ?>" <?php echo ($value["userTypeID"] === $userTypeID) ? "selected" : ""; ?>><?php echo $value["type"]; ?></option>
                            <?php } ?>
                        </select>
                    </p>
                </div>
                <div class="col-lg">
                    <p>
                        <label for="">Wachtwoord</label>
                        <input type="password" class="form-control" name="password">
                    </p>
                    <p>
                        <label for="">Herhaal het wachtwoord</label>
                        <input type="password" class="form-control" name="password-repeat">
                    </p>
                </div>
            </div>
            <input type="hidden" name="userID" value="<?php echo (isset($_GET["id"])) ? $user_id : "new"; ?>">
            <input type="submit" value="Opslaan" class="btn btn-success btn-block">
        </form>
    </div>

    <?php require __DIR__ . "/../template/footer.php";
}
else {
    // not logged in
    header("Location: ../login.php");
}