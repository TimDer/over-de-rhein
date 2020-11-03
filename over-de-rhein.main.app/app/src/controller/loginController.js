const Login = require("../model/Login");

exports.loginView = (req, res) => {
    // escape the login form during development
    if (process.env.LOGIN_DEV === "dev") {
        req.session.login = "random value";
    }

    // check if the user is logedin
    if (req.session.login === undefined) {
        res.render("login", { layout: false });
    }
    else {
        res.render("coverPages", { headTitle: "Over de rhein", topTitle: "Over de Rhein: Opdrachten" });
    }
}

exports.logout = (req, res) => {
    req.session.login = undefined;
    res.redirect("/");
}

exports.loginSubmit = (req, res) => {
    const body = req.body;

    const username = body.username;
    const password = body.password;

    let test = new Login(username, password);

    test.get_userdata((error, data, fields) => {
        req.session.login = data[0].userID;
        res.redirect("/");
    }, (error, data, fields) => {
        res.render("login", { layout: false });
    });
}