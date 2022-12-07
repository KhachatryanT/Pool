import { DeviceTypeEnum } from '../enums/device-type.enum';

export interface Device {
  poolAlias: string;
  controllerCode: string;
  type: DeviceTypeEnum;
  date: string;
  value: number;
}
