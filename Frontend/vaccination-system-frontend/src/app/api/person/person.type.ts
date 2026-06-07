import { GetVaccinationDto } from "../vaccination/vaccination.type";

export interface GetPersonsItemDto {
    id: string,
    name: string
}

export interface GetPersonDto {
    id: string,
    name: string,
    vaccines: GetVaccinationDto[]
}