var token = Document.cookie;
function GetTokenFromCookie()
{
    console.log(Document.cookie);
    var cookieString = Document.cookie;
    console.log(cookieString);
    if(!cookieString){
        var z = $.ajax({
            url: "http://localhost:57231/api/reg",        
            dataType: "jsonp", 

            success: function( response ) {
                token = response; // server response
                //Document.cookie = token;
                console.log(response);
            }                    
        });
    }
    console.log(z);
    //var cookieArr = cookieString.split(';');
    //alert(cookieArr[0]);
}

var token = GetTokenFromCookie();
