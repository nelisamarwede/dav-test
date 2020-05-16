import { Component, OnInit } from '@angular/core';
import { ServerService } from '../server.service';
import { User } from '../models/user';


@Component({
    selector: 'app-users',
    templateUrl: './users.component.html',
    styleUrls: ['./users.component.css']
  })
  export class UsersComponent implements OnInit {
  
    users: User[];
    newUser: string;
    
    constructor(public server: ServerService) {
      server.GetUsers().subscribe(i => this.users = i);
    }
  
    ngOnInit() {
    }
  
    addUser() {
      if (!this.newUser) return;
  
    //   var user = { id: null, username: this.newUser, firstName: this.newUser };
    //   this.server.AddUser(user).subscribe(id => user.id = id, e => { alert('Error') })
    //   this.users.push(user);
      this.newUser = "";
    }
  }