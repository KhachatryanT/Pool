export enum DeviceTypeEnum {
  PH = 'ph',
  CI = 'ci',
  RX = 'rx',
  TEMP = 'temp',
}

export const DeviceType: Record<DeviceTypeEnum, string> = {
  [DeviceTypeEnum.PH]: 'pH',
  [DeviceTypeEnum.CI]: 'CI',
  [DeviceTypeEnum.RX]: 'Rx',
  [DeviceTypeEnum.TEMP]: 't',
};
