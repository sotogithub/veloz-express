import { BaseService } from '@/app/shared/services/base-service';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class PackageCategories extends BaseService {
  //GetCategories
  getCategories(): Observable<any> {
    return this._httpClient.get<any>(
      `${this._env.apiUrl}/api/package-categories`
    );
  }
}
