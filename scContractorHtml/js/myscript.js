function GetToken(){
        $.ajax({
            url: "http://localhost:57231/api/reg",        
            dataType: "json", 
            success: function( response ) {
                token = "tkn"+response["token"]; // server response
                localStorage.setItem("token", token);
            },
        });
    }
function GetAllLinks(token){
    var url = "http://localhost:57231/api/values/" + token;
    var res = [];
    $.ajax({
        url: url,        
        dataType: "json", 
        async:false,
        success: function( response ) {
           response.forEach(element => {
               res.push(element);
           });
        },
    });
    return res;s
}
var z = 1;
function AddLink(link){
    var link = document.getElementById("inputLink").value;
    var XML = new XMLWriter();
    console.log(data);
    ///////////////////////////   check exist if link;    
    if(true){
        var request = new XMLHttpRequest();
        request.open("POST", "http://localhost:57231/api/values");
        request.setRequestHeader('Content-Type', 'application/xml');
        request.send(data);
    };
}

if(!localStorage.getItem("token")){ GetToken() }
var token = localStorage.getItem("token");
var listLinks = GetAllLinks(token);


