import { Directive } from '@angular/core';
import { NG_VALIDATORS, AbstractControl, ValidatorFn, Validator, FormControl } from '@angular/forms';

// validation function
function validateDateFactory(): ValidatorFn {
  return (c: AbstractControl) => {

    let enteredDate = new Date(c.value);
    let currentDate = new Date();
    let diff = Math.floor((Date.UTC(enteredDate.getFullYear(), enteredDate.getMonth(), enteredDate.getDate()) - Date.UTC(currentDate.getFullYear(), currentDate.getMonth(), currentDate.getDate())) / (1000 * 60 * 60 * 24));


    let isValid = diff > 30;

    if (isValid) {
      return null;
    } else {
      return {
        expiredMedicine: {
          valid: false
        }
      };
    }

  }
}

@Directive({
  selector: '[appExpireMedicineValidator]',
  providers: [
    { provide: NG_VALIDATORS, useExisting: ExpireMedicineValidatorDirective, multi: true }
  ]
})
export class ExpireMedicineValidatorDirective implements Validator {
  validator: ValidatorFn;
  constructor() {
    this.validator = validateDateFactory();
  }
  validate(c: FormControl) {
    return this.validator(c);
  }
}
