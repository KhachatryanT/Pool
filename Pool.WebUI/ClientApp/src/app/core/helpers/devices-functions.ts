import { DeviceTypeEnum } from '../../enums/device-type.enum';

export function getDeviceUnit(deviceType: DeviceTypeEnum): string {
  switch (deviceType) {
    case DeviceTypeEnum.CL: {
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
