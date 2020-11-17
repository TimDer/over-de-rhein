<?php

session_start();

if (isset($_SESSION["user_id"])) {
    require __DIR__ . "/db.php";
    require __DIR__ . "/template/header.php"; ?>
    
    <a href="/coverPages_add.php?type=test" class="btn btn-primary coverPages">Een Hijs-test toevoegen</a>
    <a href="/coverPages_add.php?type=cable" class="btn btn-primary coverPages">Een Kabel-check-lijst toevoegen</a>
    
    <div class="content-container">
        <div class="row">
            <div class="col">
                <h1>Hijs-testen</h1>
                <table class="table">
                    <thead>
                        <tr>
                            <th>Actie</th>
                            <th>Datum</th>
                            <th>Status</th>
                        </tr>
                    </thead>
                    <tbody>
                        <?php
                        /*$query = "SELECT coverPages.coverPagesID, coverPages.inspectionDate, coverPageStatus.statusType FROM `coverPages` INNER JOIN coverPageStatus ON coverPages.coverPageStatusID=coverPageStatus.coverPageStatusID";
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
                        else {*/
                            ?>
                            <tr>
                                <td><a href="/coverPages_add.php?edit=47&type=test" class="btn btn-primary">Bewerk: 47</a></td>
                                <td>21-02-2020</td>
                                <td>Open</td>
                            </tr>
                            <?php
                        //}
                        ?>
                    </tbody>
                </table>
            </div>
            <div class="col">
                <h1>Kabel-check-lijst</h1>
                <table class="table">
                    <thead>
                        <tr>
                            <th>Actie</th>
                            <th>Datum</th>
                            <th>Status</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td><a href="/coverPages_add.php?edit=47&type=cable" class="btn btn-primary">Bewerk: 48</a></td>
                            <td>22-02-2020</td>
                            <td>Open</td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>

    <?php require __DIR__ . "/template/footer.php";
}
else {
    // not logged in
    header("Location: login.php");
}