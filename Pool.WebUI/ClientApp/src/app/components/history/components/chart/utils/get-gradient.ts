import { Utils } from './utils';

export function getGradient(ctx: any, chartArea: any) {
  let gradient;

  gradient = ctx.createLinearGradient(0, chartArea.bottom, 0, chartArea.top);
  gradient.addColorStop(0, Utils.CHART_COLORS.darkBlue);
  gradient.addColorStop(0.5, Utils.CHART_COLORS.lightBlue);
  gradient.addColorStop(1, Utils.CHART_COLORS.darkBlue);

  return gradient;
}
