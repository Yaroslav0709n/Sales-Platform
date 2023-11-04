export interface Item {
    $id: string,
    id: string,
    name: string;
    description: string;
    price: number;
    time: string;
    city: string,
    state: string
}

export interface ItemDto {
    name: string;
    description: string;
    price: any;
    city: string,
    state: string
}