import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-gallery-list',
  templateUrl: './gallery-list.component.html'
})
export class GalleryListComponent {
  public fileList: FileDetails[];
  
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<FilesViewModel>(baseUrl + 'api/Gallery/ListAsync').subscribe(result => {
      this.fileList = result.files;
    }, error => console.error(error));
  }
}

 

export interface FilesViewModel {
  files:  FileDetails[] ;
}

export interface FileDetails {
  name: string;
  blobName: string;
}
