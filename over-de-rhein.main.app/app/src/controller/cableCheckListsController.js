exports.cableCheckListsView = (req, res) => {
    if (req.session.login === undefined) {
        res.redirect("/");
    }
    else {
        res.render("cableChecklists", {
            headTitle: "Over de rhein", topTitle: "Kabelchecklist: 47",

            cableDamage_6D: 3,
            cableDamage_30D: 567,
            outsideCableDamage: 5567,
            rust: 57,
            reducedCableDiameter: 243,
            measuringPoints: 3345,
            totalDamage: 56,
            damageRustType: 23,
        });
    }
}