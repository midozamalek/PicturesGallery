import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FilesViewModel } from './files-view-model';
import { FileDetails } from './file-details';
import { GalleryService } from './gallery.Service';
import { debug } from 'util';

@Component({
  selector: 'app-gallery-list',
  templateUrl: './gallery-list.component.html'
})
export class GalleryListComponent {
  public fileList: FileDetails[];

  constructor(galleryService: GalleryService) {
    galleryService.ListAsync().subscribe((res: any) => {
      this.fileList = res.files;
    });
  }
}






