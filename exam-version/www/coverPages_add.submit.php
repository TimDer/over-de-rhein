<?php

session_start();

if (isset($_SESSION["user_id"])) {
    require_once __DIR__ . "/classes/database.class.php";
    
    // determine rather to "INSERT" or to "UPDATE"
    $coverPagesID = ($_POST["coverPagesID"] === "new") ? "new" : $_POST["coverPagesID"];
    $processSubdata = $coverPagesID;

    // set keys and values
    $coverPageArray = array(
        "TCVTNumber"                => $_POST["TCVTNumber"],
        "userID"                    => $_SESSION["user_id"],
        "coverPageStatusID"         => 1,
        "inspectionDate"            => $_POST["inspectionDate"],
        "executor"                  => $_POST["executor"],
        "specialist"                => $_POST["specialist"],
        "crainSetup"                => $_POST["crainSetup"],
        "executionTowerHookHeight"  => $_POST["executionTowerHookHeight"],
        "boomType"                  => $_POST["boomType"],
        "telescopicBoomParts"       => $_POST["telescopicBoomParts"],
        "constructionBoomMeters"    => $_POST["constructionBoomMeters"],
        "jibBoomMeters"             => $_POST["jibBoomMeters"],
        "flyJibParts"               => $_POST["flyJibParts"],
        "BoomLength"                => $_POST["BoomLength"],
        "topable"                   => (isset($_POST["topable"]))        ? 1 : 0,
        "trolley"                   => (isset($_POST["trolley"]))        ? 1 : 0,
        "adjustableBoom"            => (isset($_POST["adjustableBoom"])) ? 1 : 0,
        "stampsType"                => (isset($_POST["stampsType"]))     ? 1 : 0,
        "shortcomings"              => (isset($_POST["shortcomings"]))   ? 1 : 0,
        "signOutBefore"             => $_POST["signOutBefore"],
        "elucidation"               => $_POST["elucidation"],
        "workInstruction"           => $_POST["workInstruction"],
        "cableSupplier"             => $_POST["cableSupplier"],
        "observations"              => $_POST["observations"],
        "operatingHours"            => $_POST["operatingHours"],
        "discardReason"             => $_POST["discardReason"]
    );

    // array to sql query
    if ($coverPagesID === "new") {
        // insert
        $coverPageQuery = database::insert($coverPageArray, "coverPages");
    }
    else {
        // update
        $coverPageQuery = database::update($coverPageArray, "coverPages", array("coverPagesID" => $coverPagesID), array("userID"));
    }

    // make query to datebase
    if ($_GET["type"] === "test" OR $_GET["type"] === "cable") {
        if (database::query($coverPageQuery) !== true) {
            header("Location: error.php");
        }
    }

    $coverPagesID = (isset($conn->insert_id) AND is_numeric($conn->insert_id)) ? $conn->insert_id : $coverPagesID;

    // process cover page subdata
    require __DIR__ . "/inc/processCoverPageSubdata.inc.php";    
}
else {
    // not logged in
    header("Location: login.php");
}