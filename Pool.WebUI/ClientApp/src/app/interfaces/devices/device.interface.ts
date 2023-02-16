import { DeviceTypeEnum } from '../../enums/device-type.enum';

export interface Device {
  type: DeviceTypeEnum;
  indicator: {
    value: number;
    date: string;
  };
}

export interface DeviceResponse {
  devices: Device[];
}
