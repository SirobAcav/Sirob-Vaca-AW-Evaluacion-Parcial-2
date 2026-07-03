import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ConferenciaService } from '../../services/conferencia';

@Component({
  selector: 'app-conferencias',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './conferencias.html',
  styleUrl: './conferencias.css'
})
export class ConferenciasComponent implements OnInit {

  conferencias: any[] = [];

  conferencia: any = {
    conferencia_id: 0,
    nombre: '',
    fecha: '',
    ubicacion: '',
    descripcion: ''
  };

  constructor(private service: ConferenciaService) {}

  ngOnInit() {
    this.cargar();
  }

  cargar() {
    this.service.getAll().subscribe((data: any) => {
      this.conferencias = data;
    });
  }

  guardar() {
    this.service.create(this.conferencia).subscribe(() => {
      this.cargar();
      this.cancelar();
    });
  }

  modificar() {
    this.service.update(this.conferencia.conferencia_id, this.conferencia).subscribe(() => {
      this.cargar();
      this.cancelar();
    });
  }

  eliminar() {
    this.service.delete(this.conferencia.conferencia_id).subscribe(() => {
      this.cargar();
      this.cancelar();
    });
  }

  seleccionar(c: any) {
    this.conferencia = { ...c };
  }

  cancelar() {
    this.conferencia = {
      conferencia_id: 0,
      nombre: '',
      fecha: '',
      ubicacion: '',
      descripcion: ''
    };
  }
}