import { ChangeDetectionStrategy, Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-navigation-button',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './navigation-button.component.html',
  styleUrls: ['./navigation-button.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class NavigationButtonComponent implements OnInit {
  @Input() iconName!: string;
  @Input() title!: string;
  @Input() isActive = false;

  constructor() { }

  ngOnInit(): void {
  }

}
