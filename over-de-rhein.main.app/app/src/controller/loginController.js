exports.loginView = (req, res) => {
    res.render("login", { layout: false });
}

exports.loginSubmit = (req, res) => {
    const body = req.body;

    
}