<?php

if (isset($_SESSION["user_id"])) {
    if (!isset($result)) {
        $dateDrawn = date("Y-m-d", time());
        $mainBoomLength = "0";
        $mechSectionBoomLength = "0";
        $auxiliaryBoomLength = "0";
        $jibBoomLength = "0";
        $hoistingCablePartsAmount = "0";

        $swingAngle = "0";
        $ownMassBallast = "0";
        $permissibleOperatingLoad = "0";
        $lbmInEffect = "0";
        $testLoad = "0";
        $Agreed = "";
    }
    else {
        $Agreed = (((int)$Agreed) === 1) ? "checked" : "";
    }

    ?>
    
    <div class="row">
        <div class="col-lg">
            <p><label for="">Datum opgesteld</label> <input type="date" name="dateDrawn" min="0" max="99" class="form-control" value="<?php echo $dateDrawn; ?>"></p>
            <p><label for="">Hoofdgiek lengte</label> <input type="number" name="mainBoomLength" min="0" max="99" class="form-control" value="<?php echo $mainBoomLength; ?>"></p>
            <p><label for="">Mech sectie gieklengte</label> <input type="number" min="0" max="99" name="mechSectionBoomLength" class="form-control" value="<?php echo $mechSectionBoomLength; ?>"></p>
            <p><label for="">Hulpgiek lengte</label> <input type="number" min="0" max="99" name="auxiliaryBoomLength" class="form-control" value="<?php echo $auxiliaryBoomLength; ?>"></p>
            <p><label for="">Hoofdgiek giekhoek</label> <input type="number" min="0" max="99" name="jibBoomLength" class="form-control" value="<?php echo $jibBoomLength; ?>"></p>
            <p><label for="">Heiskabel aantal parten</label> <input type="number" min="0" name="hoistingCablePartsAmount" class="form-control" value="<?php echo $hoistingCablePartsAmount; ?>"></p>
        </div>
        <div class="col-lg">
            <p><label for="">Zwenkhoek</label> <input type="number" min="0" max="99" name="swingAngle" class="form-control" value="<?php echo $swingAngle; ?>"></p>
            <p><label for="">Eigen massa balast</label> <input type="number" name="ownMassBallast" min="0" max="99" class="form-control" value="<?php echo $ownMassBallast; ?>"></p>
            <p><label for="">Toelaatbare bedrijfslast</label> <input type="number" name="permissibleOperatingLoad" min="0" max="99" class="form-control" value="<?php echo $permissibleOperatingLoad; ?>"></p>
            <p><label for="">LMB in werking</label> <input type="number" name="lbmInEffect" min="0" max="99" class="form-control" value="<?php echo $lbmInEffect; ?>"></p>
            <p><label for="">Proeflast</label> <input type="number" name="testLoad" min="0" max="99" class="form-control" value="<?php echo $testLoad; ?>"></p>
            <p><label for="">Akkoord</label> <input type="checkbox" name="Agreed" class="form-control" <?php echo $Agreed; ?>></p>
        </div>
    </div>

    <?php
}
else {
    // not logged in
    header("Location: ../login.php");
}