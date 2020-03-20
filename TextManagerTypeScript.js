//"use strict";
//exports.__esModule = true;
var counter = 0;
var Div = /** @class */ (function () {
    function Div() {
    }
    return Div;
}());
var divs = [new Div, new Div, new Div, new Div, new Div, new Div, new Div, new Div, new Div, new Div, new Div, new Div, new Div, new Div, new Div, new Div, new Div, new Div, new Div, new Div];
//divs: Array<Div>();
function AddTextTS(selectText) {
    //ivi Div= new Div();
    var divi = divs[counter];
    divi.ID = counter;
    divi.div = document.createElement("div");
    divi.textfiel = document.createElement("p");
    divi.deleateButton = document.createElement("button");
    divi.createButton = document.createElement("button");
    console.log(counter + ' addText ' + selectText);
    var parentDiv = document.getElementById("ParentDiv");
    // var div = document.createElement("div");
    divi.div.id = "div" + counter;
    //  var textBox = document.createElement("p");
    divi.textfiel.id = "textdiv" + counter;
    var text = document.createTextNode(selectText);
    var umbruch = document.createElement("br");
    //  var buttonWork = document.createElement("button");
    divi.createButton.textContent = 'Edit';
    divi.createButton.setAttribute('onclick', 'EditDivTS(' + counter + ')');
    //   var buttonDelete = document.createElement("button");
    divi.deleateButton.textContent = 'Delete';
    divi.deleateButton.id = "DeleteButtondiv" + counter;
    ;
    divi.deleateButton.setAttribute('onclick', 'DeleteDivTS(' + counter + ')');
    counter++;
    console.log(divs[counter]);
    divi.textfiel.appendChild(text);
    divi.div.appendChild(divi.createButton);
    divi.div.appendChild(divi.deleateButton);
    divi.div.appendChild(umbruch);
    divi.div.appendChild(divi.textfiel);
    parentDiv.appendChild(divi.div);
}
function EditDivTS(ID) {
    console.log('EditDiv ' + ID);
    divs[ID].inputfield = document.createElement("INPUT");
    divs[ID].inputfield.id = 'inputfield' + ID;
    divs[ID].inputfield.setAttribute("type", "text");
    divs[ID].div.appendChild(divs[ID].inputfield);
    divs[ID].deleateButton.setAttribute('onclick', 'EditTextTS("' + ID + '")');
    divs[ID].deleateButton.textContent = 'Save new text';
}
function EditTextTS(ID) {
    console.log('EditText ' + ID);
    divs[ID].deleateButton.textContent = 'Delete';
    divs[ID].deleateButton.setAttribute('onclick', 'DeleteDivTS(' + ID + ')');
    divs[ID].textfiel.textContent = divs[ID].inputfield.nodeValue;
    divs[ID].div.removeChild(divs[ID].inputfield);
}
function DeleteDivTS(ID) {
    console.log('deleteDiv ' + ID);
    var parentDiv = document.getElementById("ParentDiv");
    parentDiv.removeChild(divs[ID].div);
}
