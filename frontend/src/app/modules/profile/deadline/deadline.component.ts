import { Component, Input, OnInit } from '@angular/core';
import { Deadline, DeadlineClass } from 'src/app/services/profile.service';

@Component({
  selector: 'app-deadline',
  templateUrl: './deadline.component.html',
  styleUrls: ['./deadline.component.scss']
})
export class DeadlineComponent implements OnInit {

  @Input() deadline: DeadlineClass = new DeadlineClass();

  constructor() { }

  ngOnInit(): void {
  }

}
