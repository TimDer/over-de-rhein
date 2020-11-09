<?php

session_start();

if (isset($_SESSION["user_id"])) {
    require __DIR__ . "/template/header.php";

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

    ?>
    
    <a href="/" class="btn btn-primary coverPages">Terug naar overzigt</a>

    <div class="content-container">
        <form action="#" method="POST">
            <div class="row">
                <div class="col-lg">
                    <p><label for="#">TCVT Nummer</label> <input type="number" min="0" class="form-control" value="<?php echo $TCVTNumber; ?>"></p>
                    <p><label for="#">Keuringsdatum</label> <input type="text" class="form-control" value="<?php echo $inspectionDate; ?>"></p>
                    <p><label for="#">Uitvoerder</label> <input type="text" class="form-control" value="<?php echo $executor; ?>"></p>
                    <p><label for="#">Deskundige</label> <input type="text" class="form-control" value="<?php echo $specialist; ?>"></p>
                    <p><label for="#">Opstelling kraan</label> <input type="text" class="form-control" value="<?php echo $crainSetup; ?>"></p>
                    <p><label for="#">Uitvoering toren haakhoogte</label> <input type="text" class="form-control" value="<?php echo $executionTowerHookHeight; ?>"></p>
                    <p><label for="#">Soort giek</label> <input type="text" class="form-control" value="<?php echo $boomType; ?>"></p>
                    <p><label for="#">Teleskoopgiek delen</label> <input type="number" class="form-control" value="<?php echo $telescopicBoomParts; ?>"></p>
                    <p><label for="#">Opbouwgiek meters</label> <input type="number" class="form-control" value="<?php echo $constructionBoomMeters; ?>"></p>
                    <p><label for="#">hulpgiek meters</label> <input type="number" class="form-control" value="<?php echo $jibBoomMeters; ?>"></p>
                    <p><label for="#">Fly jib delen</label> <input type="number" class="form-control" value="<?php echo $flyJibParts; ?>"></p>
                    <p><label for="#">Gieklengte</label> <input type="number" class="form-control" value="<?php echo $BoomLength; ?>"></p>
                </div>
                <div class="col-lg">
                    <p><label for="#">Topbaar</label> <input type="checkbox" class="form-control" <?php echo $topable; ?>></p>
                    <p><label for="#">Loopkat</label> <input type="checkbox" class="form-control" <?php echo $trolley; ?>></p>
                    <p><label for="#">Verstelbare giek</label> <input type="checkbox" class="form-control" <?php echo $adjustableBoom; ?>></p>
                    <p><label for="#">Soort stempels</label> <input type="checkbox" class="form-control" <?php echo $stampsType; ?>></p>
                    <p>
                        <label for="#">Tekortkomingen</label>
                        <div class="row">
                            <div class="col">
                                <p>Ja: <input type="radio" name="shortcomings" class="form-control" <?php echo $shortcomings_yes; ?>></p>
                            </div>
                            <div class="col">
                                <p>Nee: <input type="radio" name="shortcomings" class="form-control" <?php echo $shortcomings_no; ?>></p>
                            </div>
                        </div>
                    </p>
                    <p><label for="#">Afgemeeld voor</label> <input type="date" class="form-control" value="<?php echo $signOutBefore; ?>"></p>
                    <p>
                        <label for="#">Toelichting</label>
                        <textarea name="" rows="10" class="form-control"><?php echo $elucidation; ?></textarea>
                    </p>
                    <p><label for="#">Werkinstructie</label> <input type="text" class="form-control" value="<?php echo $workInstruction; ?>"></p>
                    <p><label for="#">Kabelleverancier</label> <input type="text" class="form-control" value="<?php echo $cableSupplier; ?>"></p>
                    <p><label for="#">Waarmemingen</label> <input type="text" class="form-control" value="<?php echo $observations; ?>"></p>
                    <p></p>
                    <p><label for="#">Aantal bedrijfsuren</label> <input type="number" min="0" class="form-control" value="<?php echo $operatingHours; ?>"></p>
                    <p><label for="#">Aflef redenen</label> <input type="text" class="form-control" value="<?php echo $discardReason; ?>"></p>
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