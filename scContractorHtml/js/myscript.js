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
           });;
        },
    });
    return res;
}
if(!localStorage.getItem("token")){ GetToken() }
var token = localStorage.getItem("token");
var listLinks = GetAllLinks(token);
console.log(listLinks.length);

