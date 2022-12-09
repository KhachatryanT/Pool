import { HTTP_INTERCEPTORS } from '@angular/common/http';

export function makeInterceptor<T>(service: T) {
  return {
    provide: HTTP_INTERCEPTORS,
    useClass: service,
    multi: true,
  };
}
