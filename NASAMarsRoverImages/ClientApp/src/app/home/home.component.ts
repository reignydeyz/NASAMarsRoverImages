import { Component } from '@angular/core';
import { ApiService } from '../service/api.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  constructor(private apiService: ApiService) { }

  photos: string[] = [];

  ngOnInit() {
    this.apiService.get().then(r => {
      this.photos = r;
    });
  }
}
