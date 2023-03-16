import { Pipe, PipeTransform } from '@angular/core';
import { EmploymentType } from '../enums/employment-type.enum';

@Pipe({
  name: 'employmentType'
})
export class EmploymentTypePipe implements PipeTransform {

  transform(value: any) : string {
    return EmploymentType[value * 1];
  }

}