import { NgModule } from '@angular/core';

import { OverlayModule } from '@angular/cdk/overlay';

import { LoaderInterceptor } from './interceptors/loader.interceptor';
import { LoaderService } from './services/loader.service';
import { makeInterceptor } from './interceptors/make-interceptor-function';

@NgModule({
  imports: [OverlayModule],
  providers: [
    {
      ...makeInterceptor(LoaderInterceptor),
      deps: [LoaderService],
    },
  ],
})
export class CoreModule {}
