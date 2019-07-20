import { Component, Inject } from '@angular/core';
import { HttpClient, HttpEventType } from '@angular/common/http';
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
  baseUrl: string;
  msg: string = null;
  showMsg: boolean = false;
  file: any;
  progress: any=0;
  galleryService: GalleryService;
  constructor(_galleryService: GalleryService) {
    this.galleryService = _galleryService;
    this.baseUrl = _galleryService.baseUrl;
    _galleryService.ListAsync().subscribe((res: any) => {
      this.fileList = res.files;
    });
  }

  Delete(blobName: string) {
    this.galleryService.Delete(blobName).subscribe((res: any) => {
      if (res == true) {
        this.msg = 'success deleting!';
        this.showMsg = true;
        window.location.reload();
      }
    });
  }

  onSelectFile($event, file) {
    this.file = file;
  }


  uploadImage() {
    if (this.file.length === 0) {
      return;
    }

    const formData = new FormData();

    for (let file of this.file)
      formData.append(file.name, file);

    

    this.galleryService.Uploud(formData).subscribe(event => {
      if (event.type === HttpEventType.UploadProgress) {
        this.progress = Math.round(100 * event.loaded / event.total);
      }
      else if (event.type === HttpEventType.Response) {
        this.msg = 'success uplouding!';
        this.showMsg = true;
        window.location.reload();
      }
    });
  }

}






