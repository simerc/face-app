import { Component, OnInit } from '@angular/core';
import { ImageService } from '../image.service';

import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-image-details',
  templateUrl: './image-details.component.html',
  styleUrls: ['./image-details.component.scss']
})
export class ImageDetailsComponent implements OnInit {

  private image: any;

  constructor(private svc: ImageService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.getImageDetails();
  }

  getImageDetails() {
    const id = this.route.snapshot.paramMap.get("id");

    this.svc.getImageById(id).subscribe(data => {
      this.image = data;
    });

    console.log(this.image);
  }

}
