import { ChangeDetectionStrategy, Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BackgroundComponent } from '../../core/components/background/background.component';
import { HeaderComponent } from '../../ui/header/header.component';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-history',
  standalone: true,
  imports: [CommonModule, BackgroundComponent, HeaderComponent, RouterModule],
  templateUrl: './history.component.html',
  styleUrls: ['./history.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class HistoryComponent {
  constructor(private readonly router: Router) {}

  onClickBack(): void {
    this.router.navigate(['/']);
  }
}
