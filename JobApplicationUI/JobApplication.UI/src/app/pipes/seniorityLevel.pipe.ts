import { Pipe, PipeTransform } from '@angular/core';
import { SeniorityLevel } from '../enums/seniority-level.enum';

@Pipe({
  name: 'seniorityLevel'
})
export class SeniorityLevelPipe implements PipeTransform {

  transform(value: any) : string {
    return SeniorityLevel[value * 1];
  }

}