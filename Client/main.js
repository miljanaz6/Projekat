import{Boje} from "./Tecnost.js";
import{Casa} from "./Casa.js";
import{Game} from "./Game.js";
var listaCasa1=[];
var listaCasa2=[];
var listaBoja1=[];
var listaBoja2=[];
fetch("https://localhost:5001/Case/Case1")
.then(p=>
    {
        p.json().then(elementi=>{
            {
                elementi.forEach(element=>{
                   
                    var a=new Casa(element.id,element.oznaka,element.kapacitet,element.napunjenost);
                    listaCasa1.push(a);
                }

                );
                fetch("https://localhost:5001/Case/Case2")
                .then(p=>
                    {
                        p.json().then(elementi=>{
                            {
                                elementi.forEach(element=>{
                                   
                                    var c=new Casa(element.id,element.oznaka,element.kapacitet,element.napunjenost);
                                    listaCasa2.push(c);
                                });
                               //case
                               fetch("https://localhost:5001/Case/CaseBoje1")
                               .then(p=>
                                   {
                                       p.json().then(elementi=>{
                                           {
                                               elementi.forEach(element=>{
                                                   
                                                   var b=new Boje(element.oznaka,element.kapacitet,element.napunjenost,element.red1,element.red2,element.red3,element.red4);
                                                   listaBoja1.push(b);
                                               }
                               
                                               );
                                               fetch("https://localhost:5001/Case/CaseBoje2")
                                               .then(p=>
                                                   {
                                                       p.json().then(elementi=>{
                                                           {
                                                               elementi.forEach(element=>{
                                                                   
                                                                   var d=new Boje(element.oznaka,element.kapacitet,element.napunjenost,element.red1,element.red2,element.red3,element.red4);
                                                                   listaBoja2.push(d);
                                                               }
                                               
                                                               );
                                                               var g=new Game(listaCasa1,listaBoja1,1);
                                                               g.crtaj(document.body);
                                                               var g2=new Game(listaCasa2,listaBoja2,2);
                                                               g2.crtaj(document.body);
                                                               
                                                           }
                                                          
                                                       })
                                                   })   
                                               
                                           }
                                          
                                       })
                                   }) 
                               
                            }
                           
                        })
                    })
                
            }
           
        })
    })
     console.log(listaCasa1);
     console.log(listaCasa2);
     console.log(listaBoja1);  
     console.log(listaBoja2);

       