<?php

session_start();

if (isset($_SESSION["admin_id"])) {
    require_once __DIR__ . "/../db.php";

    $result_array = array();
    $query = mysqli_query($conn, "SELECT `users`.`userID`, `users`.`userName`, `userType`.`type` FROM `users` LEFT JOIN `userType` ON `users`.`userTypeID` = `userType`.`userTypeID`");
    if ($query->num_rows > 0) {
        while ($result = $query->fetch_assoc()) {
            $result_array[] = $result;
        }
    }

    require __DIR__ . "/../template/header.php"; ?>

    <a href="user_add_edit.php" class="btn btn-primary coverPages">Een gebruiker toevoegen</a>
    
    <div class="content-container">
        <table class="table">
            <thead>
                <tr>
                    <th>Gebruiker nummer</th>
                    <th>Gebruikersnaam</th>
                    <th>Type gebruiker</th>
                    <th>Actie</th>
                </tr>
            </thead>
            <tbody>
                <?php foreach ($result_array AS $key => $value) { ?>
                    <tr>
                        <td><?php echo $value["userID"] ?></td>
                        <td><?php echo $value["userName"] ?></td>
                        <td><?php echo $value["type"] ?></td>
                        <td><a href="user_add_edit.php?id=<?php echo $value["userID"] ?>" class="btn btn-primary">Bewerken</a> <a href="#" class="btn btn-primary">Verwijderen</a></td>
                    </tr>
                <?php } ?>
            </tbody>
        </table>
    </div>

    <?php require __DIR__ . "/../template/footer.php";
}
else {
    // not logged in
    header("Location: ../login.php");
}