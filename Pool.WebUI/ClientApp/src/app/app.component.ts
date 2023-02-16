import { Component, Inject, PLATFORM_ID } from '@angular/core';

import { fadeAnimation } from './core/animations/fade-animation';
import { ActivatedRoute, RouterOutlet } from '@angular/router';
import { DOCUMENT, isPlatformBrowser } from '@angular/common';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  animations: [fadeAnimation],
})
export class AppComponent {
  constructor(
    @Inject(PLATFORM_ID) private readonly platformId: Object,
    @Inject(DOCUMENT) private readonly document: Document
  ) {
    if (!isPlatformBrowser(platformId)) {
      document.body.style.setProperty('cursor', 'none');
    }
  }

  getRouterOutletState(outlet: RouterOutlet): ActivatedRoute | string {
    return outlet.isActivated ? outlet.activatedRoute : '';
  }
}
