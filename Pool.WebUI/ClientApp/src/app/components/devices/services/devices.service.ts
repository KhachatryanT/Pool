import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { DevicesApiService } from './devices-api.service';
import { Device } from '../../../interfaces/devices/device.interface';
import { Pool } from '../../../interfaces/pool/pool.interfaces';
import { catchError, map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class DevicesService {
  constructor(private readonly api: DevicesApiService) {}

  getDevices(poolAlias: string): Observable<Device[]> {
    return this.api.getDevices(poolAlias).pipe(
      catchError((error) => {
        console.log(error);
        return throwError(() => error);
      }),
      map((response) => response.devices)
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
