<?php

if (isset($_SESSION["user_id"])) {
    if ($_GET["type"] === "test") {
        // lifting tests
        $table = "liftingTests";
        $processSubdataArray = array(
            "userID" => $_SESSION["user_id"],
            "coverPagesID" => $coverPagesID,
            "dateDrawn" => $_POST["dateDrawn"],
            "mainBoomLength" => $_POST["mainBoomLength"],
            "mechSectionBoomLength" => $_POST["mechSectionBoomLength"],
            "auxiliaryBoomLength" => $_POST["auxiliaryBoomLength"],
            "jibBoomLength" => $_POST["jibBoomLength"],
            "hoistingCablePartsAmount" => $_POST["hoistingCablePartsAmount"],
            "swingAngle" => $_POST["swingAngle"],
            "ownMassBallast" => $_POST["ownMassBallast"],
            "permissibleOperatingLoad" => $_POST["permissibleOperatingLoad"],
            "lbmInEffect" => $_POST["lbmInEffect"],
            "testLoad" => $_POST["testLoad"],
            "Agreed" => (isset($_POST["Agreed"])) ? 1 : 0
        );
    }
    elseif ($_GET["type"] === "cable") {
        // cable
        $table = "cableChecklists";
        $processSubdataArray = array(
            "userID" => $_SESSION["user_id"],
            "coverPagesID" => $coverPagesID,
            "cableDamage_6D" => $_POST["cableDamage_6D"],
            "cableDamage_30D" => $_POST["cableDamage_30D"],
            "outsideCableDamage" => $_POST["outsideCableDamage"],
            "rust" => $_POST["rust"],
            "reducedCableDiameter" => $_POST["reducedCableDiameter"],
            "measuringPoints" => $_POST["measuringPoints"],
            "totalDamage" => $_POST["totalDamage"],
            "damageRustType" => $_POST["damageRustType"]
        );
    }

    // query the data
    if ($coverPagesID !== "new") {
        // array to query
        if ($processSubdata === "new") {
            $processSubdataQuery = database::insert($processSubdataArray, $table);
        }
        else {
            $processSubdataQuery = database::update($processSubdataArray, $table, array("coverPagesID" => $coverPagesID), array("userID"));
        }

        // query to the database
        $sql = database::query($processSubdataQuery);
        if ($sql !== true) {
            // if error
            header("Location: error.php");
        }
        else {
            // done get back to coverPages.php
            header("Location: coverPages.php");
        }
    }
}
else {
    // not logged in
    header("Location: login.php");
}