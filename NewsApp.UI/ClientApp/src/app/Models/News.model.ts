export class NewsModel{
  
    public managerId:string="";
    public managerName:string="";

    public  title :string="";
 
    public  description:string="";
    

    public  image:string="";
    public  datePost:string="";


    public  categoriId:string="";
    public  categoriName:string="";
    
    public isBlocked:boolean=false
    isValid():boolean{
        if(this.title!=""&&this.description!=""
        &&this.image!=""&&
        this.categoriName!=""
        )
        return true;
        else
        return false
    }
   
}