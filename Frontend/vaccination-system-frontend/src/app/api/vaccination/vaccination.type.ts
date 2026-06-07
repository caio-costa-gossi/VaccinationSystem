import { GetVaccineDto } from "../vaccine/vaccine.type";

export interface GetVaccinationDto {
    id: string,
    vaccine: GetVaccineDto,
    doseNumber: number,
    appliedAt: string
}