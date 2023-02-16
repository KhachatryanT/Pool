import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { BackgroundComponent } from '../../../../core/components/background/background.component';
import { HeaderComponent } from '../../../../ui/header/header.component';

@Component({
  selector: 'app-event-log',
  standalone: true,
  imports: [CommonModule, BackgroundComponent, HeaderComponent],
  templateUrl: './event-log.component.html',
  styleUrls: ['./event-log.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class EventLogComponent implements OnInit {
  constructor(private readonly router: Router) {}

  ngOnInit(): void {}

  onClickBack(): void {
    this.router.navigate(['/history']);
  }
}
