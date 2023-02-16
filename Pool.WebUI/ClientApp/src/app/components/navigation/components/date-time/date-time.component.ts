import {
  ChangeDetectionStrategy,
  Component,
  ElementRef,
  NgZone,
  OnInit,
  Renderer2,
  ViewChild,
} from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { LogoComponent } from '../../../../ui/logo/logo.component';

@Component({
  selector: 'app-date-time',
  standalone: true,
  imports: [CommonModule, LogoComponent],
  providers: [DatePipe],
  templateUrl: './date-time.component.html',
  styleUrls: ['./date-time.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class DateTimeComponent implements OnInit {
  @ViewChild('time')
  public time!: ElementRef;

  @ViewChild('date')
  public date!: ElementRef;

  constructor(
    private readonly zone: NgZone,
    private readonly renderer: Renderer2,
    private readonly datePipe: DatePipe
  ) {}

  ngOnInit(): void {
    this.zone.runOutsideAngular(() => {
      setInterval(() => {
        const date = new Date();
        this.setCurrentTime(date);
        this.setDate(date);
      }, 1000);
    });
  }

  private setCurrentTime(date: Date): void {
    this.renderer.setProperty(
      this.time.nativeElement,
      'textContent',
      `${this.datePipe.transform(date, 'HH:mm')}`
    );
  }

  private setDate(date: Date): void {
    this.renderer.setProperty(
      this.date.nativeElement,
      'textContent',
      `${this.datePipe.transform(date, 'd MMMM')}`
    );
  }
}
