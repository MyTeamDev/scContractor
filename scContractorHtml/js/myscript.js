var token;
var listLinks;
function GetToken(){
        $.ajax({
            url: "http://localhost:57231/api/reg",                
            dataType: "json",
            async:false,
            success: function( response ) {
                token = "tkn"+response["token"]; // server response
                localStorage.setItem("token", token);
            },
            error: function(response){
                console.log(response);
            }
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
    document.getElementById("inputLink").value = "";
    var link = { link: url, token: token }
    ///////////////////////////   check exist if link;    
    if(true){
        $.post("http://localhost:57231/api/values", link, function(result){
            UpdateTableLinks();
        });
    };
}

function copyToClipboard(val){
    val = "http://localhost:57231/api/redirect/"+val;
    var dummy = document.createElement("input");
    document.body.appendChild(dummy);     
    dummy.setAttribute("id", "dummy_id");  
    document.getElementById("dummy_id").value=val;
    dummy.select();       
    document.execCommand("copy");
    document.body.removeChild(dummy);
}

function AddZero(i){
    if(i < 10)
    {
        return "0"+i;
    }
    else
    {
        return i;
    }
}

function timeConverter(UNIX_timestamp){
    var a = new Date(UNIX_timestamp * 1000);
    var months = ['Jan','Feb','Mar','Apr','May','Jun','Jul','Aug','Sep','Oct','Nov','Dec'];
    var year = a.getFullYear();
    var month = months[a.getMonth()];
    var date = AddZero(a.getDate());
    var hour = AddZero(a.getHours());
    var min = AddZero(a.getMinutes());
    var sec = AddZero(a.getSeconds());
    var time = date + ' ' + month + ' ' + year + ' ' + hour + ':' + min + ':' + sec ;
    return time;
  }  

function UpdateTableLinks(){
    var parent = null;
    var parent = document.getElementById("idDivTableBody");
    console.log(parent.childNodes.length);
    for(var i = 0; i < parent.childNodes.length; ){
        //console.log(parent.childNodes);
        parent.removeChild(parent.childNodes[i]);
    }
    Work();
}
function RemoveLinks(link){
    console.log("http://localhost:57231/api/delete/"+link);
    $.get( "http://localhost:57231/api/delete/"+link,
        function(data) {
           //console.log("Link " + link + " was delete");
           UpdateTableLinks()
        }
    );
}
function FeelTableLinks(listLinks){
    $("#TableLinks").append("<div class='divTableBody' id='idDivTableBody'>")
    listLinks.forEach(element=>{        //add new links to table
        if((element.TargetLink).length>30){
        element.TargetLink = (element.TargetLink).substring(0,70);
        element.TargetLink = element.TargetLink+" ..."
        }
        $("#idDivTableBody").append("<div class='divTableRow'> \
                            <div class='divTableCell'><a href='http://localhost:57231/api/redirect/"+element.RequestLink+"'>"+element.TargetLink+"</a></div> \
                            <div class='divTableCell'><a onclick=copyToClipboard('"+element.RequestLink+"')><img src='https://www.mywed.tk/nextcloud/index.php/s/paYcSoJtCoSHy5b/preview'></a></div> \
                            <div class='divTableCell'>"+timeConverter(element.CreateDate)+"</div> \
                            <div class='divTableCell'>"+element.RequestCount+"</div> \
                            <div class='divTableCell'><a onclick=RemoveLinks('"+element.RequestLink+"')><img src='https://www.mywed.tk/nextcloud/index.php/s/4rB3oeL4CgETsKt/preview'></a></div>");
        $("#idDivTableBody").append("</div>");                
    });
    $("#TableLinks").append("</div>")  
}

if(!localStorage.getItem("token")){ GetToken() }
function Work(){

    token = localStorage.getItem("token");
    listLinks = GetAllLinks(token);
    FeelTableLinks(listLinks);
};
Work();

