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

@Component({
  selector: 'app-date-time',
  standalone: true,
  imports: [CommonModule],
  providers: [DatePipe],
  templateUrl: './date-time.component.html',
  styleUrls: ['./date-time.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class DateTimeComponent implements OnInit {
  count = 0;

  @ViewChild('dayOfWeek')
  public dayOfWeek!: ElementRef;

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
        this.setDayOfWeek(date);
        this.setCurrentTime(date);
        this.setDate(date);
      }, 1000);
    });
  }

  private setDayOfWeek(date: Date): void {
    this.renderer.setProperty(
      this.dayOfWeek.nativeElement,
      'textContent',
      `${this.datePipe.transform(date, 'EEEEEE')}`
    );
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
