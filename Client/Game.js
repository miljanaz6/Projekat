export class Game{
    constructor(listaCasa,listaBoja,nivo)
    {
	    this.listaBoja=listaBoja;
		this.listaCasa=listaCasa;
		this.nivo=nivo;
		
		
    }

    crtaj(rod)
	{
		if (!rod)
		{
			throw new Exception("Roditeljski element nije nadjen!");
			return;
		}
		
		console.log(this.listaBoja);
		this.listaBoja.forEach(casa =>console.log(casa));
	    console.log(this.listaCasa);

		const kontejner = document.createElement("div");		
		kontejner.className = "kontejner";
		rod.appendChild(kontejner);
		
		this.kontejner = kontejner;
		
		this.crtajNaslov();
		this.crtajOstatak();
	}

    crtajNaslov(){
		const naslov = document.createElement("h3");
		naslov.className="naslov";
		if(this.nivo==1)
		naslov.innerHTML = "Level 1";
		else
		naslov.innerHTML = "Level 2";
		this.kontejner.appendChild(naslov);
	}
    crtajOstatak(){
		
		const kontejnerOstatka = document.createElement("div");
		kontejnerOstatka.className = "ostatak";
		this.kontejner.appendChild(kontejnerOstatka);
		
		this.listaBoja.forEach(casa => this.crtajCasu(casa, kontejnerOstatka ));
		
		this.crtajFormu(kontejnerOstatka);
	}
    crtajCasu(casa, rod){
		const casaKontejner = document.createElement("div");
		casaKontejner.className = "casaKontejner";
		rod.appendChild(casaKontejner);
		
		let labela = document.createElement("label");
		labela.className = "labOznaka";
		labela.innerHTML = casa.oznaka;
		casaKontejner.appendChild(labela);
		
		labela = document.createElement("label");
		labela.innerHTML = casa.ispisiOdnos();
		labela.className = "labOdnos";
		casaKontejner.appendChild(labela);
		
		const okvir = document.createElement("div");
		okvir.className = "okvir";
		casaKontejner.appendChild(okvir);
		
		const red1 = document.createElement("div");
		red1.className = "red1";
		if(casa.red1=="white")
		red1.style.backgroundColor ="rgb(255,255,255,0.18)";
		else
		red1.style.backgroundColor =casa.red1;
		okvir.appendChild(red1);

        const red2 = document.createElement("div");
		red2.className = "red2";
		if(casa.red2=="white")
		red2.style.backgroundColor ="rgb(255,255,255,0.18)";
		else
		red2.style.backgroundColor =casa.red2;
		okvir.appendChild(red2);

        const red3 = document.createElement("div");
		red3.className = "red3";
		if(casa.red3=="white")
		red3.style.backgroundColor ="rgb(255,255,255,0.18)";
		else
		red3.style.backgroundColor =casa.red3;
		okvir.appendChild(red3);

        const red4 = document.createElement("div");
		red4.className = "red4";
		if(casa.red4=="white")
		red4.style.backgroundColor ="rgb(255,255,255,0.18)";
		else
		red4.style.backgroundColor =casa.red4;
		okvir.appendChild(red4);

		const red5 = document.createElement("div");
		red5.className = "red5";
		okvir.appendChild(red5);
	}

    crtajFormu(rod){
		const kontejnerForma = document.createElement("div");
		kontejnerForma.className = "forma";
		rod.appendChild(kontejnerForma);
		
		let labela = document.createElement("label");
		labela.innerHTML = "Izaberite čaše: ";
		kontejnerForma.appendChild(labela);
		
		const selekt = document.createElement("select");
		kontejnerForma.appendChild(selekt);
		let opcija = null;
		
		this.listaCasa.forEach((casa, indeks) => {
			opcija = document.createElement("option");
			opcija.innerHTML = casa.oznaka;
			opcija.value = indeks;
			selekt.appendChild(opcija);
		});

        const selekt2 = document.createElement("select");
		kontejnerForma.appendChild(selekt2);
		let opcija2 = null;
		
		this.listaCasa.forEach((casa, indeks) => {
			opcija2 = document.createElement("option");
			opcija2.innerHTML = casa.oznaka;
			opcija2.value = indeks;
			selekt2.appendChild(opcija2);
		});

        const dugme = document.createElement("button");
		dugme.innerHTML = "Presipaj u čašu";
		dugme.className="button"
		kontejnerForma.appendChild(dugme);
		
		
		dugme.onclick = (ev) => this.funk(ev,selekt,selekt2);

    }
    funk(eventMouse,selekt,selekt2)
    {
        console.log(selekt.value);
        console.log(selekt2.value);
        const trCasa = this.listaBoja[selekt.value];
        const trCasa2 = this.listaBoja[selekt2.value];
        
        console.log(trCasa);
        console.log(trCasa2);

        var boja;
        const casaKontejner = this.kontejner.querySelectorAll(".casaKontejner")[selekt.value];
		const casaKontejner2 = this.kontejner.querySelectorAll(".casaKontejner")[selekt2.value];
		if(trCasa.red4!="white"){
			if(trCasa2.napunjenost==4)
			alert("Pokusavate da sipate u punu casu!")
			else{
			boja=trCasa.red4;
			const red4 = casaKontejner.querySelector(".red4");
			red4.style.backgroundColor ="rgb(255,255,255,0.18)";
			trCasa.promeniRed4("white");
			trCasa.smanjiNapunjenost();
			if(this.proveraKraj())
			{
				alert("Presli ste ovaj level!");
				window.location.reload(true);
			} 
		}
		}
		else if(trCasa.red3!="white"){
			if(trCasa2.napunjenost==4)
			alert("Pokusavate da sipate u punu casu!")
			else{
			boja=trCasa.red3;
			const red3 = casaKontejner.querySelector(".red3");
			red3.style.backgroundColor ="rgb(255,255,255,0.18)";
			trCasa.promeniRed3("white");
			trCasa.smanjiNapunjenost();
			if(this.proveraKraj())
			{
				alert("Presli ste ovaj level!");
				window.location.reload(true);
			} 
		}
		}
		else if(trCasa.red2!="white"){
			if(trCasa2.napunjenost==4)
			alert("Pokusavate da sipate u punu casu!")
			else{
			boja=trCasa.red2;
			const red2 = casaKontejner.querySelector(".red2");
			red2.style.backgroundColor ="rgb(255,255,255,0.18)";
			trCasa.promeniRed2("white");
			trCasa.smanjiNapunjenost();
			if(this.proveraKraj())
			{
				alert("Presli ste ovaj level!");
				window.location.reload(true);
			} 
		}
		}
		else if(trCasa.red1!="white"){
			if(trCasa2.napunjenost==4)
			alert("Pokusavate da sipate u punu casu!")
			else{
			boja=trCasa.red1;
			const red1 = casaKontejner.querySelector(".red1");
			red1.style.backgroundColor ="rgb(255,255,255,0.18)";
			trCasa.promeniRed1("white");
			trCasa.smanjiNapunjenost();
			if(this.proveraKraj())
			{
				alert("Presli ste ovaj level!");
				window.location.reload(true);
			} 
		}
		}
		else alert("Prazna casa!")

        if(trCasa2.red1=="white"){
			const red1 = casaKontejner2.querySelector(".red1");
			red1.style.backgroundColor =boja;
			trCasa2.promeniRed1(boja); 
			trCasa2.povecajNapunjenost();
			if(this.proveraKraj())
			{
				alert("Presli ste ovaj level!");
				window.location.reload(true);
			} 
		}
		else if(trCasa2.red2=="white"){
			const red2 = casaKontejner2.querySelector(".red2");
			red2.style.backgroundColor =boja;
			trCasa2.promeniRed2(boja);
			trCasa2.povecajNapunjenost();
			if(this.proveraKraj())
			{
				alert("Presli ste ovaj level!");
				window.location.reload(true);
			} 
		}
		else if(trCasa2.red3=="white"){
			const red3 = casaKontejner2.querySelector(".red3");
			red3.style.backgroundColor =boja;
			trCasa2.promeniRed3(boja);
			trCasa2.povecajNapunjenost();
			if(this.proveraKraj())
			{
				alert("Presli ste ovaj level!");
				window.location.reload(true);
			} 
		}
		else if(trCasa2.red4=="white"){
			const red4 = casaKontejner2.querySelector(".red4");
			red4.style.backgroundColor =boja;
			trCasa2.promeniRed4(boja);
			trCasa2.povecajNapunjenost();
			if(this.proveraKraj())
			{
				alert("Presli ste ovaj level!");
				window.location.reload(true);
			} 
		}


      
        const labOdnos = casaKontejner.querySelector(".labOdnos");
        labOdnos.innerHTML = trCasa.ispisiOdnos();

        const labOdnos2 = casaKontejner2.querySelector(".labOdnos");
        labOdnos2.innerHTML = trCasa2.ispisiOdnos();
       
            
        
    }
	proveraKraj()
	{
	
		var br=0;
		this.listaBoja.forEach(casa=>{if(casa.red1==casa.red2 && casa.red2==casa.red3 && casa.red3==casa.red4)br++;})
		console.log(br);
		if((this.nivo==1 && br==3) ||(this.nivo==2 && br==5))
		return true;
		else return false;
	}

}