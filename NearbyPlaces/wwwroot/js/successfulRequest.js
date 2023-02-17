//create connection
var connectionRequestCount = new signalR.HubConnectionBuilder().withUrl("/hubs/requestCount").configureLogging(signalR.LogLevel.Information).build();


//connect to methodes that hub invokes aka receive notifications from hub
connectionRequestCount.on("updateTotalSuccessfulRequests", (value) =>{
    var newCountSpan = document.getElementById("totalSuccessfulRequestsCounter");
    newCountSpan.innerText = value.toString();

})


//invoke hub methodes aka send notification to hub
function newSuccessfulRequestOnClient(){
    connectionRequestCount.send("NewSuccessfullRequest");

}


//start connection
function fulfilled() {
    console.log("Connection to RequestHub Successful");
    //newSuccessfulRequestOnClient();
    

}


function rejected() {

}


 connectionRequestCount.start().then(fulfilled, rejected);