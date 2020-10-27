const crypto = require("crypto");

module.exports = (hash) => {
    return crypto.createHash("sha512").update(hash).digest("hex");
}