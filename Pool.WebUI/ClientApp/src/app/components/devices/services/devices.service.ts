import { Injectable } from '@angular/core';
import { Observable, tap, throwError } from 'rxjs';
import { DevicesApiService } from './devices-api.service';
import { Device } from '../../../interfaces/devices/device.interface';
import { Pool } from '../../../interfaces/pool/pool.interfaces';
import { catchError, finalize, map, repeat } from 'rxjs/operators';
import { LoaderService } from '../../../core/services/loader.service';

@Injectable({
  providedIn: 'root',
})
export class DevicesService {
  constructor(
    private readonly api: DevicesApiService,
    private readonly loaderService: LoaderService
  ) {}

  getDevices(poolAlias: string): Observable<Device[]> {
    return this.api.getDevices(poolAlias).pipe(
      tap(() => (this.loaderService.isBlockLoader = true)),
      catchError((error) => {
        console.log(error);
        return throwError(() => error);
      }),
      map((response) => response.devices),
      repeat({ delay: 10000 }),
      finalize(() => (this.loaderService.isBlockLoader = false))
    );
  }

  getPools(): Observable<Pool[]> {
    return this.api.getPools().pipe(
      catchError((error) => {
        console.log(error);
        return throwError(() => error);
      })
    );
  }
}
