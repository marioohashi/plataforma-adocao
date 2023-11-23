import { Component, OnInit } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { filter } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  currentTitle: string = 'Default Title';

  constructor(private router: Router) {}

  ngOnInit() {
    this.router.events.pipe(
      filter(event => event instanceof NavigationEnd)
    ).subscribe(() => {
      this.setCurrentTitle();
    });
  }

  private setCurrentTitle() {
    const currentRoute = this.router.routerState.snapshot.root;
    this.currentTitle = this.getTitleFromRoute(currentRoute);
  }

  private getTitleFromRoute(route: any): string {
    while (route.firstChild) {
      route = route.firstChild;
    }
    return route.data.title || 'Default Title';
  }
}
