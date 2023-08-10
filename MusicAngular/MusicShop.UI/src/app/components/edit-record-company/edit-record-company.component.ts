import { Component, EventEmitter, Input, Output } from '@angular/core';
import { RecordCompany } from 'src/app/models/recordCompany-shop';
import { RecordCompanyService } from 'src/app/services/record-company.service';
import { environment } from 'src/environments/environment.prod';

@Component({
  selector: 'app-edit-record-company',
  templateUrl: './edit-record-company.component.html',
  styleUrls: ['./edit-record-company.component.css']
})
export class EditRecordCompanyComponent {

  @Input() recordCompany?: RecordCompany;
  @Output() recordCompaniesUpdated = new EventEmitter<RecordCompany[]>();

  private url="RecordCompany";

  constructor(private recordCompanyService : RecordCompanyService){}

  ngOnInit():void{     

  }

  updateCustomer(recordCompany: RecordCompany){
    this.recordCompanyService.updateRecordCompany(recordCompany).subscribe((recordCompanies)=>this.recordCompaniesUpdated.emit(recordCompanies));
  }

  deleteCustomer(recordCompany: RecordCompany){
    this.recordCompanyService.deleteRecordCompany(recordCompany).subscribe((recordCompanies)=>this.recordCompaniesUpdated.emit(recordCompanies));
  }
  
  createCustomer(recordCompany: RecordCompany){
    this.recordCompanyService.createRecordCompany(recordCompany).subscribe((recordCompanies)=>this.recordCompaniesUpdated.emit(recordCompanies));
  }

}
