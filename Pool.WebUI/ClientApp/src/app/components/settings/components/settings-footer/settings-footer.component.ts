import { ChangeDetectionStrategy, Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-settings-footer',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './settings-footer.component.html',
  styleUrls: ['./settings-footer.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class SettingsFooterComponent {}
