import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-edit-notes',
  templateUrl: './edit-notes.component.html',
  styleUrls: ['./edit-notes.component.css']
})
export class EditNotesComponent implements OnInit {
  @Input() notes: string;
  @Input() id: number;
  @Output() save = new EventEmitter<string>();
  @Output() close = new EventEmitter<void>();
  constructor() { }

  ngOnInit(): void {
  }

  onSave() {
    this.save.emit(this.notes);
  }

  onClose() {
    this.close.emit();
  }

}
