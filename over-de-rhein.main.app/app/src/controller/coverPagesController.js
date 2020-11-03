exports.addView = (req, res) => {
    if (req.session.login === undefined) {
        res.redirect("/");
    }
    else {
        res.render("coverPages/add", { headTitle: "Over de rhein", topTitle: "Voorbald keuringsrapport: Toevoegen" });
    }
}

exports.editView = (req, res) => {
    if (req.session.login === undefined) {
        res.redirect("/");
    }
    else {
        res.render("coverPages/add", {
            headTitle: "Over de rhein", topTitle: "Voorbald keuringsrapport: Bewerken (47)",

            TCVTNumber: 48,
            inspectionDate: "Keuringsdatum",
            executor: "Uitvoerder",
            specialist: "Deskundige",
            crainSetup: "Opstelling kraan",
            executionTowerHookHeight: 5,
            boomType: "Soort giek",
            telescopicBoomParts: 66,
            constructionBoomMeters: 44,
            jibBoomMeters: 77,
            flyJibParts: 3,
            BoomLength: 54,
            topable: 43,
            trolley: "checked",
            adjustableBoom: "checked",
            stampsType: 7,
            shortcomings_yes: "checked",
            shortcomings_no: "",
            signOutBefore: "2019-11-25",
            elucidation: "Geen",
            workInstruction: "geen werk instructie",
            cableSupplier: "Dell",
            observations: "Geen",
            operatingHours: 5,
            discardReason: "Aflef redenen",
        });
    }
}