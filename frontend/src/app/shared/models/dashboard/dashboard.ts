import { Tile } from '../tile/tile';

export interface Dashboard {
    id: number,
    name: string,
    icon: string,
    createdBy: number,
    organizationId: number
    tiles: Tile[]
}
