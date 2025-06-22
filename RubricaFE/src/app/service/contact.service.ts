import { inject, Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Contact } from '../models/contact';
import { SearchContact } from '../models/search-contact';
import { CreateContact } from '../models/create-contact';
import { UpdateContact } from '../models/update-contact';

@Injectable({ providedIn: 'root' })
export class ContactService {
  private apiUrl = 'https://localhost:7007/api/Contact';

  private cities = [
    'Roma', 'Milano', 'Napoli', 'Torino', 'Palermo', 
    'Genova', 'Bologna', 'Firenze', 'Bari', 'Catania'
  ];
  private http = inject(HttpClient);

  getCities(): Observable<string[]> {
    //return this.cities;
    return this.http.get<string[]>(`${this.apiUrl}/GetAllCities`);
  }

  getContacts(searchParams?: SearchContact): Observable<Contact[]> {
    return this.http.get<Contact[]>(`${this.apiUrl}/GetAllContacts`);
  }

  createContact(contact: CreateContact): Observable<Contact> {
    return this.http.post<Contact>(this.apiUrl, contact);
  }

  updateContact(contact: UpdateContact): Observable<Contact> {
    return this.http.put<Contact>(`${this.apiUrl}`, contact);
  }

  deleteContact(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
