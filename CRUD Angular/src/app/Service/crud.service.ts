import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CrudVM } from '../Class/crud-vm';

@Injectable({
  providedIn: 'root'
})
export class CrudService {

  Url = 'http://localhost:54888/Api';
  constructor(private http: HttpClient) { }
  getAllData(): Observable<CrudVM[]> {
    return this.http.get<CrudVM[]>(this.Url + '/Data/GetAllData');
  }

  CreateData(OutletVM: CrudVM): Observable<CrudVM[]> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.post<CrudVM[]>(this.Url + '/Data/CreateData/', OutletVM, httpOptions)
  }

  UpdateData(OutletVM: CrudVM): Observable<CrudVM[]> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.post<CrudVM[]>(this.Url + '/Data/UpdateData/', OutletVM, httpOptions)
  }

  DeleteData(CrudId: number): Observable<number> {
    return this.http.get<number>(this.Url + '/Data/DeleteData?Id=' + CrudId);
  }

  getDataById(CrudId: number): Observable<CrudVM> {
    return this.http.get<CrudVM>(this.Url + '/Data/GetDataById?Id=' + CrudId);
  }
}
