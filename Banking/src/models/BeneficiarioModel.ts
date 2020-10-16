export type BeneficiarioModel = {
    Titular?: string;
    ClienteId: number;
    Alias: string;
    CuentaDestino: string;
    Aprobado: boolean;
    Estado?: number;
    FechaCreacion?: string;
}