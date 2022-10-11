import { Component, Inject, OnInit } from "@angular/core";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material";
import { AsignaturasService } from "src/app/services/asignaturas/asignaturas.service";
import { LibrosService } from "src/app/services/libros/libros.service";

@Component({
    selector: 'app-modal-delete',
    templateUrl: './modal-delete.component.html',
    styleUrls: ['./modal-delete.component.css']
})
export class ModalDeleteComponent implements OnInit {

    title: string = ""
    subtitle: string = ""


    constructor(
        public dialogRef: MatDialogRef<ModalDeleteComponent>,
        @Inject(MAT_DIALOG_DATA) public data: any,
        private librosService: LibrosService,
        private asignaturasService: AsignaturasService
    ) {

    }

    ngOnInit(): void {
        if (this.data.tipo == 'libro') {
            this.title = 'Eliminar Libro'
            this.subtitle = '¿Desea eliminar el Libro seleccionado?'
        }
        else if (this.data.tipo == 'asignatura') {
            this.title = 'Eliminar Asignatura'
            this.subtitle = '¿Desea eliminar la asignatura seleccionada?'
        }

    }

    //#region Eliminar Libro
    deleteLibro(id: number) {

        this.librosService.deleteLibro(id)
            .subscribe(
                res => {
                    this.dialogRef.close(1);
                },
                err => console.error(err)
            )

    }
    //#endregion


    //#region Eliminar Asignatura
    deleteAsignatura(id: number) {

        this.asignaturasService.deleteAsignatura(id)
            .subscribe(
                res => {
                    this.dialogRef.close(1);
                },
                err => console.error(err)
            )

    }
    //#endregion

}