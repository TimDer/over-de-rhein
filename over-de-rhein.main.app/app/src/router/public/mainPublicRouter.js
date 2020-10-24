const express = require("express");
const router = express.Router();
const path = require("path");

router.use("/", express.static(path.resolve(__dirname, "../../wwwroot")));
router.use("/jquery", express.static(path.resolve(__dirname, "../../../node_modules/jquery/dist")));
router.use("/bootstrap", express.static(path.resolve(__dirname, "../../../node_modules/bootstrap/dist")));

module.exports = router;