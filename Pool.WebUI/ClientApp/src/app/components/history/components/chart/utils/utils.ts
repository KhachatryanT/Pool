import { getGradient } from './get-gradient';

export const Utils = {
  CHART_COLORS: {
    lightBlue: '#75E6FF',
    darkBlue: '#1682CF',
  },
  PLUGINS: {
    tooltip: {
      enabled: false,
    },
    legend: {
      display: false,
    },
  },
  getBorderColor: function (context: any) {
    const chart = context.chart;
    const { ctx, chartArea } = chart;

    if (!chartArea) {
      return;
    }

    return getGradient(ctx, chartArea);
  },
};
