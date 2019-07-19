import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FilesViewModel } from './files-view-model';
@Injectable()
export class GalleryService {
  baseUrl: string;
  http: HttpClient;
  constructor(_http: HttpClient, @Inject('BASE_URL') _baseUrl: string) {
    this.baseUrl = _baseUrl;
    this.http = _http;
  }


  ListAsync() : any {
   return this.http.get<FilesViewModel>(this.baseUrl + 'api/Gallery/ListAsync');
  }
}
