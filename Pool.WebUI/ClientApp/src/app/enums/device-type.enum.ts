export enum DeviceTypeEnum {
  PH = 'ph',
  CL = 'cl',
  RX = 'rx',
  TEMP = 'temp',
}

export const DeviceType: Record<DeviceTypeEnum, string> = {
  [DeviceTypeEnum.PH]: 'pH',
  [DeviceTypeEnum.CL]: 'Cl',
  [DeviceTypeEnum.RX]: 'Rx',
  [DeviceTypeEnum.TEMP]: 't',
};
