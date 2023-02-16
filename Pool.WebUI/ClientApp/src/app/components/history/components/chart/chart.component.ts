import {
  ChangeDetectionStrategy,
  Component,
  Input,
  OnInit,
} from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgChartsModule } from 'ng2-charts';
import {
  ChartEvent,
  ActiveElement,
  Chart, ChartConfiguration,
} from 'chart.js';
import { Utils } from './utils/utils';
import { Point } from '@angular/cdk/drag-drop';

@Component({
  selector: 'app-chart',
  standalone: true,
  imports: [CommonModule, NgChartsModule],
  templateUrl: './chart.component.html',
  styleUrls: ['./chart.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ChartComponent implements OnInit {
  @Input() width!: string | number;
  @Input() height!: string | number;

  @Input() data!: (number | Point | null)[];
  @Input() labels!: (number | string | Point | null)[];

  plugins: any = {
    beforeInit: function(chart: Chart, args: any, options: any) {
      console.log('beforeInit', chart)
    }
  }

  lineChartData!: ChartConfiguration<'line'>['data'];
  lineChartOptions!: any;
  lineChartPlugins: any = [this.plugins];

  ngOnInit(): void {
    this.setChartData();
    this.setChartOptions();
  }

  private setChartData(): void {
    this.lineChartData = {
      labels: this.labels,
      datasets: [
        {
          data: this.data,
          fill: false,
          tension: 0.5,
          borderColor: Utils.getBorderColor,
        },
      ],
    };
  }

  private setChartOptions(): void {
    this.lineChartOptions = {
      onClick: (e: any) => {
        console.log(e);
      },
      onHover(event: ChartEvent, elements: ActiveElement[], chart: Chart) {
        // console.log({ event });
        // console.log({ elements });
        // console.log({ chart });
      },
      responsive: true,
      plugins: [{
        beforeInit: function(chart: any, args: any, options: any) {
          console.log('beforeInit');
        }
      }],
      elements: {
        point: {
          radius: 0,
        },
      },
      scales: {
        y: {
          beginAtZero: true,
          grid: {
            color: 'rgba(255, 255, 255, 0.1)',
          },
          ticks: {
            color: 'white',
            font: {
              family: 'Montserrat',
              size: 14,
              lineHeight: 1.1214,
              weight: '300',
              style: 'normal',
            },
            maxTicksLimit: 5,
          },
        },
        x: {
          grid: {
            display: true,
          },
          ticks: {
            display: true,
            color: 'white',
            font: {
              family: 'Montserrat',
              size: 14,
              lineHeight: 1.1214,
              weight: '300',
              style: 'normal',
            },
          },
        },
      },
    };
  }
}
