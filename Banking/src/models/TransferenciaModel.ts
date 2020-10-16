export type TransferenciaModelo = {
    Cuenta: string;
    CuentaDestino: string;
    Monto: number;
    Titular?: string;
    Concepto?: string;
    Fecha?: string;
    Estado?: number;
}