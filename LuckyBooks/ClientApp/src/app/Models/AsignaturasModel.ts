export interface IAsignatura{
    id_asig?:number;
    descripcion?:string;
    estado?:boolean;
    stock?:number;
    nId_asig?:number;
    cDescripcion?:string;
    bEstado?:boolean
}

export interface IEstado{
    value: number;
    viewValue: string;
}