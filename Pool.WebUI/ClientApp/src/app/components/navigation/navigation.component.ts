import { ChangeDetectionStrategy, Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DateTimeComponent } from './components/date-time/date-time.component';
import { NavigationButtonComponent } from './components/navigation-button/navigation-button.component';
import { NavigationService } from './services/navigation.service';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterLink, RouterLinkActive } from '@angular/router';

@Component({
  selector: 'app-navigation',
  standalone: true,
  imports: [
    CommonModule,
    DateTimeComponent,
    NavigationButtonComponent,
    ReactiveFormsModule,
    RouterLink,
    RouterLinkActive,
  ],
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class NavigationComponent {
  buttons = this.navigationService.buttons;

  constructor(private readonly navigationService: NavigationService) {}
}
