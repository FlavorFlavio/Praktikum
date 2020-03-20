export{}
var counter=0;

class Div{
ID:number;
div:Element;
textfiel:Element
deleateButton:Element
createButton:Element
editButton:Element
inputfield:Element

}

let divs: Div[] = [new Div,new Div,new Div,new Div,new Div,new Div,new Div,new Div,new Div,new Div,new Div,new Div,new Div,new Div,new Div,new Div,new Div,new Div,new Div,new Div]; 
 //divs: Array<Div>();


function AddTextTS(selectText:string){
   //ivi Div= new Div();
let divi= divs[counter];
divi.ID=counter;
divi.div = document.createElement("div");
divi.textfiel = document.createElement("p");
divi.deleateButton = document.createElement("button");
divi.createButton = document.createElement("button");
    
    console.log(counter+' addText '+selectText);

    var parentDiv = document.getElementById("ParentDiv");
    
   // var div = document.createElement("div");
   divi.div.id= "div"+counter;
    
    //  var textBox = document.createElement("p");
    divi.textfiel.id="textdiv"+counter;
     var text = document.createTextNode(selectText);
      var umbruch = document.createElement("br");

    //  var buttonWork = document.createElement("button");
    divi.createButton.textContent='Edit';
    divi.createButton.setAttribute('onclick', 'EditDivTS('+counter+'))')
      
   //   var buttonDelete = document.createElement("button");
   divi.deleateButton.textContent='Delete';
   divi.deleateButton.id= "DeleteButtondiv"+counter;;
   divi.deleateButton.setAttribute('onclick', 'DeleteDivTS('+counter+'))')

      counter++;
console.log(divs[counter]);
      divi.textfiel.appendChild(text);
      divi.div .appendChild(divi.createButton);
      divi.div .appendChild(divi.deleateButton);
      divi.div .appendChild(umbruch);
      divi.div .appendChild(divi.textfiel);
      parentDiv.appendChild(divi.div );

}


function EditDivTS(ID:number){
    console.log('EditDiv '+ID);
    
divs[ID].inputfield= document.createElement("INPUT");
divs[ID].inputfield.id= 'inputfield'+ ID;
divs[ID].inputfield.setAttribute("type", "text");
divs[ID].div.appendChild(divs[ID].inputfield);
divs[ID].deleateButton.setAttribute('onclick', 'EditTextTS("'+ID+'")')
divs[ID].deleateButton.textContent= 'Save new text';
}
function EditTextTS(ID:number){
    
    console.log('EditText '+ID);
    
    

    
    divs[ID].deleateButton.textContent= 'Delete';
    divs[ID].deleateButton.setAttribute('onclick', 'DeleteDivTS('+ID+')')
    
   
    divs[ID].textfiel.textContent=divs[ID].inputfield.nodeValue;

    divs[ID].div.removeChild(divs[ID].inputfield);
}

function DeleteDivTS(ID:number){
    console.log('deleteDiv '+ID);
    
    var  parentDiv= document.getElementById("ParentDiv");
    parentDiv.removeChild(divs[ID].div);
}