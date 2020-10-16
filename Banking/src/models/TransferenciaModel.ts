export type TransferenciaModelo = {
    Cuenta: string;
    CuentaDestino: string;
    Monto: number;
    Titular?: string;
    TitularDestino?: string;
    Concepto?: string;
    Fecha?: string;
    Estado?: number;
    TipoTransaccion?: number;
}