import { ChangeDetectionStrategy, Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { SettingsFooterComponent } from './components/settings-footer/settings-footer.component';
import { BackgroundComponent } from '../../core/components/background/background.component';
import { HeaderComponent } from '../../ui/header/header.component';

@Component({
  selector: 'app-settings',
  standalone: true,
  imports: [
    CommonModule,
    SettingsFooterComponent,
    BackgroundComponent,
    HeaderComponent,
  ],
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class SettingsComponent {
  constructor(private readonly router: Router) {}

  onClickBack(): void {
    this.router.navigate(['/dashboard']);
  }
}
