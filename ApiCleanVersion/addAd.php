<?php
$owner = filter_input(INPUT_POST, "owner");
$address = filter_input(INPUT_POST, "address");       
$url = "http://apiconnection.cloudapp.net/Service1.svc?singleWsdl";     
$client = new SoapClient($url);
$information = $address . "." . $owner;
$client->__soapCall("AddAdvertisment", array( 
    "AddAdvertismentResponse" => array("addressOwner" => $information)));
header('Location: ../ApiCleanVersion/adminMainPage.php');