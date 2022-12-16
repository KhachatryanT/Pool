import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DeviceCardComponent } from './device-card/device-card.component';
import { Device } from '../../interfaces/devices/device.interface';
import { DevicesService } from './services/devices.service';
import { Observable } from 'rxjs';
import { mergeMap } from 'rxjs/operators';

@Component({
  selector: 'app-devices',
  standalone: true,
  imports: [CommonModule, DeviceCardComponent],
  templateUrl: './devices.component.html',
  styleUrls: ['./devices.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class DevicesComponent implements OnInit {
  devices$: Observable<Device[]> = this.devicesService.getPools().pipe(
    mergeMap((pools) => this.devicesService.getDevices(pools[0].alias)),
  );

  constructor(private readonly devicesService: DevicesService) {}

  ngOnInit(): void {}
}
