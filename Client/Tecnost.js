export class Boje{
    constructor(oznaka,kapacitet,napunjenost,red1,red2,red3,red4){
        this.oznaka=oznaka;
        this.kapacitet=kapacitet;
        this.napunjenost=napunjenost;
        this.red1=red1;
        this.red2=red2;
        this.red3=red3;
        this.red4=red4;
    }
    ispisiOdnos()
	{
		return this.napunjenost + "/" + this.kapacitet ;
        
	}

    promeniRed4(x){
      this.red4=x;
    }
    promeniRed3(x){
        this.red3=x;
    }
    promeniRed2(x){
        this.red2=x;
    }
    promeniRed1(x){
        this.red1=x;
    }
    povecajNapunjenost(){
        this.napunjenost++;
    }
    smanjiNapunjenost(){
        this.napunjenost--;
    }
}