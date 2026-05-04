import { BaseService } from '@/app/shared/services/base-service';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class Addresses extends BaseService {
  getAddresses(): Observable<any> {
    return this._httpClient.get<any>(`${this._env.apiUrl}/api/addresses`);
  }
}
