import { Component, OnInit, Input, OnChanges } from '@angular/core';
import { NgxGalleryOptions, NgxGalleryImage, NgxGalleryAnimation, INgxGalleryOptions } from 'ngx-gallery';
import { MonumentsService } from '../services/monuments.service';
import { PicturesClient, DeletePictureCommand, PictureDto, MonumentDto } from '../../api/monuments-manager-api';
import { DialogService } from 'ng2-bootstrap-modal';
import { UserConfirmationDialogComponent } from './../../../app/layout/user-confirmation-dialog/user-confirmation-dialog.component';
import { ToastrService } from 'ngx-toastr';
import { CreatePictureDialogComponent } from '../create-picture-dialog/create-picture-dialog.component';

@Component({
    selector: 'app-monuments-pictures-gallery',
    templateUrl: './monuments-pictures-gallery.component.html',
    styleUrls: ['./monuments-pictures-gallery.component.css']
})
export class MonumentsPicturesGalleryComponent implements OnChanges {
    private readonly defaultGalleryOptions: INgxGalleryOptions[] = [
        { thumbnails: false, imageArrowsAutoHide: true, preview: false }
    ];
    private selectedIndex: number = 0;

    @Input()
    monument: MonumentDto;
    galleryOptions: NgxGalleryOptions[] = this.defaultGalleryOptions;
    galleryImages: NgxGalleryImage[] = [];

    constructor(private dialogService: DialogService,
                private picturesClient: PicturesClient,
                private toastr: ToastrService) {

    }

    ngOnChanges(changes: any) {
        var monument = changes.monument.currentValue;

        if (monument == null || monument.pictures == null || monument.pictures.length == 0) {
            this.setNoPhotoConfiguration();
        } else {
            this.setGalleryWithPhotosConfiguration(monument.pictures);
        }
    }

    onImageChange(event: any) {
        this.selectedIndex = event.index;
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

    private setGalleryWithPhotosConfiguration(pictures: PictureDto[]) {
        this.galleryOptions = [
            {
                thumbnailsColumns: 3,
                imageAnimation: NgxGalleryAnimation.Slide,
                previewCloseOnClick: true,
                previewCloseOnEsc: true,
                previewAnimation: true,
                preview: true,
                previewZoom: true,
                previewRotate: true,
                previewDownload: true,
                imageSize: "Cover",
                previewDescription: true,
                thumbnailsArrows: true,
                startIndex: this.selectedIndex = 0,
                imageActions: [
                    {
                        icon: 'fa fa-trash',
                        onClick: (_: Event) => this.onDeleteAction(pictures)
                    },
                    {
                        icon: 'fa fa-plus',
                        onClick: (_: Event) => this.onCreateAction(pictures)
                    }
                ]
            }
        ];
        this.galleryImages = pictures.map(image => {
            var ngxGalleryImage = new NgxGalleryImage({
                small: "data:image/png;base64," + image.small,
                medium: "data:image/png;base64," + image.medium,
                big: "data:image/png;base64," + image.original,
                description: image.description
            });
            return ngxGalleryImage;
        });
    }

    private onCreateAction(pictures: PictureDto[]) {
        this.dialogService.addDialog(
                CreatePictureDialogComponent,
                { monument: this.monument })
            .subscribe(result => {
                if(result) {
                    pictures.push(result);
                    this.setGalleryWithPhotosConfiguration(pictures);
                }
            });
    }

    private onDeleteAction(pictures: PictureDto[]) {
        var pictureToDelete = pictures[this.selectedIndex];

        this.dialogService.addDialog(UserConfirmationDialogComponent,
            { title: 'Delete picture', message: 'Do you want to delete picture?'})
            .subscribe(result => {
                if(!result)
                    return;
                
                var command = new DeletePictureCommand();
                command.pictureId = pictureToDelete.id;
                this.picturesClient.deletePicture(command)
                    .subscribe(_ => { 
                        this.toastr.success('Picture has been deleted', 'Delete picture');
                        var newPicturesList = pictures.filter(s => s.id != pictureToDelete.id);
                        if(newPicturesList.length == 0) {
                            this.setNoPhotoConfiguration();
                        } else {
                            this.setGalleryWithPhotosConfiguration(newPicturesList);
                        }
                    }, _ => this.toastr.error('Cannot delete picture', 'Delete picture'))
            });
    }
}
