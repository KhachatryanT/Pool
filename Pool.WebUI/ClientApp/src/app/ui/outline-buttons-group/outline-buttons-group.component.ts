import {
  ChangeDetectionStrategy,
  Component,
  forwardRef,
  Input,
} from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  ControlValueAccessor,
  FormControl,
  NG_VALUE_ACCESSOR,
  ReactiveFormsModule,
} from '@angular/forms';

@Component({
  selector: 'app-outline-buttons-group',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './outline-buttons-group.component.html',
  styleUrls: ['./outline-buttons-group.component.scss'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => OutlineButtonsGroupComponent),
      multi: true,
    },
  ],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class OutlineButtonsGroupComponent implements ControlValueAccessor {
  @Input() buttons!: any;

  formControl = new FormControl();

  ngOnInit(): void {
    this.formControl.valueChanges.subscribe((value) => {
      this.onChange(value);
    });
  }

  registerOnChange(fn: any): void {
    this.onChange = fn;
  }

  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }

  writeValue(value: any): void {
    this.formControl.setValue(value);
  }

  private onChange = (value: any) => {};
  private onTouched = () => {};
}
