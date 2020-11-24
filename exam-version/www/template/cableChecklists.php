<?php

if (isset($_SESSION["user_id"])) {
    if (!isset($result)) {
        $cableDamage_6D = "0";
        $cableDamage_30D = "0";
        $outsideCableDamage = "0";
        $rust = "0";
        $reducedCableDiameter = "0";
        $measuringPoints = "0";
        $totalDamage = "0";
        $damageRustType = "0";
    }
    
    ?>
    <div class="row">
        <div class="col-lg">
            <p><label for="">Draadbreuk 6 dagen</label> <input type="number" name="cableDamage_6D" class="form-control" value="<?php echo $cableDamage_6D; ?>"></p>
            <p><label for="">Draadbreuk 30 dagen</label> <input type="number" name="cableDamage_30D" class="form-control" value="<?php echo $cableDamage_30D; ?>"></p>
            <p><label for="">Beschadiging buitenzijde</label> <input type="number" name="outsideCableDamage" class="form-control" value="<?php echo $outsideCableDamage; ?>"></p>
            <p><label for="">Beschadiging roest corrosie</label> <input type="number" name="rust" class="form-control" value="<?php echo $rust; ?>"></p>
        </div>
        <div class="col-lg">
            <p><label for="">Verminderde kabeldiameter</label> <input type="number" name="reducedCableDiameter" class="form-control" value="<?php echo $reducedCableDiameter; ?>"></p>
            <p><label for="">Positie meetpunten</label> <input type="number" name="measuringPoints" class="form-control" value="<?php echo $measuringPoints; ?>"></p>
            <p><label for="">Beschadiging totaal</label> <input type="number" name="totalDamage" class="form-control" value="<?php echo $totalDamage; ?>"></p>
            <p><label for="">Type Beschadiging roest</label> <input type="number" name="damageRustType" class="form-control" value="<?php echo $damageRustType; ?>"></p>
        </div>
    </div>

    <?php
}
else {
    // not logged in
    header("Location: login.php");
}