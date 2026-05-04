import { BaseService } from '@/app/shared/services/base-service';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class Ubigeos extends BaseService {
  search(term: any): Observable<any> {
    return this._httpClient.get<any>(`${this._env.apiUrl}/api/ubigeos`, {
      params: { term },
    });
  }
}
