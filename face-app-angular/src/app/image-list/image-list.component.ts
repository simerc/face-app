import { Component, OnInit } from '@angular/core';

import { ImageService } from '../image.service';

@Component({
  selector: 'app-image-list',
  templateUrl: './image-list.component.html',
  styleUrls: ['./image-list.component.scss']
})
export class ImageListComponent implements OnInit {

  private imageData: any;

  constructor(private svc: ImageService) { }

  ngOnInit() {
    this.svc.getImages().subscribe(data => {
      this.imageData = data;
    });
  }

}
