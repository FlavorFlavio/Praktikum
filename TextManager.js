

function AddText(string){
    console.log('test '+string);
    var div = document.createElement("div");
    
      var textBox = document.createElement("p");

      var buttonWork = document.createElement("button");
      var umbruch = document.createElement("br");
      var buttonDelete = document.createElement("button");
      

      var text = document.createTextNode(string);
      textBox.appendChild(text);
      //text.AddText = string;
  
      
      var parentDiv = document.getElementById("ParentDiv");
      div.appendChild(buttonWork);
      div.appendChild(buttonDelete);
      div.appendChild(umbruch);
      div.appendChild(textBox);
      parentDiv.appendChild(div);

}