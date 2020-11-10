<?php

session_start();

if (isset($_SESSION["user_id"])) {
    require __DIR__ . "/db.php";
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
                <?php
                $query = "SELECT coverPages.coverPagesID, coverPages.inspectionDate, coverPageStatus.statusType FROM `coverPages` INNER JOIN coverPageStatus ON coverPages.coverPageStatusID=coverPageStatus.coverPageStatusID";
                $result = mysqli_query($conn, $query);

                if ($result->num_rows > 0) {
                    while ($row = $result->fetch_assoc()) {
                        ?>
                        <tr>
                            <td><a href="/coverPages_add.php?edit=<?php echo $row["coverPagesID"]; ?>"><?php echo $row["coverPagesID"]; ?></a></td>
                            <td><a href="/liftingTests.php?edit=<?php echo $row["coverPagesID"]; ?>" class="btn btn-primary">Bewerken</a></td>
                            <td><a href="/cableChecklists.php?edit=<?php echo $row["coverPagesID"]; ?>" class="btn btn-primary">Bewerken</a></td>
                            <td><?php echo date("d-m-Y", strtotime($row["inspectionDate"])); ?></td>
                            <td><?php echo $row["statusType"]; ?></td>
                        </tr>
                        <?php
                    }
                }
                else {
                    ?>
                    <tr>
                        <td><a href="/coverPages_add.php?edit=47">47</a></td>
                        <td><a href="/liftingTests.php?edit=47" class="btn btn-primary">Bewerken</a></td>
                        <td><a href="/cableChecklists.php?edit=47" class="btn btn-primary">Bewerken</a></td>
                        <td>21-02-2020</td>
                        <td>Open</td>
                    </tr>
                    <?php
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