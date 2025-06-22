import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Contact } from '../../../models/contact';

@Component({
  selector: 'app-contact-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './contact-list.component.html',
  styleUrls: ['./contact-list.component.css']
})
export class ContactListComponent {
  @Input({ required: true }) contacts: Contact[] = [];
  @Output() select = new EventEmitter<Contact>();

  selectContact(contact: Contact) {
    this.select.emit(contact);
  }
}
