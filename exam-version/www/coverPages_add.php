<?php

session_start();

if (isset($_SESSION["user_id"])) {
    require __DIR__ . "/db.php";
    require __DIR__ . "/template/header.php";

    $coverPagesID = "new";
    $TCVTNumber = "";
    $inspectionDate = "";
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
    $signOutBefore = "";
    $elucidation = "";
    $workInstruction = "";
    $cableSupplier = "";
    $observations = "";
    $operatingHours = "";
    $discardReason = "";

    if (isset($_GET["edit"])) {
        $coverPagesID = $_GET["edit"];
        $query = "SELECT coverPagesID, TCVTNumber, inspectionDate, executor, specialist, crainSetup, executionTowerHookHeight, boomType, telescopicBoomParts, constructionBoomMeters, jibBoomMeters, flyJibParts, BoomLength, topable, trolley, adjustableBoom, stampsType, shortcomings, signOutBefore, elucidation, workInstruction, cableSupplier, observations, operatingHours, discardReason FROM `coverPages` WHERE coverPagesID = '$coverPagesID'";
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
    }

    ?>
    
    <a href="/" class="btn btn-primary coverPages">Terug naar overzigt</a>

    <div class="content-container">
        <form action="coverPages_add.submit.php" method="POST">
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
                    <p><label for="#">Topbaar</label> <input type="checkbox" class="form-control" name="topable" <?php echo $topable; ?>></p>
                    <p><label for="#">Loopkat</label> <input type="checkbox" class="form-control" name="trolley" <?php echo $trolley; ?>></p>
                    <p><label for="#">Verstelbare giek</label> <input type="checkbox" class="form-control" name="adjustableBoom" <?php echo $adjustableBoom; ?>></p>
                    <p><label for="#">Soort stempels</label> <input type="checkbox" class="form-control" name="stampsType" <?php echo $stampsType; ?>></p>
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
                        <textarea rows="10" name="elucidation" class="form-control"><?php echo $elucidation; ?></textarea>
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