<?php

session_start();

if (isset($_SESSION["user_id"])) {
    require __DIR__ . "/db.php";

    class submit {
        public static $post_var = array();

        // get the data
        public static function setVars($post) {
            global $conn;
            foreach ($post AS $key => $value) {
                $to_post_var = mysqli_real_escape_string($conn, $value);
                self::$post_var[$key] = (is_numeric($to_post_var)) ? (int)$to_post_var : $to_post_var;
            }

            self::$post_var["topable"]          = (isset($post["topable"]))         ? 1 : 0;
            self::$post_var["trolley"]          = (isset($post["trolley"]))         ? 1 : 0;
            self::$post_var["adjustableBoom"]   = (isset($post["adjustableBoom"]))  ? 1 : 0;
            self::$post_var["stampsType"]       = (isset($post["stampsType"]))      ? 1 : 0;
        }

        // update the data
        public static function update() {
            foreach (self::$post_var AS $key => $value) {
                $$key = (is_numeric($value)) ? (int)$value : $value;
            }

            $user_id = $_SESSION["user_id"];

            return "UPDATE `coverPages` SET `TCVTNumber`='$TCVTNumber',                         `inspectionDate`='$inspectionDate',
                                            `executor`='$executor',                             `specialist`='$specialist',
                                            `crainSetup`='$crainSetup',                         `executionTowerHookHeight`='$executionTowerHookHeight',
                                            `boomType`='$boomType',                             `telescopicBoomParts`='$telescopicBoomParts',
                                            `constructionBoomMeters`='$constructionBoomMeters', `jibBoomMeters`='$jibBoomMeters',
                                            `flyJibParts`='$flyJibParts',                       `BoomLength`='$BoomLength',
                                            `topable`='$topable',                               `trolley`='$trolley',
                                            `adjustableBoom`='$adjustableBoom',                 `stampsType`='$stampsType',
                                            `shortcomings`='$shortcomings',                     `signOutBefore`='$signOutBefore',
                                            `elucidation`='$elucidation',                       `workInstruction`='$workInstruction',
                                            `cableSupplier`='$cableSupplier',                   `observations`='$observations',
                                            `operatingHours`='$operatingHours',                 `discardReason`='$discardReason'
                                            WHERE `coverPagesID`='$coverPagesID'";
        }

        // insert the data
        public static function insert() {
            // array to var
            foreach (self::$post_var AS $key => $value) {
                $$key = (is_numeric($value)) ? (int)$value : $value;
            }

            $user_id = $_SESSION["user_id"];
            
            return "INSERT INTO `coverPages` (`TCVTNumber`,                 `inspectionDate`,
                                                `executor`,                 `specialist`,
                                                `crainSetup`,               `executionTowerHookHeight`,
                                                `boomType`,                 `telescopicBoomParts`,
                                                `constructionBoomMeters`,   `jibBoomMeters`,
                                                `flyJibParts`,              `BoomLength`,
                                                `topable`,                  `trolley`,
                                                `adjustableBoom`,           `stampsType`,
                                                `shortcomings`,             `signOutBefore`,
                                                `elucidation`,              `workInstruction`,
                                                `cableSupplier`,            `observations`,
                                                `operatingHours`,           `discardReason`,
                                                
                                                `userID`,                   `coverPageStatusID`)
                                        VALUES ('$TCVTNumber',              '$inspectionDate',
                                                '$executor',                '$specialist',
                                                '$crainSetup',              '$executionTowerHookHeight',
                                                '$boomType',                '$telescopicBoomParts',
                                                '$constructionBoomMeters',  '$jibBoomMeters',
                                                '$flyJibParts',             '$BoomLength',
                                                '$topable',                 '$trolley',
                                                '$adjustableBoom',          '$stampsType',
                                                '$shortcomings',            '$signOutBefore',
                                                '$elucidation',             '$workInstruction',
                                                '$cableSupplier',           '$observations',
                                                '$operatingHours',          '$discardReason',
                                                
                                                '$user_id',                 '1')";
        }

        // run query
        public static function run($query) {
            global $conn;
            if (mysqli_query($conn, $query)) {
                header("Location: coverPages.php");
            }
            else {
                var_dump(mysqli_error($conn));
            }
        }
    }

    submit::setVars($_POST);
    if ($_POST["coverPagesID"] === "new") {
        submit::run(submit::insert());
    }
    else {
        submit::run(submit::update());
    }
}
else {
    // not logged in
    header("Location: login.php");
}