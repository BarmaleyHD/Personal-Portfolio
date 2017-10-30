function checkreset(){
   return confirm("do you realy want to reset the form");    
}

function validate(myform){
    var message = "";
    if (myform.fname.value == "") {
        message += "First name needs a value\n";
    }
    if (myform.lname.value == "") {
        message += "Last name needs a value\n";
    }
    if (message != "") {
        //alert(message);
        document.getElementById("error").innerHTML = message;
        return false;
    } else {
        document.getElementById("error").innerHTML = "";
        return confirm("Want to continue...?");
    }
}


        