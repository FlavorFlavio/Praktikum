
var counter=0;
function AddText(string){
    console.log(counter+' addText '+string);
    var div = document.createElement("div");
    div.id= "div"+counter;
    
      var textBox = document.createElement("p");

      var buttonWork = document.createElement("button");
      buttonWork.textContent='Edit';
      
      var umbruch = document.createElement("br");
      var buttonDelete = document.createElement("button");
      buttonDelete.textContent='Delete';
      buttonDelete.setAttribute('onclick', 'DeleteDiv(document.getElementById("div'+counter+'"))')
      var text = document.createTextNode(string);
      textBox.appendChild(text);
      //text.AddText = string;
  
      
      var parentDiv = document.getElementById("ParentDiv");
      div.appendChild(buttonWork);
      div.appendChild(buttonDelete);
      div.appendChild(umbruch);
      div.appendChild(textBox);
      parentDiv.appendChild(div);
counter++;
}


function EditDiv(element){


    console.log('Editiv '+element);
    
   var  parentDiv= document.getElementById("ParentDiv");
   parentDiv.removeChild(element);
   // parentDiv.removeChild
   // for (var i = 0; i < 9; i++) {
  //      console.log(i +' '+parentDiv.childNodes[i]);
  //    if(parentDiv.childNodes[i] == element){
//
}
function DeleteDiv(element){
    console.log('deleteDiv '+element);
    
   var  parentDiv= document.getElementById("ParentDiv");
   parentDiv.removeChild(element);
   // parentDiv.removeChild
   // for (var i = 0; i < 9; i++) {
  //      console.log(i +' '+parentDiv.childNodes[i]);
  //    if(parentDiv.childNodes[i] == element){
   //   }
    // }
    



}