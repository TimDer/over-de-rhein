<?php

require_once __DIR__ . "/../db.php";

class database {
    // escape data functions
    private static function escapeReal($conn, $array) {
        // setup return array
        $return = array();

        // loop and escape
        foreach ($array AS $key => $value) {
            if (!is_array($value)) {
                // if data then escape the data
                $return[$key] = mysqli_real_escape_string($conn, $value);
            }
            else {
                // if array then loop through the array
                $return[$key] = self::escapeReal($conn, $value);
            }
        }

        // return escaped array
        return $return;
    }
    public static function escape(array $array) {
        // get database connection var
        global $conn;

        // return escaped data
        return self::escapeReal($conn, $array);
    }

    // make a query to the database
    public static function query(string $query) {
        // get the connection var
        global $conn;
        if (mysqli_query($conn, $query)) {
            // return true if done
            return true;
        }
        else {
            // return the error
            return mysqli_error($conn);
        }
    }

    // genarate an "INSERT INTO" query
    public static function insert(array $array, string $tableName, array $skipKey = array()) {
        // INSERT INTO `table` (`key`) VALUES ('value')

        // get the connection var 
        global $conn;

        // escape the data
        $tableNameEscape = mysqli_real_escape_string($conn, $tableName);
        $arrayEscape = self::escape($array);

        // setup the query string
        $query_setup = "INSERT INTO `$tableNameEscape` (";
        $value_setup = "";

        // Keys to query string and values to "value_setup" var
        $number_start = 0;
        $number_stop = count($arrayEscape) - 1;
        foreach ($arrayEscape AS $key => $value) {
            if (!in_array($key, $skipKey)) {
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

        // "value_setup" var to query string
        $query_setup .= ") VALUES (" . $value_setup . ")";

        // return the query string
        return $query_setup;
    }

    // genarate an "UPDATE" query
    public static function update(array $array, string $tableName, $where, array $skipKey = array()) {
        // UPDATE `table` SET `key`='value' WHERE `id`='value'

        // get the connection var
        global $conn;

        // escape the data
        $tableNameEscape = mysqli_real_escape_string($conn, $tableName);
        $arrayEscape = self::escape($array);
        $whereEscape = self::escape($where);

        // setup the query string
        $query_setup = "UPDATE `$tableNameEscape` SET ";

        // data to query string
        $number_start = 0;
        $number_stop = count($arrayEscape) - 1;
        foreach ($arrayEscape AS $key => $value) {
            // determine rather or not to skip a specific key
            if (!in_array($key, $skipKey)) {
                if ($number_start === $number_stop) {
                    // last round
                    $query_setup .= "`" . $key . "`='" . $value . "'";
                }
                else {
                    // the rest
                    $query_setup .= "`" . $key . "`='" . $value . "',";
                }
            }
            $number_start = $number_start + 1;
        }

        // "WHERE clause" to query string
        if (is_array($whereEscape)) {
            $query_setup .= " WHERE ";
            $number_start = 0;
            $number_stop = count($whereEscape) - 1;
            foreach ($whereEscape AS $key => $value) {
                if (!in_array($key, $skipKey)) {
                    if ($number_start === $number_stop) {
                        // last round
                        $query_setup .= "`" . $key . "`='" . $value . "'";
                    }
                    else {
                        // the rest
                        $query_setup .= "`" . $key . "`='" . $value . "', AND ";
                    }
                }
                $number_start = $number_start + 1;
            }
        }
        elseif (is_string($whereEscape)) {
            $query_setup .= " WHERE " . $whereEscape;
        }

        // return the query string
        return $query_setup;
    }
}