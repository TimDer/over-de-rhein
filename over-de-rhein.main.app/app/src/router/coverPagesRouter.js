const express = require("express");
const router = express.Router();

const coverPagesController = require("../controller/coverPagesController");

router.use("/add", coverPagesController.addView);

router.get("/edit/:edit", coverPagesController.editView);

module.exports = router;