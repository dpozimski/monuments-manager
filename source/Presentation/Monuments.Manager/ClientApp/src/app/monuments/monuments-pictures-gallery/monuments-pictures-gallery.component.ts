import { Component, OnInit } from '@angular/core';
import { NgxGalleryOptions, NgxGalleryImage, NgxGalleryAnimation, INgxGalleryOptions } from 'ngx-gallery';
import { MonumentsService } from '../services/monuments.service';
import { PicturesClient, DeletePictureCommand } from '../../api/monuments-manager-api';
import { DialogService } from 'ng2-bootstrap-modal';
import { UserConfirmationDialogComponent } from './../../../app/layout/user-confirmation-dialog/user-confirmation-dialog.component';

@Component({
    selector: 'app-monuments-pictures-gallery',
    templateUrl: './monuments-pictures-gallery.component.html',
    styleUrls: ['./monuments-pictures-gallery.component.css']
})
export class MonumentsPicturesGalleryComponent implements OnInit {
    private readonly defaultGalleryOptions: INgxGalleryOptions[] = [
        { thumbnails: false, width: '600px', height: '400px', imageArrowsAutoHide: true, preview: false }
    ];
    private selectedIndex: number = 0;

    galleryOptions: NgxGalleryOptions[] = this.defaultGalleryOptions;
    galleryImages: NgxGalleryImage[] = [];

    constructor(private monumentsService: MonumentsService,
                private dialogService: DialogService,
                private picturesClient: PicturesClient) {

    }

    ngOnInit() {
        this.monumentsService.selectedMonumentChanged
            .subscribe(_ => {
                if (this.monumentsService.selectedMonument == null ||
                    this.monumentsService.selectedMonument.pictures.length == 0) {
                    this.setNoPhotoConfiguration();
                } else {
                    this.setGalleryWithPhotosConfiguration();
                }
            });
    }

    private setNoPhotoConfiguration() {
        this.galleryOptions = this.defaultGalleryOptions;
        this.galleryImages = [{
            small: './../../assets/no-photo-small.png',
            medium: './../../assets/no-photo-medium.png',
            big: './../../assets/no-photo-big.png',
            description: 'No photo'
        }];
    }

    private setGalleryWithPhotosConfiguration() {
        this.galleryOptions = [
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
                thumbnailsArrows: true,
                startIndex: this.selectedIndex = 0,
                imageActions: [
                    {
                        icon: 'fa fa-times',
                        onClick: this.onDeleteAction
                    }
                ]
            }
        ];
        this.galleryImages = this.monumentsService.selectedMonument.pictures.map(image => {
            var ngxGalleryImage = new NgxGalleryImage({
                small: "data:image/png;base64," + image.data,
                medium: "data:image/png;base64," + image.data,
                big: "data:image/png;base64," + image.data,
                description: image.description
            });
            return ngxGalleryImage;
        });
    }

    private onDeleteAction(event: MouseEvent) {
        var pictureToDelete = this.monumentsService.selectedMonument.pictures[this.selectedIndex];

        this.dialogService.addDialog(UserConfirmationDialogComponent,
            { title: 'Delete picture', message: 'Do you want to delete picture?'})
            .subscribe(result => {
                if(result)
                    return;
                
                var command = new DeletePictureCommand();
                command.pictureId = pictureToDelete.;
                this.picturesClient.deletePicture()
            });
    }

    private onImageChange(event: any) {
        this.selectedIndex = event.index;
    }
}
