import { Component, Input, OnInit } from '@angular/core';
import { Member } from 'src/app/_models/member';

@Component({
  selector: 'app-memer-card',
  templateUrl: './memer-card.component.html',
  styleUrls: ['./memer-card.component.scss']
})
export class MemerCardComponent implements OnInit {
  @Input() member: Member;

  constructor() { }

  ngOnInit(): void {
  }

}
