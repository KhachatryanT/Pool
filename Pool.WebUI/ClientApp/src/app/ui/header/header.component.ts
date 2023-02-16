import {
  ChangeDetectionStrategy,
  Component,
  EventEmitter,
  Input,
  Output,
} from '@angular/core';
import { CommonModule } from '@angular/common';
import { LogoComponent } from '../logo/logo.component';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [CommonModule, LogoComponent],
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class HeaderComponent {
  @Input() title!: string;
  @Input() isShowUserProfileButton = true;
  @Input() isShowInfoButton = true;

  @Output() clickBack = new EventEmitter<void>();
  @Output() clickInfo = new EventEmitter<void>();

  onClickBack(): void {
    this.clickBack.emit();
  }

  onClickInfo(): void {
    this.clickInfo.emit();
  }
}
