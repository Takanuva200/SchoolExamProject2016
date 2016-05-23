<html>
    <head>
        <meta charset="UTF-8">
        <title>Administrator main page</title>
    </head>
    <body>
        <h1>Administrator's panel</h1>
        <form action='pageMovement.php' method='post'><input type='submit' name="submit" value="Log out"></form>    
        <h3>List of available functions</h3>
        <?php
        $url = "http://apiconnection.cloudapp.net/Service1.svc?singleWsdl";     
        $client = new SoapClient($url);
        $result = $client->__getFunctions();
        foreach($result as $function){
            print_r($function);
            echo "<br>";
        }      
        ?>
        <br><br>
        <h3>Ads Table</h3>
        <table>
            <tr>
                <th>Owner</th>
                <th>Address</th>
                <th>Expiration Date</th>
                <th>Delete</th>               
                <th>New Owner</th>
                <th>New Address</th>
                <th>Update</th>
            </tr>            
            <?php
            $idCounter = 0;
            $result = $client->GetAllAds();
            // Self generated table rows with the content of the advertisements
            foreach($result->GetAllAdsResult->Ads as $adsResult){
                        echo "<tr>";
                        echo "<td>";
                        print_r($adsResult->Owner);
                        echo "</td>";
                        echo "<td>";
                        print_r($adsResult->Address);
                        echo "</td>";
                        echo "<td>";
                        print_r($adsResult->dateOfExpire);
                        echo "</td>";
                        
                        echo "<form action='deleteAd.php' method='post'>";
                        echo "<input type='number' value='" . $idCounter . "'name='id' hidden>";
                        echo "<td> <input type='submit' value='Delete'></td>";
                        echo "</form>";
                        
                        echo "<form action='updateAd.php' method='post'>";
                        echo "<input type='number' value='" . $idCounter . "'name='id2' hidden>";
                        echo '<td><input type="string" name="newOwner"></td>';
                        echo '<td><input type="string" name="newAddress"></td>';
                        echo "<input type='number' value='" . $idCounter . "'name='id' hidden>";
                        echo "<td> <input type='submit' value='Update'></td>"; 
                        echo "</form>";
                        echo "</tr>"; 
                        $idCounter++;
                        
            }
            ?>
        </table> 
        <br><br>
        <h3> Add an advertisement</h3>
        <form action="addAd.php" method="post">
            Owner: <input type="string" name="owner">
             <br>
             Address: <input type="string" name="address">
             <br>   
             <input type="submit" name="submit2">
        </form>     
    </body>
</html>
