exports.liftingTestView = (req, res) => {
    if (req.session.login === undefined) {
        res.redirect("/");
    }
    else {
        res.render("liftingTests", { headTitle: "Over de rhein", topTitle: "Hijstabel: 47" });
    }
}