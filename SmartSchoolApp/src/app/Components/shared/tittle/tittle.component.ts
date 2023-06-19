import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-tittle',
  templateUrl: './tittle.component.html',
  styleUrls: ['./tittle.component.css']
})
export class TittleComponent implements OnInit {

  @Input() titulo: string = '';

  constructor() { }

  ngOnInit() {
  }

}
