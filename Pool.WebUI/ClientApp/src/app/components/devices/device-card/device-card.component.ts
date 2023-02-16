import { ChangeDetectionStrategy, Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Device } from '../../../interfaces/devices/device.interface';
import { DeviceType, DeviceTypeEnum } from '../../../enums/device-type.enum';
import { DotToCommaPipe } from '../../../pipes/dot-to-comma.pipe';
import { getDeviceUnit } from '../../../core/helpers/devices-functions';

@Component({
  selector: 'app-device-card',
  standalone: true,
  imports: [CommonModule, DotToCommaPipe],
  templateUrl: './device-card.component.html',
  styleUrls: ['./device-card.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class DeviceCardComponent {
  @Input() set device(device: Device) {
    this.name = DeviceType[device.type.toLowerCase() as DeviceTypeEnum];
    this.value = device.indicator.value;
    this.unit = getDeviceUnit(device.type.toLowerCase() as DeviceTypeEnum);
    this.isBlueValue = true;
  }

  name!: string;
  value!: number;
  isBlueValue!: boolean;
  unit!: string;
}
