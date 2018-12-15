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

    constructor(private monumentsService: MonumentsService) {

    }

    ngOnInit() {
        this.monumentsService.selectedMonumentChanged
            .subscribe(_ => {
                this.galleryOptions = this.monumentsService.selectedMonument != null ?
                    [
                        {
                            width: '600px',
                            height: '400px',
                            thumbnailsColumns: 3,
                            imageAnimation: NgxGalleryAnimation.Slide,
                            previewCloseOnClick: true,
                            previewCloseOnEsc: true,
                            previewAnimation: true,
                            preview: true,
                            previewZoom: true,
                            previewRotate: true,
                            previewDownload: true,
                            previewDescription: true,
                            thumbnailsArrows: true
                        }
                    ] : 
                    [
                        {
                            thumbnails: false
                        },
                        {
                            breakpoint: 500,
                            width: "100%",
                            height: "200px"
                        }
                    ];

                this.galleryImages = this.monumentsService.selectedMonument != null ?
                    this.monumentsService.selectedMonument.pictures.map(s => {
                        var ngxGalleryImage = new NgxGalleryImage({
                            small: "data:image/png;base64," + s,
                            medium: "data:image/png;base64," + s,
                            big: "data:image/png;base64," + s,
                            description: 'dupa',
                        });
                        return ngxGalleryImage;
                    }) : [{
                        small: './../../../assets/no-photo-small.png',
                        medium: './../../../assets/no-photo-medium.png',
                        big: './../../../assets/no-photo-big.png'
                    }];
            });
    }
}
