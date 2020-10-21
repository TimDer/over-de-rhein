const express   = require("express");
const exphbs    = require("express-handlebars");
const router    = require("./router/mainRouter");
const app       = express();

app.engine('handlebars', exphbs());
app.set('view engine', 'handlebars');
app.set("views", "./src/view");

app.use("/", router);

app.listen(3001, () => console.log("Listening on: http://localhost:3001"));