export{}
var counter=0;

class Div{
ID:number;
isEditEnabled:boolean;
div:Element;
textfiel:HTMLInputElement;
Color:HTMLInputElement;
deleateButton:Element
createButton:Element
editButton:Element
inputfield:HTMLInputElement
InputfielLable:HTMLInputElement
}



let divs: Div[] = [new Div,new Div,new Div,new Div,new Div,new Div,new Div,new Div,new Div,new Div,new Div,new Div,new Div,new Div,new Div,new Div,new Div,new Div,new Div,new Div]; 

function AddTextTS(selectText:string){

let divi= divs[counter];
divi.ID=counter;
divi.div = document.createElement("div");
divi.div.setAttribute("class", "newdiv");
   
divi.textfiel =(<HTMLInputElement> document.createElement("p"));
divi.deleateButton = document.createElement("button");

divi.deleateButton.setAttribute("class", "deletebutton");
divi.createButton = document.createElement("button");
    
divi.createButton.setAttribute("class", "editbutton");
    console.log(counter+' addText '+selectText);

    var parentDiv = document.getElementById("ParentDiv");
   divi.div.id= "div"+counter;
    divi.textfiel.id="textdiv"+counter;
     var text = document.createTextNode(selectText);
      var umbruch = document.createElement("br");
    divi.createButton.textContent='Edit';
    divi.createButton.setAttribute('onclick', 'EditDivTS('+counter+')')
   divi.deleateButton.textContent='Delete';
   divi.deleateButton.id= "DeleteButtondiv"+counter;;
   divi.deleateButton.setAttribute('onclick', 'DeleteDivTS('+counter+')')

    
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
    if(!divs[ID].isEditEnabled){
divs[ID].inputfield= (<HTMLInputElement> document.createElement("INPUT"));
divs[ID].inputfield.setAttribute("class", "editinputfield");
divs[ID].inputfield.id= 'inputfield'+ ID;
divs[ID].inputfield.setAttribute("type", "text");


divs[ID].InputfielLable=  (<HTMLInputElement>document.createElement("LABEL"));
divs[ID].InputfielLable.setAttribute("for","inputfield"+ID);
divs[ID].InputfielLable.textContent="New Text: ";

CreateDropdown(ID);

        
        divs[ID].div.appendChild(divs[ID].InputfielLable);
        
        divs[ID].InputfielLable.appendChild(divs[ID].inputfield);

//divs[ID].div.appendChild(divs[ID].inputfield);
divs[ID].deleateButton.setAttribute('onclick', 'EditTextTS("'+ID+'")')
divs[ID].deleateButton.setAttribute("class", "savebutton");
divs[ID].deleateButton.textContent= 'Save';
divs[ID].isEditEnabled=true;
    }
 
}
function CreateDropdown(ID){
    
    var color = ["Red","Green","Blue","Yellow"];
    divs[ID].Color =  (<HTMLInputElement>document.createElement("SELECT"));
    divs[ID].Color.id = "Color"+ID;
    divs[ID].Color.setAttribute("for","inputfield"+ID);
    divs[ID].InputfielLable.appendChild(divs[ID].Color);
    for (var i = 0; i < color.length; i++) {
        var option = document.createElement("option");
        option.value = color[i];
        option.text = color[i];
        divs[ID].Color.appendChild(option);
        
        
    }
   }
function EditTextTS(ID:number){
    
    console.log('EditText '+ID); 
    divs[ID].deleateButton.textContent= 'Delete';
    divs[ID].deleateButton.setAttribute("class", "deletebutton");
    divs[ID].deleateButton.setAttribute('onclick', 'DeleteDivTS('+ID+')')
    divs[ID].textfiel.textContent=divs[ID].inputfield.value;
    divs[ID].textfiel.style.color=  divs[ID].Color.value;

    divs[ID].div.removeChild(divs[ID].InputfielLable);
    divs[ID].isEditEnabled=false;
}

function DeleteDivTS(ID:number){
    console.log('deleteDiv '+ID);
    var  parentDiv= document.getElementById("ParentDiv");
    parentDiv.removeChild(divs[ID].div);
}