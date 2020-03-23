
var counter=0;
function AddText(string){
    console.log(counter+' addText '+string);

    var parentDiv = document.getElementById("ParentDiv");
    
    var div = document.createElement("div");
    div.id= "div"+counter;
    
      var textBox = document.createElement("p");
      textBox.id="textdiv"+counter;
      var text = document.createTextNode(string);
      var umbruch = document.createElement("br");

      var buttonWork = document.createElement("button");
      buttonWork.textContent='Edit';
      buttonWork.setAttribute('onclick', 'EditDiv(document.getElementById("div'+counter+'"))')
      
      var buttonDelete = document.createElement("button");
      buttonDelete.textContent='Delete';
      buttonDelete.id= "DeleteButtondiv"+counter;;
      buttonDelete.setAttribute('onclick', 'DeleteDiv(document.getElementById("div'+counter+'"))')

      counter++;

      textBox.appendChild(text);
      div.appendChild(buttonWork);
      div.appendChild(buttonDelete);
      div.appendChild(umbruch);
      div.appendChild(textBox);
      parentDiv.appendChild(div);

}


function EditDiv(element){
    console.log('EditDiv '+element.id);
    
    var inputfield = document.createElement("INPUT");
    inputfield.id= 'inputfield'+ element.id;
    inputfield.setAttribute("type", "text");
    element.appendChild(inputfield);

    var buttonDelete= document.getElementById('DeleteButton'+element.id);
    buttonDelete.setAttribute('onclick', 'EditText("'+element.id+'")')
    buttonDelete.textContent= 'Save new text';
}
function EditText(elementId){
    
    console.log('EditText '+elementId);
    
    var div= document.getElementById(elementId);

    var deleteButton= document.getElementById('DeleteButton'+elementId);
    deleteButton.textContent= 'Delete';
    deleteButton.setAttribute('onclick', 'DeleteDiv(document.getElementById("'+elementId+'"))')
    
    var inputfield= document.getElementById('inputfield'+elementId);
    var text= document.getElementById('text'+elementId);
    text.textContent=inputfield.value;

    div.removeChild(inputfield);
}

function DeleteDiv(element){
    console.log('deleteDiv '+element);
    
    var  parentDiv= document.getElementById("ParentDiv");
    parentDiv.removeChild(element);
}