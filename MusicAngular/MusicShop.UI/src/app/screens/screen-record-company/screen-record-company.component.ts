import { Component } from '@angular/core';
import { RecordCompany } from 'src/app/models/recordCompany-shop';
import { RecordCompanyService } from 'src/app/services/record-company.service';

@Component({
  selector: 'app-screen-record-company',
  templateUrl: './screen-record-company.component.html',
  styleUrls: ['./screen-record-company.component.css']
})
export class ScreenRecordCompanyComponent {
  
  title = 'MusicShop.UI';
  recordCompanies: RecordCompany[]=[];
  recordCompanyToEdit?: RecordCompany;

  constructor(private recordCompany :RecordCompanyService ){}

  ngOnInit() : void{
    this.recordCompany.getRecordCompany().subscribe((result :RecordCompany[])=>(this.recordCompanies=result));
  }

  updateRecordCompanyList(recordCompany: RecordCompany[])
  {
   this.recordCompanies=recordCompany;
  }

  initNewRecordCompany()
  {
    this.recordCompanyToEdit = new RecordCompany();
  }

  editRecordCompany(recordCompany : RecordCompany)
  {
    this.recordCompanyToEdit = recordCompany;
  }

}
