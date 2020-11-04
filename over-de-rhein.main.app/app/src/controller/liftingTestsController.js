exports.liftingTestView = (req, res) => {
    if (req.session.login === undefined) {
        res.redirect("/");
    }
    else {
        res.render("liftingTests", {
            headTitle: "Over de rhein", topTitle: "Hijstabel: 47",
            
            dateDrawn: "2019-11-25",
            mainBoomLength: 45,
            mechSectionBoomLength: 32,

            jibBoomLength: 84,
            hoistingCablePartsAmount: 463,
            swingAngle: 11,
            ownMassBallast: 31,
            permissibleOperatingLoad: 55,
            lbmInEffect: 47,
            testLoad: 03,
            Agreed: "",
        });
    }
}