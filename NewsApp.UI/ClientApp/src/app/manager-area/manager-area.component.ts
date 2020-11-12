import { Component, OnInit } from '@angular/core';
import { NewsModel } from '../Models/News.model';
import { NewsService } from '../Services/News.service';

@Component({
  selector: 'app-manager-area',
  templateUrl: './manager-area.component.html',
  styleUrls: ['./manager-area.component.css']
})
export class ManagerAreaComponent implements OnInit {

  constructor() { }

  ngOnInit() {
    
  }

}
