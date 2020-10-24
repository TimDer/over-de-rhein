const express = require("express");
const router = express.Router();

const mainPublicRouter = require(`${__dirname}/public/mainPublicRouter`);

const loginController = require(`${__dirname}/../controller/loginController`);

router.get("/", loginController.loginView);
router.post("/", loginController.loginSubmit);

router.use("/public", mainPublicRouter);

module.exports = router;