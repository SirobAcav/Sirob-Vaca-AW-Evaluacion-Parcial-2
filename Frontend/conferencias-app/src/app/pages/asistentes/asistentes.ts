import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AsistenteService } from '../../services/asistente';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-asistentes',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './asistentes.html',
  styleUrl: './asistentes.css'
})
export class AsistentesComponent implements OnInit {

  asistentes: any[] = [];
  conferencias: any[] = [];

  asistente: any = {
    asistente_id: 0,
    nombre: '',
    apellido: '',
    email: '',
    telefono: '',
    conferencia_id: 0
  };

  constructor(
    private service: AsistenteService,
    private http: HttpClient
  ) {}

  ngOnInit() {
    this.cargar();
    this.cargarConferencias();
  }

  cargar() {
    this.service.getAll().subscribe(data => {
      this.asistentes = data;
    });
  }

  cargarConferencias() {
    this.http.get('http://localhost:5000/api/Conferencias')
      .subscribe(data => {
        this.conferencias = data as any[];
      });
  }

  guardar() {
    this.service.create(this.asistente).subscribe(() => {
      this.cargar();
      this.cancelar();
    });
  }

  modificar() {
    this.service.update(this.asistente.asistente_id, this.asistente).subscribe(() => {
      this.cargar();
      this.cancelar();
    });
  }

  eliminar() {
    this.service.delete(this.asistente.asistente_id).subscribe(() => {
      this.cargar();
      this.cancelar();
    });
  }

  seleccionar(a: any) {
    this.asistente = { ...a };
  }

  cancelar() {
    this.asistente = {
      asistente_id: 0,
      nombre: '',
      apellido: '',
      email: '',
      telefono: '',
      conferencia_id: 0
    };
  }
}