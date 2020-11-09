<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="/public/bootstrap/css/bootstrap.min.css">
    <link rel="stylesheet" href="/public/login.min.css">
    <title>Inloggen bij over de rhein</title>
</head>
<body>
    <form action="/login.submit.php" method="POST" class="login-container">
        <h1>Inloggen bij Over de Rhein</h1>
        <input type="text" name="username" placeholder="Gebruikersnaam..." required>
        <input type="password" name="password" placeholder="Wachtwoord..." required>
        <input type="submit" value="Login">
    </form>
</body>
</html>