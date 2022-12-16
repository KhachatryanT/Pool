import { Injectable } from '@angular/core';

import { Overlay, OverlayRef } from '@angular/cdk/overlay';
import { ComponentPortal } from '@angular/cdk/portal';

import { defer, NEVER } from 'rxjs';
import { finalize, share } from 'rxjs/operators';
import { LoaderComponent } from '../../ui/loader/loader.component';

@Injectable({
  providedIn: 'root',
})
export class LoaderService {
  readonly spinner$ = defer(() => {
    if (!this.isBlockLoader) {
      this.show();
    }

    return NEVER.pipe(
      finalize(() => {
        this.hide();
      })
    );
  }).pipe(share());

  isBlockLoader = false;

  private overlayRef: OverlayRef | undefined;

  constructor(private overlay: Overlay) {}

  private show(): void {
    Promise.resolve(null).then(() => {
      this.overlayRef = this.overlay.create({
        positionStrategy: this.overlay
          .position()
          .global()
          .centerHorizontally()
          .centerVertically(),
        hasBackdrop: true,
      });
      this.overlayRef.attach(new ComponentPortal(LoaderComponent));
    });
  }

  private hide(): void {
    this.overlayRef?.detach();
    this.overlayRef = undefined;
  }
}
