import { Component, OnInit } from '@angular/core';
import { CrudVM } from '../../Class/Crud-vm';
import { CrudService } from '../../Service/crud.service';
import { Observable } from 'rxjs';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
@Component({
  selector: 'app-crud',
  templateUrl: './crud.component.html',
  styleUrls: ['./crud.component.css']
})
export class CrudComponent implements OnInit {
  dataSaved = false;
  massage: string;
  FromCrud: FormGroup;
  CrudId: number = 0;
  allData: Observable<CrudVM[]>;
  constructor(private formbulider: FormBuilder, private CrudService: CrudService) { }
  GetAllData() {
    debugger;
    this.allData = this.CrudService.getAllData();
  }
  Reset() {
    this.FromCrud.reset();
  }
  CreateData(CrudVM: CrudVM) {
    debugger;
    CrudVM.CrudId = this.CrudId;
    if (this.CrudId > 0) {
      this.CrudService.UpdateData(CrudVM).subscribe(
        () => {
          this.dataSaved = true;
          this.massage = 'Record Update Successfully';
          alert(this.massage);
          this.GetAllData();
          this.Reset();
          this.CrudId = 0;
        });
    }
    else {


      this.CrudService.CreateData(CrudVM).subscribe(
        () => {
          this.dataSaved = true;
          this.massage = 'Record saved Successfully';
          alert(this.massage);
          this.GetAllData();
          this.Reset();
          this.CrudId = 0;
        });
    }
  }
  DeleteData(CrudId: number) {
    if (confirm("Are You Sure To Delete this Informations")) {
      this.CrudService.DeleteData(CrudId).subscribe(
        () => {
          this.dataSaved = true;
          this.massage = "Deleted Successfully";
          alert(this.massage);
          this.GetAllData();
        }
      );
    }
  }
  DataEdit(CrudId: number) {
    debugger;
    this.CrudService.getDataById(CrudId).subscribe(Response => {
      this.massage = null;
      this.dataSaved = false;
      debugger;
      this.CrudId = Response.CrudId;
      this.FromCrud.controls['Title'].setValue(Response.Title);
      this.FromCrud.controls['Cost'].setValue(Response.Cost);
      this.FromCrud.controls['Quantity'].setValue(Response.Quantity);
      this.FromCrud.controls['TotalCost'].setValue(Response.TotalCost);
    });
  }

  CalculateTotalCost() {
    var Cost = parseFloat(this.FromCrud.controls["Cost"].value);
    var Quantity = parseFloat(this.FromCrud.controls["Quantity"].value);

    var TotalCost = (Cost * Quantity);
    if (TotalCost > 0) {
      this.FromCrud.controls["TotalCost"].setValue(TotalCost.toFixed(2));
    }

  }

  ngOnInit(): void {
    this.FromCrud = this.formbulider.group({
      Title: ['', [Validators.required]],
      Cost: ['', [Validators.required]],
      Quantity: ['', [Validators.required]],
      TotalCost: ['', [Validators.required]],
    });
    this.GetAllData();
  }
}
