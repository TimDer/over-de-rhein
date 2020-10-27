const express   = require("express");
const session   = require("express-session");
const exphbs    = require("express-handlebars");
const router    = require("./router/mainRouter");
const random    = require("random-string");
const app       = express();

const secretKey = random({
    length: 2000,
    special: true,
    numeric: true,
    letters: true,
});

app.engine('handlebars', exphbs());
app.set('view engine', 'handlebars');
app.set("views", "./src/view");
app.use(express.urlencoded({ extended: false }));
app.use(session({
    secret: secretKey,
    resave: false,
    saveUninitialized: false
}));

app.use("/", router);

app.listen(parseInt( process.env.port ), () => console.log("Listening on: http://localhost:3001"));