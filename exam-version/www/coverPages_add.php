<?php

session_start();

if (isset($_SESSION["user_id"])) {
    require __DIR__ . "/db.php";

    $coverPagesID = "new";
    $TCVTNumber = "";
    $inspectionDate = date("Y-m-d", time());
    $executor = "";
    $specialist = "";
    $crainSetup = "";
    $executionTowerHookHeight = "";
    $boomType = "";
    $telescopicBoomParts = "";
    $constructionBoomMeters = "";
    $jibBoomMeters = "";
    $flyJibParts = "";
    $BoomLength = "";
    $topable = "";
    $trolley = "";
    $adjustableBoom = "";
    $stampsType = "";
    $shortcomings_yes = "";
    $shortcomings_no = "";
    $signOutBefore = date("Y-m-d", time());
    $elucidation = "";
    $workInstruction = "";
    $cableSupplier = "";
    $observations = "";
    $operatingHours = "";
    $discardReason = "";

    if (isset($_GET["edit"])) {
        $coverPagesID = (int)mysqli_real_escape_string($conn, $_GET["edit"]);
        $query = "SELECT `coverPages`.`coverPagesID`, `coverPages`.`userID`, `coverPageStatus`.`statusType`, `coverPageStatus`.`coverPageStatusID`, `coverPages`.`TCVTNumber`, `coverPages`.`inspectionDate`, `coverPages`.`executor`, `coverPages`.`specialist`, `coverPages`.`crainSetup`, `coverPages`.`executionTowerHookHeight`, `coverPages`.`boomType`, `coverPages`.`telescopicBoomParts`, `coverPages`.`constructionBoomMeters`, `coverPages`.`jibBoomMeters`, `coverPages`.`flyJibParts`, `coverPages`.`BoomLength`, `coverPages`.`topable`, `coverPages`.`trolley`, `coverPages`.`adjustableBoom`, `coverPages`.`stampsType`, `coverPages`.`shortcomings`, `coverPages`.`signOutBefore`, `coverPages`.`elucidation`, `coverPages`.`workInstruction`, `coverPages`.`cableSupplier`, `coverPages`.`observations`, `coverPages`.`operatingHours`, `coverPages`.`discardReason`, ";
        // FROM `coverPages`
        if ($_GET["type"] === "cable") {
            $query .= "`cableChecklists`.`cableDamage_6D`, `cableChecklists`.`cableDamage_30D`, `cableChecklists`.`outsideCableDamage`, `cableChecklists`.`rust`, `cableChecklists`.`reducedCableDiameter`, `cableChecklists`.`measuringPoints`, `cableChecklists`.`totalDamage`, `cableChecklists`.`damageRustType` FROM `coverPages` INNER JOIN `cableChecklists` ON `coverPages`.`coverPagesID` = `cableChecklists`.`coverPagesID`";
        }
        elseif ($_GET["type"] === "test") {
            $query .= "`liftingTests`.`dateDrawn`, `liftingTests`.`mainBoomLength`, `liftingTests`.`mechSectionBoomLength`, `liftingTests`.`auxiliaryBoomLength`, `liftingTests`.`jibBoomLength`, `liftingTests`.`hoistingCablePartsAmount`, `liftingTests`.`swingAngle`, `liftingTests`.`ownMassBallast`, `liftingTests`.`permissibleOperatingLoad`, `liftingTests`.`lbmInEffect`, `liftingTests`.`testLoad`, `liftingTests`.`Agreed` FROM `coverPages` INNER JOIN `liftingTests` ON `coverPages`.`coverPagesID` = `liftingTests`.`coverPagesID`";
        }
        $query .= " LEFT JOIN `coverPageStatus` ON `coverPages`.`coverPageStatusID` = `coverPageStatus`.`coverPageStatusID`";
        $query .= " WHERE `coverPages`.`coverPagesID` = '$coverPagesID'";
        $result = mysqli_query($conn, $query);
        if ($result->num_rows > 0) {
            while ($row = $result->fetch_assoc()) {
                foreach ($row AS $key => $value) {
                    $$key = $value;
                }
                $shortcomings_yes   = ((int)$row["shortcomings"] === 1) ? "checked" : "";
                $shortcomings_no    = ((int)$row["shortcomings"] === 0) ? "checked" : "";
                
                $topable            = ($row["topable"] === "1")         ? "checked" : "";
                $trolley            = ($row["trolley"] === "1")         ? "checked" : "";
                $adjustableBoom     = ($row["adjustableBoom"] === "1")  ? "checked" : "";
                $stampsType         = ($row["stampsType"] === "1")      ? "checked" : "";
            }
        }
        else {
            header("Location: error.php");
        }
    }

    require __DIR__ . "/template/header.php";

    ?>
    
    <a href="/" class="btn btn-primary coverPages">Terug naar overzigt</a>

    <div class="content-container">
        <form action="coverPages_add.submit.php?type=<?php echo $_GET["type"]; ?>" method="POST">
            <div class="row">
                <div class="col-lg">
                    <p><label for="#">TCVT Nummer</label> <input type="number" min="0" class="form-control" name="TCVTNumber" value="<?php echo $TCVTNumber; ?>"></p>
                    <p><label for="#">Keuringsdatum</label> <input type="date" class="form-control" name="inspectionDate" value="<?php echo date("Y-m-d", strtotime($inspectionDate)); ?>"></p>
                    <p><label for="#">Uitvoerder</label> <input type="text" class="form-control" name="executor" value="<?php echo $executor; ?>"></p>
                    <p><label for="#">Deskundige</label> <input type="text" class="form-control" name="specialist" value="<?php echo $specialist; ?>"></p>
                    <p><label for="#">Opstelling kraan</label> <input type="text" class="form-control" name="crainSetup" value="<?php echo $crainSetup; ?>"></p>
                    <p><label for="#">Uitvoering toren haakhoogte</label> <input type="text" name="executionTowerHookHeight" class="form-control" value="<?php echo $executionTowerHookHeight; ?>"></p>
                    <p><label for="#">Soort giek</label> <input type="text" class="form-control" name="boomType" value="<?php echo $boomType; ?>"></p>
                    <p><label for="#">Teleskoopgiek delen</label> <input type="number" class="form-control" name="telescopicBoomParts" value="<?php echo $telescopicBoomParts; ?>"></p>
                    <p><label for="#">Opbouwgiek meters</label> <input type="number" class="form-control" name="constructionBoomMeters" value="<?php echo $constructionBoomMeters; ?>"></p>
                    <p><label for="#">hulpgiek meters</label> <input type="number" class="form-control" name="jibBoomMeters" value="<?php echo $jibBoomMeters; ?>"></p>
                    <p><label for="#">Fly jib delen</label> <input type="number" class="form-control" name="flyJibParts" value="<?php echo $flyJibParts; ?>"></p>
                    <p><label for="#">Gieklengte</label> <input type="number" class="form-control" name="BoomLength" value="<?php echo $BoomLength; ?>"></p>
                </div>
                <div class="col-lg">
                    <div class="row">
                        <div class="col-lg">
                            <p><label for="#">Topbaar</label> <input type="checkbox" class="form-control" name="topable" <?php echo $topable; ?>></p>
                        </div>
                        <div class="col-lg">
                            <p><label for="#">Loopkat</label> <input type="checkbox" class="form-control" name="trolley" <?php echo $trolley; ?>></p>
                        </div>
                        <div class="col-lg">
                        <p><label for="#">Verstelbare_giek</label> <input type="checkbox" class="form-control" name="adjustableBoom" <?php echo $adjustableBoom; ?>></p>
                        </div>
                        <div class="col-lg">
                            <p><label for="#">Soort_stempels</label> <input type="checkbox" class="form-control" name="stampsType" <?php echo $stampsType; ?>></p>
                        </div>
                    </div>
                    <p>
                        <label for="#">Tekortkomingen</label>
                        <div class="row">
                            <div class="col">
                                <p>Ja: <input type="radio" name="shortcomings" class="form-control" value="1" <?php echo $shortcomings_yes; ?>></p>
                            </div>
                            <div class="col">
                                <p>Nee: <input type="radio" name="shortcomings" class="form-control" value="0" <?php echo $shortcomings_no; ?>></p>
                            </div>
                        </div>
                    </p>
                    <p><label for="#">Afgemeeld voor</label> <input type="date" class="form-control" name="signOutBefore" value="<?php echo date("Y-m-d", strtotime($signOutBefore)); ?>"></p>
                    <p>
                        <label for="#">Toelichting</label>
                        <textarea name="elucidation" class="form-control elucidation"><?php echo $elucidation; ?></textarea>
                    </p>
                    <p><label for="#">Werkinstructie</label> <input type="text" class="form-control" name="workInstruction" value="<?php echo $workInstruction; ?>"></p>
                    <p><label for="#">Kabelleverancier</label> <input type="text" class="form-control" name="cableSupplier" value="<?php echo $cableSupplier; ?>"></p>
                    <p><label for="#">Waarmemingen</label> <input type="text" class="form-control" name="observations" value="<?php echo $observations; ?>"></p>
                    <p></p>
                    <p><label for="#">Aantal bedrijfsuren</label> <input type="number" min="0" class="form-control" name="operatingHours" value="<?php echo $operatingHours; ?>"></p>
                    <p><label for="#">Aflef redenen</label> <input type="text" class="form-control" name="discardReason" value="<?php echo $discardReason; ?>"></p>

                    

                    <input type="hidden" name="coverPagesID" value="<?php echo $coverPagesID; ?>">
                </div>
            </div>

            <?php
            if (isset($_GET["type"]) AND $_GET["type"] === "cable") {
                require __DIR__ . "/template/cableChecklists.php";
            }
            elseif (isset($_GET["type"]) AND $_GET["type"] === "test") {
                require __DIR__ . "/template/liftingTests.php";
            }
            ?>

            <input type="submit" value="Opslaan" class="btn btn-success btn-block">
        </form>
    </div>

    <?php
    require __DIR__ . "/template/footer.php";
}
else {
    // not logged in
    header("Location: login.php");
}