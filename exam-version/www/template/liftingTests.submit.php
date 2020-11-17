<?php

session_start();

if (isset($_SESSION["user_id"])) {
    require __DIR__ . "/db.php";

    class submit {
        public static $post_var = array();

        public static function setVars($post) {
            global $conn;
            foreach ($post AS $key => $value) {
                self::$post_var[$key] = mysqli_real_escape_string($conn, $value);
            }

            if (isset($post["Agreed"])) {
                self::$post_var["Agreed"] = 1;
            }
            else {
                self::$post_var["Agreed"] = 0;
            }
        }

        public static function insert() {
            // INSERT INTO `table` (`key`) VALUES ('value')

            $query_setup = "INSERT INTO `liftingTests` (";
            $value_setup = "";

            $number_start = 0;
            $number_stop = count(self::$post_var) - 1;
            foreach (self::$post_var AS $key => $value) {
                if ($key !== "liftingTestsID") {
                    if ($number_start === $number_stop) {
                        // last round
                        $query_setup .= "`" . $key . "`";
                        $value_setup .= "'" . $value . "'";
                    }
                    else {
                        // the rest
                        $query_setup .= "`" . $key . "`,";
                        $value_setup .= "'" . $value . "',";
                    }
                }
                $number_start = $number_start + 1;
            }

            $query_setup .= ", `userID`) VALUES (" . $value_setup . ", '" . $_SESSION["user_id"] . "')";

            return $query_setup;
        }

        public static function update() {
            // UPDATE `table` SET `key`='value' WHERE `id`='number'
        }

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
    if ($_POST["liftingTestsID"] === "new") {
        // add
        submit::run(submit::insert());
    }
    else {
        // update
        submit::run(submit::update());
    }
}
else {
    // not logged in
    header("Location: login.php");
}