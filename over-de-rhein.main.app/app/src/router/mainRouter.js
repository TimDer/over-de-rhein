const express = require("express");
const router = express.Router();

const loginController = require(`${__dirname}/../controller/loginController`);

router.get("/", loginController.loginView)

module.exports = router;