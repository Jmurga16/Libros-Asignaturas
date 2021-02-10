export interface ILibro{
    Id_libro?:number;
    descripcion?:string;    
    asignatura?:string;
    cAsignatura?:string;
    stock?:number;
    nId_asig?:number;
    cDescripcion?:string;
    nStock?:number;
    bStock?:number
}

export interface IStock{
    value: number;
    viewValue: string;
}

export interface IListaLibros{
    Id_libro?:number;
    descripcion?:string;
    asignatura?:string;
    cAsignatura?:string;
    stock?:number;
}

export interface ILibroEdit{
    Id_libro?:number;
    descripcion?:string;
    nId_asig?:number;
    stock?:number;

}