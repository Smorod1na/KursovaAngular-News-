import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { NotifierService } from 'angular-notifier';
import { NewsModel } from 'src/app/Models/News.model';
import { NewsService } from 'src/app/Services/News.service';

@Component({
  selector: 'app-manager-item',
  templateUrl: './manager-item.component.html',
  styleUrls: ['./manager-item.component.css']
})
export class ManagerItemComponent implements OnInit {

  title:string
  model:NewsModel
  constructor(private newsService:NewsService,
    private route:ActivatedRoute,private notifier:NotifierService,
    private router:Router) { }

  ngOnInit() {
    this.route.params.subscribe((params: Params) => {
      this.title = params["title"]
    })

    this.newsService.getAllNews().subscribe(data => {
      this.model = data.filter(x => x.title == this.title)[0]
    })
  }


  deleteNews(){
    this.newsService.deleteNews(this.model).subscribe(data=>{
     
        if (data.status === 200) {
          this.notifier.notify('success', "You delete news!");
          this.router.navigate(['/manager-panel'])
     
        }
        else {
          for (var i = 0; i < data.errors.length; i++) {
            this.notifier.notify('error', data.errors[i]);
          }
        }
    });
  }
}
