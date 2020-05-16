import { ProductLine } from "./ProductLine";
import { OrderStatus } from "./order-status.enum";

export class Order {
  public id: number;
  public supplierId: number;
  public supplerName: string;
  public orderNumber: number;
  public dateTime: Date;
  public statusId: OrderStatus;
  public productLines: ProductLine[];

  constructor(){
    this.productLines = [new ProductLine()];
  }
}
