import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-newsDescription',
  templateUrl: './newsDescription.component.html',
  styleUrls: ['./newsDescription.component.css']
})
export class NewsDescriptionComponent implements OnInit {
  @Input() model: string
  constructor() { }

  ngOnInit() {
  }

}
