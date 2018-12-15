import { Component, OnInit } from '@angular/core';
import { NgxGalleryOptions, NgxGalleryImage, NgxGalleryAnimation } from 'ngx-gallery';

@Component({
  selector: 'app-monuments-pictures-gallery',
  templateUrl: './monuments-pictures-gallery.component.html',
  styleUrls: ['./monuments-pictures-gallery.component.css']
})
export class MonumentsPicturesGalleryComponent implements OnInit {
  galleryOptions: NgxGalleryOptions[];
  galleryImages: NgxGalleryImage[];

  ngOnInit() {

      this.galleryOptions = [
          {
              width: '600px',
              height: '400px',
              thumbnailsColumns: 4,
              imageAnimation: NgxGalleryAnimation.Slide
          },
          // max-width 800
          {
              breakpoint: 800,
              width: '100%',
              height: '600px',
              imagePercent: 80,
              thumbnailsPercent: 20,
              thumbnailsMargin: 20,
              thumbnailMargin: 20
          },
          // max-width 400
          {
              breakpoint: 400,
              preview: false
          }
      ];

      this.galleryImages = [
          {
              small: './../../assets/favicon.ico',
              medium: './../../assets/favicon.ico',
              big: './../../assets/favicon.ico'
          },
          {
              small: './../../assets/favicon.ico',
              medium: './../../assets/favicon.ico',
              big: './../../assets/favicon.ico'
          },
          {
              small: './../../assets/favicon.ico',
              medium: './../../assets/favicon.ico',
              big: './../../assets/favicon.ico'
          }
      ];
  }
}
