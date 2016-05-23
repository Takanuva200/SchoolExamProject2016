<html>
    <head>
        <meta charset="UTF-8">
        <title>Login and Registration</title>
    </head>
    <body>
        <form action="<?php echo $_SERVER['PHP_SELF']; ?>" method="post">
             Username: <input type="string" name="username">
             <br>
             Password: <input type="password" name="password">
             <br>             
             <input type="submit" name="submit">
        </form>
    </body>
</html>
<?php
if(isset($_POST['submit']))
{
        $username = filter_input(INPUT_POST, "username");
        $password = filter_input(INPUT_POST, "password");
        $accounts = explode("/",file_get_contents("Accounts.txt"));
        foreach ($accounts as $account){    
            $anAccount = explode(";",$account);       
            $fileUsername = $anAccount[0];         
            $filePassword = $anAccount[1];  
            if ($fileUsername == $username && $filePassword == $password){      
                switch ($anAccount[2]){        
                    case admin:             
                        header('Location: adminMainPage.php');              
                        break;           
                    case client:              
                        header('Location: clientMainPage.php');
                        break;
                        default:              
                            echo "New issue";          
                            break;     
                        }   
                }            
        }
        echo "Wrong username or password";
}
?>