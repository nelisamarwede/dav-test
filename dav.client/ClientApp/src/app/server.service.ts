import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../environments/environment';
import { User } from './models/user';
import { Observable } from 'rxjs/Observable';
import { Order } from './models/Order';
import {Image} from './models/image';

@Injectable()
export class ServerService {

  constructor(private http: HttpClient) { }


  public GetUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.GetUrl("User"));
  }

  public AddUser(user: User): Observable<number> {
    return this.http.post<number>(this.GetUrl("User"), user);
  }
  private GetUrl(resource: string): string {
    return `${environment.baseAddress}/${resource}`;
  }

  public GetOrders(): Observable<Order[]>{
    return this.http.get<Order[]>(this.GetUrl("Order"));
  }

  public AddOrder(order: Order): Observable<Order>{
    return this.http.post<Order>(this.GetUrl("Order"), order);
  }

  public UpdateOrder(order: Order): Observable<boolean>{
    return this.http.put<boolean>(this.GetUrl("Order"), order);
  }


  public GetImages(): Observable<Image[]>{
    return this.http.get<Image[]>(this.GetUrl("Image"));
  }

  public AddImage(image: Image): Observable<Image>{
    return this.http.post<Image>(this.GetUrl("Image"), image);
  }

  public UpdateImage(image: Image): Observable<boolean>{
    return this.http.put<boolean>(this.GetUrl("Image"), image);
  }


}
