<?php

class users {
    public $salt = "";

    public function create_password_salt($min, $max) {
        $randomString   = "abcdefghijklmnopqrstuvwxyz-ABCDEFGHIJKLMNOPQRSTUVWXYZ_0123456789=!@#$%^&*()+:><.,";
        $salt = "";

        $randomLength = rand($min, $max);

        for ($x = 1; $x <= $randomLength; $x++) {
            $salt .= $randomString[rand(0, strlen($randomString)-1)];
        }
        
        $this->salt = $salt;
    }
}