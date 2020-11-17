<?php

session_start();

if (isset($_SESSION["user_id"])) {
    $cableDamage_6D = "";
    $cableDamage_30D = "";
    $outsideCableDamage = "";
    $rust = "";
    $reducedCableDiameter = "";
    $measuringPoints = "";
    $totalDamage = "";
    $damageRustType = "";
    
    ?>
    <div class="row">
        <div class="col-lg">
            <p><label for="">Draadbreuk 6 dagen</label> <input type="number" name="" class="form-control" value="<?php echo $cableDamage_6D; ?>"></p>
            <p><label for="">Draadbreuk 30 dagen</label> <input type="number" name="" class="form-control" value="<?php echo $cableDamage_30D; ?>"></p>
            <p><label for="">Beschadiging buitenzijde</label> <input type="number" name="" class="form-control" value="<?php echo $outsideCableDamage; ?>"></p>
            <p><label for="">Beschadiging roest corrosie</label> <input type="number" name="" class="form-control" value="<?php echo $rust; ?>"></p>
        </div>
        <div class="col-lg">
            <p><label for="">Verminderde kabeldiameter</label> <input type="number" name="" class="form-control" value="<?php echo $reducedCableDiameter; ?>"></p>
            <p><label for="">Positie meetpunten</label> <input type="number" name="" class="form-control" value="<?php echo $measuringPoints; ?>"></p>
            <p><label for="">Beschadiging totaal</label> <input type="number" name="" class="form-control" value="<?php echo $totalDamage; ?>"></p>
            <p><label for="">Type Beschadiging roest</label> <input type="number" name="" class="form-control" value="<?php echo $damageRustType; ?>"></p>
        </div>
    </div>

    <?php
}
else {
    // not logged in
    header("Location: login.php");
}