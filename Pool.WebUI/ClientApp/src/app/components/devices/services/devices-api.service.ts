import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Pool } from '../../../interfaces/pool/pool.interfaces';
import { Observable } from 'rxjs';
import { DeviceResponse } from '../../../interfaces/devices/device.interface';

@Injectable({
  providedIn: 'root',
})
export class DevicesApiService {
  constructor(private readonly httpClient: HttpClient) {}

  getDevices(poolAlias: string): Observable<DeviceResponse> {
    return this.httpClient.get<DeviceResponse>(`api/devices/${poolAlias}`);
  }

  getPools(): Observable<Pool[]> {
    return this.httpClient.get<Pool[]>('api/Pool');
  }
}
