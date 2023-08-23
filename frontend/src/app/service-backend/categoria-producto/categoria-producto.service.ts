import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http'
import { Observable } from 'rxjs';
import { Categoria } from 'src/app/interface/categoria';
@Injectable({
  providedIn: 'root'
})
export class CategoriaProductoService {

  PATH_BACKEND = "http://localhost:" + "5159"

  URL_GET = this.PATH_BACKEND + "/api/categoria-producto";
  URL_ADD_USUARIO = this.PATH_BACKEND + "/api/categoria-producto";

  constructor(private httpClient: HttpClient) {
  }

  public GetUsuarios(): Observable<HttpResponse<Categoria[]>> {
    return this.httpClient
      .get<Categoria[]>(this.URL_GET,
        { observe: 'response' })
      .pipe();
  }

  public AddUsuario(entidad: Categoria): Observable<HttpResponse<any>> {
    return this.httpClient
      .post<any>(this.URL_ADD_USUARIO, entidad,
        { observe: 'response' })
      .pipe();
  }
}
