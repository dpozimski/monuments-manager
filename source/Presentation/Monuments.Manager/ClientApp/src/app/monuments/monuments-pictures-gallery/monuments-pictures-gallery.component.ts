import { Component, OnInit } from '@angular/core';
import { NgxGalleryOptions, NgxGalleryImage, NgxGalleryAnimation } from 'ngx-gallery';
import { MonumentsService } from '../services/monuments.service';
import { MonumentDto } from '../../api/monuments-manager-api';

@Component({
  selector: 'app-monuments-pictures-gallery',
  templateUrl: './monuments-pictures-gallery.component.html',
  styleUrls: ['./monuments-pictures-gallery.component.css']
})
export class MonumentsPicturesGalleryComponent implements OnInit {
  galleryOptions: NgxGalleryOptions[];
  galleryImages: NgxGalleryImage[];

  constructor(private monumentsService: MonumentsService){

  }

  ngOnInit() {

      this.galleryOptions = [
          {
              width: '600px',
              height: '400px',
              thumbnailsColumns: 4,
              imageAnimation: NgxGalleryAnimation.Slide,
              previewCloseOnClick: true,
              previewCloseOnEsc: true
          },
          {
              breakpoint: 800,
              width: '100%',
              height: '600px',
              imagePercent: 80,
              thumbnailsPercent: 20,
              thumbnailsMargin: 20,
              thumbnailMargin: 20
          },
          {
              breakpoint: 400,
              preview: true,
          }
      ];

      this.monumentsService.selectedMonumentChanged
          .subscribe(_ => {
            this.galleryImages = this.monumentsService.selectedMonument.pictures.map(s => {
                var ngxGalleryImage = new NgxGalleryImage({
                    small: "data:image/png;base64," + s,
                    medium: "data:image/png;base64," + s,
                    big: "data:image/png;base64," + s,
                });
                return ngxGalleryImage;
            });
          });
  }
}
