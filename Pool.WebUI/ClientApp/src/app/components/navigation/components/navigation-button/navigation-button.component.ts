import { ChangeDetectionStrategy, Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { NavigateButton } from '../../services/navigation.service';

@Component({
  selector: 'app-navigation-button',
  standalone: true,
  imports: [CommonModule, RouterLink, RouterLinkActive],
  templateUrl: './navigation-button.component.html',
  styleUrls: ['./navigation-button.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class NavigationButtonComponent {
  @Input() button!: NavigateButton;
}
