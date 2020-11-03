const express = require("express");
const router = express.Router();

/* ============================== Login ============================== */
const loginController = require(`${__dirname}/../controller/loginController`);

router.get("/", loginController.loginView);
router.get("/logout", loginController.logout);
router.post("/", loginController.loginSubmit);
/* ============================== /Login ============================== */


/* ============================== Public router (For files like css, js etc) ============================== */
const mainPublicRouter = require(`${__dirname}/public/mainPublicRouter`);

router.use("/public", mainPublicRouter);
/* ============================== /Public router (For files like css, js etc) ============================== */


/* ============================== coverPages routes ============================== */
const coverPagesRouter = require(`${__dirname}/coverPagesRouter`);

router.use("/coverPages", coverPagesRouter);
/* ============================== /coverPages routes ============================== */


/* ============================== liftingTests routes ============================== */
const liftingTestsController = require(`${__dirname}/../controller/liftingTestsController`);

router.get("/lifting-tests/edit/:edit", liftingTestsController.liftingTestView);
/* ============================== /liftingTests routes ============================== */

/* ============================== cable-check-lists ============================== */
const cableCheckListsController = require("../controller/cableCheckListsController");

router.get("/cable-check-lists/edit/:edit", cableCheckListsController.cableCheckListsView);
/* ============================== cable-check-lists ============================== */


// 404
router.use(function (req, res) {
    res.redirect("/");
});

module.exports = router;