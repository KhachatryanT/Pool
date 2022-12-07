import { ChangeDetectionStrategy, Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Device } from '../../../../interfaces/device.interface';
import { DeviceType, DeviceTypeEnum } from '../../../../enums/device-type.enum';
import { DotToCommaPipe } from '../../../../pipes/dot-to-comma.pipe';

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
    this.name = DeviceType[device.type];
    this.value = device.value;
    this.unit = this.getDeviceUnit(device);
    this.isBlueValue = [DeviceTypeEnum.PH, DeviceTypeEnum.RX].includes(
      device.type
    );
  }

  name!: string;
  value!: number;
  isBlueValue!: boolean;
  unit!: string;

  private getDeviceUnit(device: Device): string {
    switch (device.type) {
      case DeviceTypeEnum.CI: {
        return ', мг/л';
      }
      case DeviceTypeEnum.RX: {
        return ', мВ';
      }
      case DeviceTypeEnum.TEMP: {
        return ', &#176;C';
      }
      default: {
        return '';
      }
    }
  }
}
