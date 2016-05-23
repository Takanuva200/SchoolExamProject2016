<?php
$testId = $_POST['id2'];
$newOwner = filter_input(INPUT_POST, "newOwner");
$newAddress = filter_input(INPUT_POST, "newAddress");
$url = "http://apiconnection.cloudapp.net/Service1.svc?singleWsdl";     
$client = new SoapClient($url);
$result = $client->GetAdID();
$result2 = $client->GetAllAds();
$randomCounter = 0;
$counter = 0;
foreach($result->GetAdIDResult->int as $individual){
    if($randomCounter == $testId){
        $client->__soapCall("UpdateAdvertisment", array( 
    "UpdateAdvertismentResponse" => array("id" => $individual, "address" => $newAddress, "owner" => $newOwner)));
header('Location: ../ApiCleanVersion/adminMainPage.php');

        }
        $randomCounter++;
    }
