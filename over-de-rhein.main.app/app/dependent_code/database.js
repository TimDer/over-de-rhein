const mysql = require('mysql');
const env = process.env;
const conVars = {
    host:     env.DBHost,
    user:     env.DBUsername,
    password: env.DBPassword,
    database: env.DBName,
    waitForConnections: true
}

const conn = mysql.createConnection(conVars);
conn.connect();
module.exports = conn;