import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { UpdateContact } from '../../../models/update-contact';
import { CreateContact } from '../../../models/create-contact';
import { ContactService } from '../../../service/contact.service';
import { Contact } from '../../../models/contact';
import { error } from 'console';

@Component({
  selector: 'app-contact-form',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './contact-form.component.html',
  styleUrl: './contact-form.component.css'
})
export class ContactFormComponent implements OnInit {
  @Input() contact: Contact | null = null;
  @Input() isEditing = false;
  @Output() saved = new EventEmitter<void>();
  @Output() cancel = new EventEmitter<void>();
  
  cities: string[] = [];
  isSubmitting = false;
  contactForm!: FormGroup; // Rimossa l'inizializzazione diretta

  constructor(
    private fb: FormBuilder,
    private contactService: ContactService
  ) {
    // Inizializzazione nel costruttore
    this.contactForm = this.fb.group({
      name: ['', [Validators.required, Validators.maxLength(30)]],
      surname: ['', [Validators.required, Validators.maxLength(30)]],
      gender: ['', Validators.required],
      birthDate: [''],
      phoneNumber: ['', Validators.pattern(/^\+?[0-9]{9,15}$/)],
      email: ['', [Validators.required, Validators.email]],
      city: ['']
    });

    this.contactService.getCities().subscribe({
      next: x => this.cities = x,
      error: () => alert('Si è verificato un errore durante il caricamento delle cities')
    });
  }

  ngOnInit() {
    if (this.contact) {
      // Converti Date in stringa ISO per l'input
      const contactData = { 
        ...this.contact,
        birthDate: this.contact.birthDate 
          ? this.formatDate(this.contact.birthDate) 
          : null
      };
      
      this.contactForm.patchValue(contactData);
    }
  }

  // Formatta la data per l'input (YYYY-MM-DD)
  private formatDate(date: Date): string {
    const d = new Date(date);
    const year = d.getFullYear();
    const month = ('0' + (d.getMonth() + 1)).slice(-2);
    const day = ('0' + d.getDate()).slice(-2);
    return `${year}-${month}-${day}`;
  }

  onSubmit() {
    if (this.contactForm.invalid || this.isSubmitting) return;

    this.isSubmitting = true;
    const formValue = this.contactForm.value;
    
    if (this.isEditing && this.contact) {

      const dto = new UpdateContact({
        ...formValue,
        id: this.contact.id,
        birthDate: formValue.birthDate 
      });

      this.contactService.updateContact(
        dto
      ).subscribe({
        next: () => this.handleSuccess(),
        error: () => this.handleError()
      });
    } else {

      const dto = new CreateContact({
        ...formValue,
        birthDate: formValue.birthDate
      })

      this.contactService.createContact(
        dto
      ).subscribe({
        next: () => this.handleSuccess(),
        error: () => this.handleError()
      });
    }
  }

  handleSuccess() {
    this.saved.emit();
    this.isSubmitting = false;
  }

  handleError() {
    alert('Si è verificato un errore durante il salvataggio');
    this.isSubmitting = false;
  }

  get nameError() {
    const nameCtrl = this.contactForm.get('name');
    if (nameCtrl?.hasError('required')) return 'Nome obbligatorio';
    if (nameCtrl?.hasError('maxlength')) return 'Massimo 30 caratteri';
    return '';
  }

  get surnameError() {
    const surnameCtrl = this.contactForm.get('surname');
    if (surnameCtrl?.hasError('required')) return 'Cognome obbligatorio';
    if (surnameCtrl?.hasError('maxlength')) return 'Massimo 30 caratteri';
    return '';
  }

  get emailError() {
    const emailCtrl = this.contactForm.get('email');
    if (emailCtrl?.hasError('required')) return 'Email obbligatoria';
    if (emailCtrl?.hasError('email')) return 'Email non valida';
    return '';
  }

  get phoneError() {
    const phoneCtrl = this.contactForm.get('phoneNumber');
    if (phoneCtrl?.hasError('pattern')) return 'Numero di telefono non valido';
    return '';
  }
}