import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Contact } from '../../models/contact';
import { ContactService } from '../../service/contact.service';
import { ContactListComponent } from '../../components/contact-list/contact-list/contact-list.component';
import { ContactDetailComponent } from '../../components/contact-deatil/contact-detail.component/contact-detail.component';
import { ContactFormComponent } from '../../components/contact-form/contact-form/contact-form.component';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, ContactListComponent, ContactFormComponent, ContactDetailComponent],
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  contacts: Contact[] = [];
  selectedContact: Contact | null = null;
  showForm = false;
  isEditing = false;
  contactToEdit: Contact | null = null;

  constructor(private contactService: ContactService) {}

  ngOnInit() {
    this.loadContacts();
  }

  loadContacts() {
    this.contactService.getContacts().subscribe(contacts => {
      this.contacts = contacts;
    });
  }

  showContactDetail(contact: Contact) {
    this.selectedContact = contact;
    this.showForm = false;
  }

  showAddForm() {
    this.showForm = true;
    this.isEditing = false;
    this.contactToEdit = null;
    this.selectedContact = null;
  }

  showEditForm(contact: Contact) {
    this.showForm = true;
    this.isEditing = true;
    this.contactToEdit = contact;
    this.selectedContact = null;
  }

  handleContactSaved() {
    this.showForm = false;
    this.loadContacts();
  }

  handleDelete(id: string) {
    if (confirm('Sei sicuro di voler eliminare questo contatto?')) {
      this.contactService.deleteContact(id).subscribe(() => {
        this.loadContacts();
        this.selectedContact = null;
      });
    }
  }
}