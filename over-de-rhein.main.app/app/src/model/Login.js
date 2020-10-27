const conn = require("../../dependent_code/database");
const sha512 = require("../../dependent_code/sha512");

class Login {
    // class constructor
    constructor (User, Pass) {
        this.username = User;
        this.password = Pass;
    }

    // Check if the user password is the same as the password in the database
    check_user_data(ifTrue, ifFalse, error, data, fields) {
        if (data === undefined || data.length == 0) {
            ifFalse(error, data, fields);
        }
        else {
            const password_input = sha512(this.password + data[0].passwordSalt);
            if (password_input === data[0].password) {
                ifTrue(error, data, fields);
            }
            else {
                ifFalse(error, data, fields);
            }
        }
    }

    // Get user form the database
    get_userdata(ifTrue, ifFalse) {
        conn.query(
            "SELECT `users`.`userID`, `users`.`userName`, `users`.`password`, `users`.`passwordSalt`, `userType`.`type` FROM users INNER JOIN userType ON users.userTypeID=userType.userTypeID WHERE users.userName = ?",
            [this.username],
            (error, data, fields) => {
                this.check_user_data(ifTrue, ifFalse, error, data, fields);
            }
        );
    }
}

module.exports = Login;