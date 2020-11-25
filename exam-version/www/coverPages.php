<?php

session_start();

if (isset($_SESSION["user_id"])) {
    require __DIR__ . "/db.php";
    require __DIR__ . "/template/header.php"; ?>
    
    <a href="/coverPages_add.php?type=test" class="btn btn-primary coverPages">Een Hijs-test toevoegen</a>
    <a href="/coverPages_add.php?type=cable" class="btn btn-primary coverPages">Een Kabel-check-lijst toevoegen</a>
    
    <div class="content-container">
        <h1>Overzicht</h1>
        <table class="table">
            <thead>
                <tr>
                    <th>Actie</th>
                    <th>Datum</th>
                    <th>Type</th>
                    <th>Status</th>
                </tr>
            </thead>
            <tbody>
                <?php
                $query = "SELECT `coverPages`.`coverPagesID`,
                                `coverPages`.`inspectionDate`,
                                `coverPageStatus`.`statusType`,
                                `cableChecklists`.`cableChecklistsID` FROM `coverPages`
                        LEFT JOIN `cableChecklists` ON `cableChecklists`.`coverPagesID` = `coverPages`.`coverPagesID`
                        INNER JOIN `coverPageStatus` ON `coverPages`.`coverPageStatusID` = `coverPageStatus`.`coverPageStatusID`
                        ORDER BY `coverPages`.`coverPagesID` DESC";
                $result = mysqli_query($conn, $query);

                if ($result->num_rows > 0) {
                    while ($row = $result->fetch_assoc()) {
                        $type = ($row["cableChecklistsID"] === NULL) ? "test" : "cable";
                        $typeDisplay = ($row["cableChecklistsID"] === NULL) ? "Hijs-testen" : "Kabel-check-lijst";
                        ?>
                        <tr>
                            <td><a href="/coverPages_add.php?edit=<?php echo $row["coverPagesID"]; ?>&type=<?php echo $type; ?>" class="btn btn-primary">Bewerk: <?php echo $row["coverPagesID"]; ?></a></td>
                            <td><?php echo date("d-m-Y", strtotime($row["inspectionDate"])); ?></td>
                            <td><?php echo $typeDisplay; ?></td>
                            <td><?php echo $row["statusType"]; ?></td>
                        </tr>
                        <?php
                    }
                }
                ?>
            </tbody>
        </table>
    </div>

    <?php require __DIR__ . "/template/footer.php";
}
else {
    // not logged in
    header("Location: login.php");
}