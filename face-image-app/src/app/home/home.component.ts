import { Component, OnInit, Injectable } from '@angular/core';
import { IServerInfo } from '../shared/server-info';
import { ServerInfoService } from '../shared/server-info.service';



@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  providers: [ ServerInfoService ]
})
export class HomeComponent implements OnInit {

  serverInfo: IServerInfo;
  private _serverService: ServerInfoService;

  errorMessage: string = '';

  constructor(serviceInfoService: ServerInfoService) {
    this._serverService = serviceInfoService;
  }

  ngOnInit() {
    console.log('Home component OnInit');
    // this._serverService.getServerInfo().subscribe(
    //   data => this.serverInfo = data,
    //   error => this.error(<any>error)
    // );
  }

  error(data) {
    console.log('error : ' + data)
  }
}
