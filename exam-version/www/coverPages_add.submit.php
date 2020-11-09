<?php

/*
























*/

session_start();

if (isset($_SESSION["user_id"])) {
    require __DIR__ . "/db.php";

    class submit {
        public static $post_var = array();

        // get the data
        public static function setVars($post) {
            if (isset($post['shortcomings_yes'])) {
                $post["shortcomings"] = 1
            }
            else {
                $post["shortcomings"] = 0
            }

            unset($post["shortcomings_yes"]);
            unset($post["shortcomings_no"]);

            foreach ($post AS $key => $value) {
                self::$post_var[$key] = mysqli_real_escape_string($conn, $value);
            }
        }

        public static function update() {
            return "";
        }

        public static function insert() {
            // array to var
            foreach (self::$post_var AS $key => $value) {
                $new_key = mysqli_real_escape_string($conn, $key);
                $$new_key = $value
            }
            
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
                                                `operatingHours`,           `discardReason`)
                                        VALUES ()";
        }

        public static function run($query) {}
    }

    submit::setVars($_POST);
    if (isset($_GET["update"])) {
        submit::run(submit::update());
    }
    else {
        submit::run(submit::insert());
    }
}
else {
    // not logged in
    header("Location: login.php");
}