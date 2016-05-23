<?php
$testId = $_POST['id'];
$url = "http://apiconnection.cloudapp.net/Service1.svc?singleWsdl";     
        $client = new SoapClient($url);
$result = $client->GetAdID();

$randomCounter = 0;
foreach($result->GetAdIDResult->int as $individual){
    if($randomCounter == $testId){
        $client->__soapCall("DeleteSpecificAd", array("DeleteSpecificAdResponse" => array("id" => $individual)));
header("Location: ../ApiCleanVersion/adminMainPage.php");
    }
    $randomCounter++;
}
            
?>