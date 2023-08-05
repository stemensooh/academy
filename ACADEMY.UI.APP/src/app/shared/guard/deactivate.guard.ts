import { CanDeactivateFn } from "@angular/router";
import { Observable } from "rxjs";

export const deactivateGuard: CanDeactivateFn<CanDeactivateComponent> = (component) => {
  return component.canExit();
};

export interface CanDeactivateComponent {
  canExit(): boolean | Observable<boolean>;
}
