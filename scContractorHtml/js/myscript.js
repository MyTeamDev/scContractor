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
    return res;
}

function AddLink(link){
    var url = document.getElementById("inputLink").value;
    var link = { link: url, token: token }
    ///////////////////////////   check exist if link;    
    if(true){
        $.post("http://localhost:57231/api/values", link, function(result){
            //console.log(200);
        });
    };
}

function FeelTableLinks(listLinks){
    listLinks.forEach(element=>{
        $("#TableLinks").append("<div class='divTableBody'>")
                            .append("<div class='divTableRow'>")
                            .append("<div class='divTableCell'>"+element.TargetLink+"</div>")
                            .append("<div class='divTableCell'>"+element.CreateDate+"</div>")
                            .append("<div class='divTableCell'>"+element.RequestCount+"</div>")
                            .append("</div></div>");                  
    });
}

if(!localStorage.getItem("token")){ GetToken() }
var token = localStorage.getItem("token");
var listLinks = GetAllLinks(token);
FeelTableLinks(listLinks);



