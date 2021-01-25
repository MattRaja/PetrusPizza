import { ITopping } from "./ITopping";
export interface IOrderRow {
    NameOfPizza: string;
    ExtraToppingsOnItems: string[];
    Price: string;
    AppUserId: string;
    PizzaType: string;
    PizzaSize: string;
}
