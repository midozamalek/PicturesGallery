import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpRequest } from '@angular/common/http';
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
   return this.http.get<FilesViewModel>(this.baseUrl + 'api/Gallery/List');
  }

  Delete(blobName: string): any {
    return this.http.get<boolean>(this.baseUrl + 'api/Gallery/Delete?blobName=' + blobName);
  }

  Uploud(formData: FormData): any {
    const uploadReq = new HttpRequest('POST', 'api/Gallery/UploadAsync', formData, {
      reportProgress: true,      
      responseType: 'text' 
    });

    return this.http.request(uploadReq);
  }

}
