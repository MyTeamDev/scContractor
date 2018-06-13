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
    var res = $.ajax({
        url: url,        
        dataType: "json", 
        success: function( response ) {
            return response;
        },
    });
    return res;
}

if(!localStorage.getItem("token")){ GetToken() }
var token = localStorage.getItem("token");
var listLinks = GetAllLinks(token);
