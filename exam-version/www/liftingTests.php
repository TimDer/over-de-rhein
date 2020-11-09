<?php

if (!isset($_GET["edit"])) {
    header("Location: coverPages.php");
}

session_start();

if (isset($_SESSION["user_id"])) {
    require __DIR__ . "/template/header.php";
    
    $dateDrawn = "";
    $mainBoomLength = "";
    $mechSectionBoomLength = "";
    //$ = "";
    $jibBoomLength = "";
    $hoistingCablePartsAmount = "";

    $swingAngle = "";
    $ownMassBallast = "";
    $permissibleOperatingLoad = "";
    $lbmInEffect = "";
    $testLoad = "";
    $Agreed = "";

    ?>
    
    <a href="/" class="btn btn-primary coverPages">Terug naar overzigt</a>

    <div class="content-container">
        <form action="#" method="post">
            <div class="row">
                <div class="col-lg">
                    <p><label for="">Datum opgesteld</label> <input type="date" name="" min="0" max="99" class="form-control" value="<?php echo $dateDrawn; ?>"></p>
                    <p><label for="">Hoofdgiek lengte</label> <input type="number" name="" min="0" max="99" class="form-control" value="<?php echo $dateDrawn; ?>"></p>
                    <p><label for="">Mech sectie gieklengte</label> <input type="number" min="0" max="99" name="" class="form-control" value="<?php echo $dateDrawn; ?>"></p>
                    <p><label for="">Hulpgiek lengte</label> <input type="number" min="0" max="99" name="" class="form-control" value="69"></p>
                    <p><label for="">Hoofdgiek giekhoek</label> <input type="number" min="0" max="99" name="" class="form-control" value="<?php echo $dateDrawn; ?>"></p>
                    <p><label for="">Heiskabel aantal parten</label> <input type="number" min="0" name="" class="form-control" value="<?php echo $dateDrawn; ?>"></p>
                </div>
                <div class="col-lg">
                    <p><label for="">Zwenkhoek</label> <input type="number" min="0" max="99" name="" class="form-control" value="<?php echo $dateDrawn; ?>"></p>
                    <p><label for="">Eigen massa balast</label> <input type="number" name="" min="0" max="99" class="form-control" value="<?php echo $dateDrawn; ?>"></p>
                    <p><label for="">Toelaatbare bedrijfslast</label> <input type="number" name="" min="0" max="99" class="form-control" value="<?php echo $dateDrawn; ?>"></p>
                    <p><label for="">LMB in werking</label> <input type="number" name="" min="0" max="99" class="form-control" value="<?php echo $dateDrawn; ?>"></p>
                    <p><label for="">Proeflast</label> <input type="number" name="" min="0" max="99" class="form-control" value="<?php echo $dateDrawn; ?>"></p>
                    <p><label for="">Akkoord</label> <input type="checkbox" name="" class="form-control" <?php echo $dateDrawn; ?>></p>
                    <p><input type="submit" value="Opslaan" class="btn btn-success btn-block liftingTests-submit"></p>
                </div>
            </div>
        </form>
    </div>

    <?php require __DIR__ . "/template/footer.php";
}
else {
    // not logged in
    header("Location: login.php");
}