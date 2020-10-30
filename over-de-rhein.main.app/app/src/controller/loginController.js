const Login = require("../model/Login");

exports.loginView = (req, res) => {
    if (req.session.login === undefined) {
        res.render("login", { layout: false });
    }
    else {
        res.render("orders", { headTitle: "Over de rhein" });
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

    var test = new Login(username, password);

    test.get_userdata((error, data, fields) => {
        req.session.login = data[0].userID;
        res.redirect("/");
    }, (error, data, fields) => {
        res.render("login", { layout: false });
    });
}