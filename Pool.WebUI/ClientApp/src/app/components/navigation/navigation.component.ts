import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DateTimeComponent } from './components/date-time/date-time.component';
import { NavigationButtonComponent } from './components/navigation-button/navigation-button.component';
import { NavigationService } from './services/navigation.service';

@Component({
  selector: 'app-navigation',
  standalone: true,
  imports: [CommonModule, DateTimeComponent, NavigationButtonComponent],
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class NavigationComponent implements OnInit {
  buttons = this.navigationService.buttons;

  constructor(private readonly navigationService: NavigationService) {}

  ngOnInit(): void {}

  onSelectMenuItem(index: number): void {
    this.navigationService.selectMenuItem(index);
  }
}
