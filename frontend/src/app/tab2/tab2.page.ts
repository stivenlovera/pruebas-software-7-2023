import { Component } from '@angular/core';
import { Categoria } from '../interface/categoria';
import { CategoriaProductoService } from '../service-backend/categoria-producto/categoria-producto.service';
import { HttpResponse } from '@angular/common/http';

@Component({
  selector: 'app-tab2',
  templateUrl: 'tab2.page.html',
  styleUrls: ['tab2.page.scss']
})
export class Tab2Page {

  public ListCategoria: Categoria[] = []
  constructor(private CategoriaProductoService: CategoriaProductoService) {
    this.ListCategoria = [
      {
        estadoRegistro: 1,
        nombre: 'Electrodomesticos',
        usuarioRegistro: 'stiven',
        fechaRegistro: '16/08/2023',
        id: 1
      },
      {
        estadoRegistro: 1,
        nombre: 'Muebles',
        usuarioRegistro: 'stiven',
        fechaRegistro: '16/08/2023',
        id: 1
      },
    ];
    this.getUsuariosFromBackend();
  }
  private getUsuariosFromBackend() {
    this.CategoriaProductoService.GetUsuarios().subscribe({
      next: (response: HttpResponse<Categoria[]>) => {
        this.ListCategoria = response.body!;
        console.log(this.ListCategoria)
      },
      error: (error: any) => {
        console.log(error);
      },
      complete: () => {
        //console.log('complete - this.getUsuarios()');
      },
    });
  }
}
