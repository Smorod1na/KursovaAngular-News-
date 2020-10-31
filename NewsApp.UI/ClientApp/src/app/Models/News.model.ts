export class NewsModel{
  
    public managerId:string="";
    public managerName:string="";

    public  title :string="";
 
    public  description:string="";
    

    public  image:string="";
    public  datePost:string="";


    public  categoriId:string="";
    public  categoriName:string="";
    
    isValid():boolean{
        if(this.title!=""&&this.description!=""&&
        this.datePost!=""&&this.image!=""&&
        this.categoriId!=""
        )
        return true;
        else
        return false
    }
   
}