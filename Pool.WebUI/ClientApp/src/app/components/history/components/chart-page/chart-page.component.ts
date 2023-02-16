import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BackgroundComponent } from '../../../../core/components/background/background.component';
import { HeaderComponent } from '../../../../ui/header/header.component';
import { Router } from '@angular/router';
import { OutlineButtonsGroupComponent } from '../../../../ui/outline-buttons-group/outline-buttons-group.component';
import { FormControl, ReactiveFormsModule } from '@angular/forms';
import { ChartComponent } from '../chart/chart.component';
import { map } from 'rxjs/operators';
import { DeviceTypeEnum } from '../../../../enums/device-type.enum';
import { ChartsService } from './charts.service';

@Component({
  selector: 'app-chart-page',
  standalone: true,
  imports: [
    CommonModule,
    BackgroundComponent,
    HeaderComponent,
    OutlineButtonsGroupComponent,
    ReactiveFormsModule,
    ChartComponent,
  ],
  templateUrl: './chart-page.component.html',
  styleUrls: ['./chart-page.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ChartPageComponent implements OnInit {
  periodButtons = ['1 ч', '4 ч', '1 дн', '1 нед', '1 мес', 'Все'];

  periodSelectControl = new FormControl();

  width = 951;
  height = 360;
  data$ = this.chartsService.getChart().pipe(
    map(
      (data: {
        data: number[];
        labels: number[];
        deviceType: DeviceTypeEnum;
      }) => {
        return {
          ...data,
          labels: ['0:00 \n - \n 3:59', '0:00 \n - \n 3:59', '0:00 \n - \n 3:59', '0:00 \n - \n 3:59', '0:00 \n - \n 3:59', '0:00 \n - \n 3:59', '0:00 \n - \n 3:59'],
        };
      }
    )
  );

  constructor(
    private readonly router: Router,
    private readonly chartsService: ChartsService
  ) {}

  ngOnInit(): void {
    this.periodSelectControl.setValue('1 дн');
  }

  onClickBack(): void {
    this.router.navigate(['/history']);
  }
}
