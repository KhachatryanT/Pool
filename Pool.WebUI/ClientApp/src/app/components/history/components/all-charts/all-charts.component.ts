import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ChartComponent } from '../chart/chart.component';
import { AllChartsService } from './all-charts.service';
import { map } from 'rxjs/operators';
import { DeviceType, DeviceTypeEnum } from '../../../../enums/device-type.enum';
import { getDeviceUnit } from '../../../../core/helpers/devices-functions';

@Component({
  selector: 'app-all-charts',
  standalone: true,
  imports: [CommonModule, ChartComponent],
  templateUrl: './all-charts.component.html',
  styleUrls: ['./all-charts.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AllChartsComponent implements OnInit {
  width = 428;
  height = 180;
  data$ = this.chartsService.getCharts().pipe(
    map(
      (
        data: { data: number[]; labels: number[]; deviceType: DeviceTypeEnum }[]
      ) => {
        return data.map((d: any) => {
          return {
            ...d,
            labels: new Array(d.data?.length).fill(''),
            title: `${
              DeviceType[d.deviceType as DeviceTypeEnum]
            }${getDeviceUnit(d.deviceType)}`,
          };
        });
      }
    )
  );

  constructor(private readonly chartsService: AllChartsService) {}

  ngOnInit(): void {}
}
