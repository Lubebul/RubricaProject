export interface Contact {
    id: string;             
    name: string;
    surname: string;
    //gender: 'Male'|'Female'; 
    gender: 0|1; 
    email: string;
    phoneNumber?: string;
    city?: string;
    birthDate?: Date;     // YYYY-MM-DD
  }